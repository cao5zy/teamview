using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TeamView.Common
{
    public static class Utility
    {
        public static byte[] ReadBytes(Stream stream)
        {
            using (var mem = new MemoryStream())
            {
                int readLength = 1024;
                byte[] readBuffer = new byte[readLength];

                long totalLength = stream.Length;
                if (totalLength < readLength)
                {
                    int n = stream.Read(readBuffer, 0, (int)stream.Length);
                    mem.Write(readBuffer, 0, n);
                    return mem.ToArray();
                }

                while (true)
                {
                    int n = stream.Read(readBuffer, 0, readLength);
                    if (n == 0)
                        return mem.ToArray();
                    else
                    {
                        mem.Write(readBuffer, 0, n);
                    }
                }
            }

        }

        public static void WriteBytes(byte[] buffer, Stream stream)
        {
            using (var mem = new MemoryStream(buffer))
            {
                int writeLength = 1024;
                byte[] writeBuffer = new byte[writeLength];
                if (mem.Length < writeLength)
                {
                    stream.Write(mem.ToArray(), 0, (int)mem.Length);
                    return;
                }

                while (true)
                {
                    int n = mem.Read(writeBuffer, 0, writeLength);
                    if (n == 0)
                        break;
                    stream.Write(writeBuffer, 0, n);
                }
            }
        }
    }
}
