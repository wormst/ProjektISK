using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjektISK.Models
{
    [Serializable]
    public class Packet
    {
        public Packet(List<Frame> frames, string checksum)
        {
            Frames = frames;
            Checksum = checksum;
        }

        public List<Frame> Frames { get; }
        public string Checksum { get; }

        public string GetBytes()
        {
            return string.Join("", Frames.Select(f => f.GetFrame())) + Checksum;
        }

        public Packet DeepClone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Packet)formatter.Deserialize(ms);
            }
        }
    }
}
