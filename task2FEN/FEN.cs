using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2FEN
{
    enum Piece : int
    {
        whitePawns = 0,
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
            //2 ^ (64 - 1) == 9223372036854775808
            ulong position = 9223372036854775808;//Math.Pow(2,64);
            string positions = "7k/8/8/8/8/8/8/K7";//data[0];
            position >>= 7;
            foreach (char item in positions)
            {
                if (item == '/')
                {
                    position >>= 8;
                    continue;
                }


                switch (item)
                {
                    //K, Q, R, B, N, P — белые король, ферзь, ладья, слон, конь, пешка. 
                    //k, q, r, b, n, p — чёрные король, ферзь, ладья, слон, конь, пешка.
                    case 'K':
                        board[(int)Piece.whiteKing] += position;
                        break;

                    case 'Q':
                        board[(int)Piece.whiteQueens] += position;
                        break;

                    case 'R':
                        board[(int)Piece.whiteRooks] += position;
                        break;

                    case 'B':
                        board[(int)Piece.whiteBishops] += position;
                        break;

                    case 'N':
                        board[(int)Piece.whiteKnights] += position;
                        break
                            ;
                    case 'P':
                        board[(int)Piece.whitePawns] += position;
                        break;


                    case 'k':
                        board[(int)Piece.blackKing] += position;
                        break;

                    case 'q':
                        board[(int)Piece.blackQueens] += position;
                        break;

                    case 'r':
                        board[(int)Piece.blackRooks] += position;
                        break;

                    case 'b':
                        board[(int)Piece.blackBishops] += position;
                        break;

                    case 'n':
                        board[(int)Piece.blackKnights] += position;
                        break;

                    case 'p':
                        board[(int)Piece.blackPawns] += position;
                        break;

                    default:

                        position = position << (int)Char.GetNumericValue(item);
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
