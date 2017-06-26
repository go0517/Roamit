﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickShare.HelperClasses.VersionHelpers
{
    static class TrialSettings
    {
        public static readonly double MaxSizeForTrialVersion = 5.0;

        private static bool isTrial = false;

        public static bool IsTrial
        {
            get
            {
                return isTrial;
            }
            set
            {
                isTrial = value;
                IsTrialChanged?.Invoke();
            }
        }

        public delegate void ReceiveFileProgressEventHandler();
        public static event ReceiveFileProgressEventHandler IsTrialChanged;
    }
}