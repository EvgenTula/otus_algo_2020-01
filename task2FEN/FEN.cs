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
            
            string positions = data[0];
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
                    case 'K': fillBoard(Piece.whiteKing);   break;

                    case 'Q': fillBoard(Piece.whiteQueens); break;

                    case 'R': fillBoard(Piece.whiteRooks);  break;

                    case 'B': fillBoard(Piece.whiteBishops);break;

                    case 'N': fillBoard(Piece.whiteKnights);break;
                            
                    case 'P': fillBoard(Piece.whitePawns);  break;
 

                    case 'k': fillBoard(Piece.blackKing);   break;

                    case 'q': fillBoard(Piece.blackQueens); break;

                    case 'r': fillBoard(Piece.blackRooks);  break;

                    case 'b': fillBoard(Piece.blackBishops);break;

                    case 'n': fillBoard(Piece.blackKnights);break;

                    case 'p': fillBoard(Piece.blackPawns);  break;

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



            void fillBoard(Piece piece)
            {
                board[(int)piece] += currentPosition;
                currentPosition <<= 1;
            };
        }
    }
}
