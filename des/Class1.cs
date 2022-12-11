using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Properties
{
    public class DataEncryptionStandard
    {



        public UInt64 initialPermutation(UInt64 source)
        {


            int[] permutationTable = new int[64]   { 58, 50, 42, 34, 26, 18, 10, 2,
                                                     60, 52, 44, 36, 28, 20, 12, 4,
                                                     62, 54, 46, 38, 30, 22, 14, 6,
                                                     64, 56, 48, 40, 32, 24, 16, 8,
                                                     57, 49, 41, 33, 25, 17, 9,  1,
                                                     59, 51, 43, 35, 27, 19, 11, 3,
                                                     61, 53, 45, 37, 29, 21, 13, 5,
                                                     63, 55, 47, 39, 31, 23, 15, 7  };

            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 64; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 64 - permutationTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 63)
                {
                    break;
                }

                result <<= 1;
            }

            return result;
        }

        public UInt64 finalPermutation(UInt64 source)
        {

            int[] permutationTable = new int[64]   { 40, 8, 48, 16, 56, 24, 64, 32,
                                                     39, 7, 47, 15, 55, 23, 63, 31,
                                                     38, 6, 46, 14, 54, 22, 62, 30,
                                                     37, 5, 45, 13, 53, 21, 61, 29,
                                                     36, 4, 44, 12, 52, 20, 60, 28,
                                                     35, 3, 43, 11, 51, 19, 59, 27,
                                                     34, 2, 42, 10, 50, 18, 58, 26,
                                                     33, 1, 41, 9,  49, 17, 57, 25  };

            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 64; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 64 - permutationTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 63)
                {
                    break;
                }

                result <<= 1;
            }

            return result;
        }


        public UInt64 extension(UInt64 source)
        {


            int[] extensionTable = new int[48]  { 32, 1, 2,3,4,5,
                                                    4,5,6,7,8,9,
                                                    8,9,10,11,12,13,
                                                    12,13,14,15,16,17,
                                                    16,17,18,19,20,21,
                                                    20,21,22,23,24,25,
                                                    24,25,26,27,28,29,
                                                    28,29,30,31,32,1 };
            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 48; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 32 - extensionTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 47)
                {
                    break;
                }

                result <<= 1;
            }


            return result;
        }
        UInt64 s_Block(UInt64 s, int number = 1)
        {
            /*TO DO*/
            UInt64[,] table = new UInt64[,] { { 14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7 },
                                        { 0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8 },
                                        { 4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                                        { 15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13} }; ;


            switch (number)
            {
                case 1:
                    {
                        table = new UInt64[,] { { 14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7 },
                                        { 0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8 },
                                        { 4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                                        { 15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13} };
                    }
                    break;
                case 2:
                    {
                        table = new UInt64[,] {{ 15,  1,   8, 14,   6, 11,   3,  4,   9,  7,   2, 13,  12,  0,   5, 10},
                                                 { 3, 13,   4,  7,  15,  2,   8, 14,  12,  0,   1, 10,   6,  9,  11,  5},
                                                 { 0, 14,   7, 11,  10,  4,  13,  1,   5,  8,  12,  6,   9,  3,   2, 15},
                                                 { 13,  8,  10,  1,   3, 15,   4,  2,  11,  6,   7, 12,   0,  5,  14,  9}};
                    }
                    break;
                case 3:
                    {
                        table = new UInt64[,] {{  10,  0,   9, 14,   6,  3,  15,  5,   1, 13,  12,  7,  11,  4,   2,  8},
                                                 { 13,  7,   0,  9,   3,  4,   6, 10,   2,  8,   5, 14,  12, 11,  15,  1},
                                                 { 13,  6,   4,  9,   8, 15,   3,  0,  11,  1,   2, 12,   5, 10,  14,  7},
                                                 { 1, 10,  13,  0,   6,  9,   8,  7,   4, 15,  14,  3,  11,  5,   2, 12} };
                    }
                    break;
                case 4:
                    {
                        table = new UInt64[,] {{   7, 13,  14,  3,   0,  6,   9, 10,   1,  2,   8,  5,  11, 12,   4, 15 },
                                                { 13,  8,  11,  5,   6, 15,   0,  3,   4,  7,   2, 12,   1, 10,  14,  9 },
                                                { 10,  6,   9,  0,  12, 11,   7, 13,  15,  1,   3, 14,   5,  2,   8,  4 },
                                                {  3, 15,   0,  6,  10,  1,  13,  8,   9,  4,   5, 11,  12,  7,   2, 14 } };
                    }
                    break;
                case 5:
                    {
                        table = new UInt64[,] {{   2, 12,   4,  1,   7, 10,  11,  6,   8,  5,   3, 15,  13,  0,  14,  9 },
                                                { 14, 11,   2, 12,   4,  7,  13,  1,   5,  0,  15, 10,   3,  9,   8,  6},
                                                {  4,  2,   1, 11,  10, 13,   7,  8,  15,  9,  12,  5,   6,  3,   0, 14},
                                                { 11,  8,  12,  7,   1, 14,   2, 13,   6, 15,   0,  9,  10,  4,   5,  3} };
                    }
                    break;
                case 6:
                    {
                        table = new UInt64[,] {{  12,  1,  10, 15,   9,  2,   6,  8,   0, 13,   3,  4,  14,  7,   5, 11},
                                                { 10, 15,   4,  2,   7, 12,   9,  5,   6,  1,  13, 14,   0, 11,   3,  8},
                                                {  9, 14,  15,  5,   2,  8,  12,  3,   7,  0,   4, 10,   1, 13,  11,  6},
                                                {  4,  3,   2, 12,   9,  5,  15, 10,  11, 14,   1,  7,   6,  0,   8, 13} };
                    }
                    break;
                case 7:
                    {
                        table = new UInt64[,] {{  4, 11,   2, 14,  15,  0,   8, 13,   3, 12,   9,  7,   5, 10,   6 , 1 },
                                                { 13,  0,  11,  7,   4,  9,   1, 10,  14,  3,   5, 12,   2, 15,   8,  6},
                                                {  1,  4,  11, 13,  12,  3,   7, 14,  10, 15,   6,  8,   0,  5,   9,  2},
                                                {  6, 11,  13,  8,   1,  4,  10,  7,   9,  5,   0, 15,  14,  2,   3, 12} };
                    }
                    break;
                case 8:
                    {
                        table = new UInt64[,] {{  13,  2,   8,  4,   6, 15,  11,  1,  10,  9,   3, 14,   5,  0,  12,  7},
                                                {  1, 15,  13,  8,  10,  3,   7,  4,  12,  5,   6, 11,   0, 14,   9,  2},
                                                {  7, 11,   4,  1,   9, 12,  14,  2,   0,  6,  10, 13,  15,  3,   5,  8},
                                                {  2,  1,  14,  7,   4, 10,   8, 13,  15, 12,   9,  0,   3,  5,   6, 11} };
                    }
                    break;
            }


            ulong index1 = s & 0b100000;
            index1 >>= 4;
            index1 += s & 0b1;

            ulong index2 = s & 0b11110;
            index2 >>= 1;



            return table[index1, index2];
        }

        public UInt64 f_Function(UInt64 r, UInt64 ki)
        {
            r = extension(r);

            UInt64 s = r ^ ki; // XOR

            UInt64[] sBox = new UInt64[8];


            for (int i = 0; i < 8; i++)
            {
                int movePointer = 42 - 6 * i;
                ulong temp = (Convert.ToUInt64(0b111111) << movePointer);
                temp = temp & s;
                temp >>= 42 - 6 * i;

                sBox[i] = s_Block(temp, i + 1);

            }
            s = 0;
            for (int i = 0; i < sBox.Length; i++)
            {
                s += (sBox[i] << (28 - i * 4));
            }

            s = p_Permutation(s);

            return s;
        }

        public UInt64 p_Permutation(UInt64 source)
        {
            int[] permutationTable = new int[32] { 16,7,20,21,29,12,28,17,
                                                    1,15,23,26,5,18,31,10,
                                                    2,8,24,14,32,27,3,9,
                                                    19,13,30,6,22,11,4,25};


            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 32; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 32 - permutationTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 31)
                {
                    break;
                }

                result <<= 1;
            }


            return result;
        }


        public UInt64 feistelNetwork(UInt64 message, UInt64 key, bool cryptor = true)
        {
            UInt64 right = message & 0b11111111111111111111111111111111;
            UInt64 left = message & 0b1111111111111111111111111111111100000000000000000000000000000000;
            left >>= 32;

            key = permutedChoice(key);


            UInt64 d = key & 0b1111111111111111111111111111;
            UInt64 c = key & 0b11111111111111111111111111110000000000000000000000000000;
            c >>= 28;

            UInt64 f;
            UInt64 temp;

            UInt64[] keyBox = new UInt64[16];

            for (int i = 1; i <= 16; i++)
            {


                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    c = rotate(c, 1);
                    d = rotate(d, 1);
                }
                else
                {
                    c = rotate(c, 2);
                    d = rotate(d, 2);
                }
                key = c;
                key <<= 28;
                key += d;
                key = permutedChoice2(key);

                keyBox[i - 1] = key;



            }

            for (int i = 1; i <= 16; i++)
            {
                if (cryptor)
                    f = f_Function(right, keyBox[i - 1]);
                else //Decryptor
                    f = f_Function(right, keyBox[16 - i]);
                temp = left;
                left = right;
                right = (temp ^ f);
            }


            message = right;
            message <<= 32;
            message += left;

            return message;
        }

        public UInt64 permutedChoice2(ulong source)
        {
            int[] permutationTable = new int[48] {14,17,11,24,1,5,3,28,
                                                  15,6,21,10,23,19,12,4,
                                                  26,8,16,7,27,20,13,2,
                                                  41,52,31,37,47,55,30,40,
                                                  51,45,33,48,44,49,39,56,
                                                  34,53,46,42,50,36,29,32
                                                        };


            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 48; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 56 - permutationTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 47)
                {
                    break;
                }

                result <<= 1;
            }


            return result;
        }

        public ulong rotate(ulong sequence, int v)
        {

            for (int i = 0; i < v; i++)
            {
                if (Convert.ToBoolean(sequence & 0x8000000))
                {
                    sequence ^= 0x8000000;
                    sequence <<= 1;
                    sequence += 0x1;
                }
                else
                {
                    sequence <<= 1;
                }

            }

            return sequence;
        }

        public ulong permutedChoice(ulong source)
        //64 bits in
        //56 bits out
        {
            int[] permutationTable = new int[56] { 57,   49,    41,   33,    25,    17,    9,
                                                   1,   58,    50,  42,    34,    26,   18,
                                                  10,    2,    59,   51,    43,    35,   27,
                                                  19,   11,     3,   60,    52,    44,   36,
                                                  63,   55,    47,   39,   31,    23,   15,
                                                   7,   62,    54,   46,    38,    30,   22,
                                                  14,    6,    61,   53,    45,    37,   29,
                                                  21,   13,     5,   28,    20,    12,    4
                                                        };


            UInt64 copySource = source;
            UInt64 result = 0;
            for (int i = 0; i < 56; i++)
            {
                UInt64 temp = Convert.ToUInt64(1) << 64 - permutationTable[i];

                result += (Convert.ToBoolean(copySource & temp)) ? Convert.ToUInt64(1) : Convert.ToUInt64(0);

                if (i == 55)
                {
                    break;
                }

                result <<= 1;
            }


            return result;

        }


        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string Des(string message, ulong key, bool cryptor = true)
        {
          

          
            byte[] startArr = new byte[8];

            int index = 0;

         
            UInt64 microMessage = 0;

            string output = "";

           
            int rest = 8 - message.Length % 8;
            for (int i = 0; rest != 8 && i < rest; i++)
                message += ' ';
            Console.WriteLine(message.Length);


            for (int a = 0; a < (message.Length / 8); a++)
            {
                microMessage = 0;
            
                for (int i = 0; i < 8; i++)
                {
                    startArr[i] = Convert.ToByte(message[index++]);
                }
                for (int i = 0; i < 8; i++)
                {
                    microMessage += startArr[i];
                    if (i < 7) { microMessage <<= 8; }

                }

               
                microMessage = initialPermutation(microMessage);
                microMessage = feistelNetwork(microMessage, key, cryptor);
                microMessage = finalPermutation(microMessage);

                output += convertUInt64ToString(microMessage);

            }


            return output;
        }



        public string convertUInt64ToString(UInt64 microMessage)
        {
            string result = "";
            for (int i = 0; i < 8; i++)
            {
                result += Convert.ToChar(microMessage & 0b11111111);
                if (i < 7) { microMessage >>= 8; }

            }
            return Reverse(result);
        }
    }

}