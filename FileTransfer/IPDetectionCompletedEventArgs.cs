﻿using System;

namespace QuickShare.FileTransfer
{
    public class IPDetectionCompletedEventArgs
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string MyIP { get; set; }
        public string TargetIP { get; set; }
    }
}