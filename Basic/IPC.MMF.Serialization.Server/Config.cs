﻿using System;
using System.Collections.Generic;
using System.Data;

namespace IPC.MMF
{
    public static class Config
    {     
        public const string MAPPED_FILE_NAME = @"ipcmmfserializationtest";
        public const long BufferSize = 65535;
    }

    public class AudioDataDTO
    {
        public IList<float> Samples { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }       
    }
}