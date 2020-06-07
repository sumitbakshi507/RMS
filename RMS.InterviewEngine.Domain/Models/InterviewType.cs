using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.InterviewEngine.Domain.Models
{
    public static class InterviewTypeConstant
    {
        public static int PreScreening = 0;
        public static int Telephonic = 1;
        public static int FaceToFace = 2;
        public static int Video = 3;
    }

    public static class InterviewStatusConstant
    {
        public static int Pending = 0;
        public static int Pass = 1;
        public static int Fail = 2;
    }

    public enum InterviewType {
        PreScreening = 0,
        Telephonic = 1,
        FaceToFace = 2,
        Video = 3
    }

    public enum InterviewStatus { 
        Pending = 0,
        Pass = 1,
        Fail =2
    }
}
