using System;

namespace ProjektISK.Models
{
    [Serializable]
    public class Frame
    {
        public Frame(string data, string checksum)
        {
            Data = data;
            Checksum = checksum;
        }

        public string Data { get; }
        public string Checksum { get; }

        public string GetFrame()
        {
            return Data + Checksum;
        }
    }
}
