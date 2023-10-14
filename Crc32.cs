using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmpconversion
{
    internal class Crc32
    {
        private uint[] table;
        private const uint Polynomial = 0xEDB88320;

        public Crc32()
        {
            table = GenerateTable();
        }

        private uint[] GenerateTable()
        {
            uint[] table = new uint[256];

            for (uint i = 0; i < 256; i++)
            {
                uint value = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((value & 1) == 1)
                    {
                        value = (value >> 1) ^ Polynomial;
                    }
                    else
                    {
                        value >>= 1;
                    }
                }
                table[i] = value;
            }

            return table;
        }

        public uint ComputeChecksum(byte[] bytes)
        {
            uint crc = 0xFFFFFFFF;

            for (int i = 0; i < bytes.Length; i++)
            {
                byte index = (byte)((crc ^ bytes[i]) & 0xFF);
                crc = (crc >> 8) ^ table[index];
            }

            return ~crc;
        }
    }
}
