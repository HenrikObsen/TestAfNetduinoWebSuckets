using System;
using Microsoft.SPOT;

namespace TestAfNetduino
{
    public struct MorseChar
    {
        public readonly byte[] Code;

        private MorseChar(char c)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'B':
                case 'b':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'C':
                case 'c':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'D':
                case 'd':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'E':
                case 'e':
                    Code = new byte[] { 1, 0, 0, 0 };
                    break;
                case 'F':
                case 'f':
                    Code = new byte[] { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'G':
                case 'g':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'H':
                case 'h':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'I':
                case 'i':
                    Code = new byte[] { 1, 0, 1, 0, 0, 0 };
                    break;
                case 'J':
                case 'j':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'K':
                case 'k':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'L':
                case 'l':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'M':
                case 'm':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'N':
                case 'n':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'O':
                case 'o':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'P':
                case 'p':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'Q':
                case 'q':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'R':
                case 'r':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'S':
                case 's':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case 'T':
                case 't':
                    Code = new byte[] { 1, 1, 1, 0, 0, 0 };
                    break;
                case 'U':
                case 'u':
                    Code = new byte[] { 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'V':
                case 'v':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'W':
                case 'w':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'X':
                case 'x':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'Y':
                case 'y':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case 'Z':
                case 'z':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case ' ':
                    Code = new byte[] { 0, 0, 0, 0 };
                    break;
                case '1':
                    Code = new byte[] { 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case '2':
                    Code = new byte[] { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case '3':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case '4':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                case '5':
                    Code = new byte[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case '6':
                    Code = new byte[] { 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case '7':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case '8':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0 };
                    break;
                case '9':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 };
                    break;
                case '0':
                    Code = new byte[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 };
                    break;
                default:
                    Code = new byte[0];
                    break;
            }
        }

        public static MorseChar FromChar(char c)
        {
            return new MorseChar(c);
        }
    }
}


