using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2FEN
{
    enum Piece
    {
        whitePawns,
        whiteKnights,
        whiteBishops,
        whiteRooks,
        whiteQueens,
        whiteKing,

        blackPawns,
        blackKnights,
        blackBishops,
        blackRooks,
        blackQueens,
        blackKing
    }

    class Fen : Task
    {
        public override string Run(string[] data)
        {
            ulong[] board = new ulong[12];
            //2 ^ (64 - 1)
            ulong f = Math.Pow(2,64);
            string position = "7k/8/8/8/8/8/8/K7";//data[0];
            foreach(var item in position)
            {
                switch (item)
                {
                    case 'K':
                        break;

                    case 'Q':
                        break;

                    case 'R':
                        break;

                    case 'B':
                        break;

                    case 'N':
                        break
                            ;
                    case 'P':
                        break;


                    case 'k':
                        break;

                    case 'q':
                        break;

                    case 'r':
                        break;

                    case 'b':
                        break;

                    case 'n':
                        break;

                    case 'p':
                        break;

                    default:
                        f = f << Convert.ToInt32(item);
                        break;

                }
            }
            /*
            ulong k = 1ul << x;
            ulong nA = 0xFEFEFEFEFEFEFEFE;
            ulong nH = 0x7F7F7F7F7F7F7F7F;
            ulong mask =


                        ((k & nH) << 1) | ((k & nA) >> 1) |
                        ((k & nA) << 7) | ((k & nH) >> 7) |
                        (k << 8) | (k >> 8) |
                        ((k & nH) << 9) | ((k & nA) >> 9);
            result = mask.ToString();
            long cnt = 0;
            while (mask > 0)
            {
                cnt++;
                mask &= mask - 1;
            }
            */
            //return cnt + "\r\n" + result;

            return "";
        }
    }
}
