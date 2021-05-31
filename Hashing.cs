using System;
using System.Collections.Generic;
using System.Text;

namespace LoanModule
{
    public class Hashing
    {
        public double GetCubeRoot(int n)
        {
            return Math.Pow(n,.3333d);
        }

        public double GetSquareRoot(int n)
        {
            return Math.Pow(n,.5d);
        }

        public uint ShiftRightNBits(uint number, int n)
        {
            return number >> n;
        }

        public uint RotateRightNBits(uint number, int n)
        {
            uint left = number << 32-n;
            uint right = number >> n;

            uint res = (right | left);
            return res;
        }

        public uint BitwiseXOR(uint a, uint b)
        {
            return a^b;
        }

        public uint BitwiseAdd(uint a, uint b)
        {
            return ((uint)((a + b) % (Math.Pow(2,32)-1)));
        }

        public uint Sigma0(uint number)
        {
            uint a = RotateRightNBits(number,7);
            uint b = RotateRightNBits(number,18);
            uint c = ShiftRightNBits(number,3);

            uint d = BitwiseXOR(a, b);
            uint e = BitwiseXOR(d, c);

            return e;
        }
        public uint Sigma1(uint number)
        {
            uint a = RotateRightNBits(number, 17);
            uint b = RotateRightNBits(number, 19);
            uint c = ShiftRightNBits(number, 10);

            uint d = BitwiseXOR(a, b);
            uint e = BitwiseXOR(d, c);

            return e;
        }
        public uint USigma0(uint number)
        {
            uint a = RotateRightNBits(number, 2);
            uint b = RotateRightNBits(number, 13);
            uint c = RotateRightNBits(number, 22);

            uint d = BitwiseXOR(a, b);
            uint e = BitwiseXOR(d, c);

            return e;
        }
        public uint USigma1(uint number)
        {
            uint a = RotateRightNBits(number, 6);
            uint b = RotateRightNBits(number, 11);
            uint c = RotateRightNBits(number, 25);

            uint d = BitwiseXOR(a, b);
            uint e = BitwiseXOR(d, c);

            return e;
        }
        public uint ChoiceBasedOnX(uint x, uint y, uint z)
        {
            uint res = 0;

            for (int i = 31; i >= 0; i--)
            {
                if ((x & (1u << i)) > 0)
                {
                    res |=  y & (1u << i);
                }
                else
                {
                    res |= z & (1u << i);
                }
            }
            
            return res;
        }
        public uint Majority(uint x, uint y, uint z)
        {
            uint a = x & y;
            uint b = x & z;
            uint c = y & z;

            uint d = BitwiseXOR(a, b);
            uint e = BitwiseXOR(d, c);

            return (e);
        }
        public void ConstantGen()
        {
            int[] constants = new int[64] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,
                43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127,
                131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 
                223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311};

            foreach (int c in constants)
            {
                double x = GetCubeRoot(c);
                x -= (int)x;
                x *= Math.Pow(2, 32);
            }
        }
    }
}
//abc = BA7816BF 8F01CFEA 414140DE 5DAE2223 B00361A3 96177A9C B410FF61 F20015AD
//abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq = 248D6A61 D20638B8 E5C02693 0C3E6039 A33CE459 64FF2167 F6ECEDD4 19DB06C1