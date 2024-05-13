﻿
namespace Core.Models
{
    public class ConfigSettings
    {
        public string Browser { get; set; }
        public int Timeout { get; set; }
        public int PageLoadTimeout { get; set; }
        public int PollingInterval { get; set; }
    }
}
