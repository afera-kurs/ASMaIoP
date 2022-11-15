using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMaIoP.Client.Models.Network
{
    internal class PacketMath
    {
        private int nCounter;
        public int Counter { get => nCounter; }

        public PacketMath(int start)
        {
            nCounter = start;
        }

        public void AddInt() => nCounter += sizeof(int);

        void AddByte() => nCounter++;

        public void AddBytes(int nCount) => nCounter += nCount;

        /*
         * return -> Count of symbols
         * nEnd -> end of the string
         */
        public int AddString(int nEnd)
        {
            int res = nCounter - nEnd;
            nCounter += nEnd;

            return res;
        }
    }
}
