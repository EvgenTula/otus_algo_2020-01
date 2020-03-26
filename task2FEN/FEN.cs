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
            ulong position = 9223372036854775808;

            string positions =  data[0];
            position >>= 7;

            ulong currentPosition = position;
            foreach (char item in positions)
            {
                if (item == '/')
                {
                    position >>= 8;
                    currentPosition = position;
                    continue;
                }


                switch (item)
                {
                    case 'K':
                        board[(int)Piece.whiteKing] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'Q': 
                        board[(int)Piece.whiteQueens] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'R': 
                        board[(int)Piece.whiteRooks] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'B': 
                        board[(int)Piece.whiteBishops] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'N': 
                        board[(int)Piece.whiteKnights] += currentPosition;
                        currentPosition <<= 1;
                        break;
                            
                    case 'P': 
                        board[(int)Piece.whitePawns] += currentPosition;
                        currentPosition <<= 1;
                        break;
 

                    case 'k': 
                        board[(int)Piece.blackKing] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'q': 
                        board[(int)Piece.blackQueens] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'r': 
                        board[(int)Piece.blackRooks] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'b': 
                        board[(int)Piece.blackBishops] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'n': 
                        board[(int)Piece.blackKnights] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    case 'p': 
                        board[(int)Piece.blackPawns] += currentPosition;
                        currentPosition <<= 1;
                        break;

                    default:
                        currentPosition = currentPosition << (int)Char.GetNumericValue(item);
                        break;

                }
            }

            String result = "";

            for(int i = 0; i < board.Length; i++)
            {
                if (result != "")
                    result += "\r\n";
                result += board[i].ToString();
            }
         
            return result;

        }
    }
}
