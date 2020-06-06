using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RMS.CandidateEngine.Domain.CommandHandlers;
using RMS.CandidateEngine.Domain.Commands;
using RMS.CandidateEngine.Domain.EventHandlers;
using RMS.CandidateEngine.Domain.Events;
using RMS.Domain.Core.Bus;
using RMS.Infra.Bus;
using RMS.JobPostEngine.Application.Contracts;
using RMS.JobPostEngine.Application.Services;
using RMS.JobPostEngine.Data.Context;
using RMS.JobPostEngine.Data.Repository;
using RMS.JobPostEngine.Domain.CommandHandlers;
using RMS.JobPostEngine.Domain.Commands;
using RMS.JobPostEngine.Domain.EventHandlers;
using RMS.JobPostEngine.Domain.Events;
using RMS.JobPostEngine.Domain.Interfaces;
using RMS.RequestEngine.Application.Interfaces;
using RMS.RequestEngine.Application.Services;
using RMS.RequestEngine.Data.Context;
using RMS.RequestEngine.Data.Repository;
using RMS.RequestEngine.Domain.CommandHandlers;
using RMS.RequestEngine.Domain.Commands;
using RMS.RequestEngine.Domain.EventHandlers;
using RMS.RequestEngine.Domain.Events;
using RMS.RequestEngine.Domain.Interfaces;

namespace RMS.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RMSBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RMSBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<ManpowerRequestEventHandler>();
            services.AddTransient<JobCreatedEventHandler>();
            services.AddTransient<PublishWebsitePostEventHandler>();
            services.AddTransient<ResumeReceivedEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<ManpowerRequestCreatedEvent>, ManpowerRequestEventHandler>();
            services.AddTransient<IEventHandler<RMS.JobPostEngine.Domain.Events.JobCreatedEvent>, JobCreatedEventHandler>();
            services.AddTransient<IEventHandler<PublishWebsitePostEvent>, PublishWebsitePostEventHandler>();
            services.AddTransient<IEventHandler<ResumeReceivedEvent>, ResumeReceivedEventHandler>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreateJobCommand, bool>, CreateJobCommandHandler>();
            services.AddTransient<IRequestHandler<PublishWebsitePostCommand, bool>, PublishWebsitePostCommandHandler>();
            services.AddTransient<IRequestHandler<NotifyCommand, bool>, NotifyCommandHandler>();

            //Application Services
            services.AddTransient<IManpowerRequestService, ManpowerRequestService>();
            services.AddTransient<IJobService, JobService>();

            //Data
            services.AddTransient<IManpowerRequestRepository, ManpowerRequestRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IJobPostRepository, JobPostRepository>();
            services.AddTransient<IExternalSystemRepository, ExternalSystemRepository>();
            services.AddTransient<RequestEngineDbContext>();
            services.AddTransient<JobPostEngineDbContext>();
        }
    }
}
