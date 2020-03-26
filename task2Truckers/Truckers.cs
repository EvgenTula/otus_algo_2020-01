using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2Truckers
{
    enum Piece : int
    {
        whitePawns = 1,
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
    class Truckers : Task
    {
        public override string Run(string[] data)
        {        
            int[] board = new int[64];
            int index = board.Length - 1;
            int currentIndex = index;
            //2 ^ (64 - 1) == 9223372036854775808
            ulong position = 9223372036854775808;
            
            int positionWhiteRooks = -1;
            int positionWhiteBishops = -1;
            int positionWhiteQueens = -1;

            string positions = "5k2/8/4Q3/8/5B2/2R5/8/3K4";//data[0];
            position >>= 7;

            index -= 7;
            currentIndex = index;
            ulong currentPosition = position;
            foreach (char item in positions)
            {
                if (item == '/')
                {
                    index -= 8;
                    currentIndex = index;
                    position >>= 8;
                    currentPosition = position;
                    continue;
                }


                switch (item)
                {
                    case 'K':
                        fillBoard(Piece.whiteKing); 
                        break;

                    case 'Q':
                        positionWhiteQueens = index;
                        fillBoard(Piece.whiteQueens);
                        
                        break;

                    case 'R':
                        positionWhiteRooks = index;
                        fillBoard(Piece.whiteRooks);

                        break;

                    case 'B':
                        positionWhiteBishops = index;
                        fillBoard(Piece.whiteBishops);

                        break;

                    case 'N': fillBoard(Piece.whiteKnights); break;

                    case 'P': fillBoard(Piece.whitePawns); break;


                    case 'k': fillBoard(Piece.blackKing); break;

                    case 'q': fillBoard(Piece.blackQueens); break;

                    case 'r': fillBoard(Piece.blackRooks); break;

                    case 'b': fillBoard(Piece.blackBishops); break;

                    case 'n': fillBoard(Piece.blackKnights); break;

                    case 'p': fillBoard(Piece.blackPawns); break;

                    default:
                        currentIndex += (int)Char.GetNumericValue(item);
                        currentPosition = currentPosition << (int)Char.GetNumericValue(item);
                        break;

                }
            }

            ulong result = WhiteRooksMask(positionWhiteRooks, board);
            return result.ToString();//WhiteRooksMask(positionWhiteRooks, board) + "\r\n" + WhiteBishopsMask(positionWhiteBishops, board) + "\r\n" + WhileQueensMask(positionWhiteQueens, board);

            void fillBoard(Piece piece)
            {
                board[currentIndex++] = (int)piece;
                currentPosition <<= 1;
            };            
        }
        
        private ulong WhiteRooksMask(int startPosition, int[] board)
        {
            ulong whiteRooks = 1ul << startPosition;
            int currentPosition = startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteRooks = 0;

            //up
            currentPosition = startPosition + 8;
            ulong stepRooks = whiteRooks << 8;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];

                if (figureOnBoard < 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition += 8;
                stepRooks <<= 8;
                
                if (figureOnBoard > 6)
                {                
                    break;
                }                
            }

            //down
            currentPosition = startPosition - 8;
            stepRooks = whiteRooks >> 8;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard < 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition -= 8;
                stepRooks >>= 8;

                if (figureOnBoard > 6)
                {
                    break;
                }        
            }


            //left
            currentPosition = startPosition - 1;
            stepRooks = (whiteRooks & nL) >> 1;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard < 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition -= 1;
                stepRooks = (stepRooks & nL) >> 1;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }
            //right
            currentPosition = startPosition + 1;
            stepRooks = (whiteRooks & nR) << 1;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard < 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition += 1;
                stepRooks = (stepRooks & nR) << 1;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            return maskWhiteRooks;
        }

        private ulong WhiteBishopsMask(int startPosition, int[] board)
        {
            int startStep = 0;
            ulong whiteBishops = 1ul << startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteBishops = 0;

            //up-left            
            startStep = 7;
            ulong stepBishops = (whiteBishops & nL) << startStep;
            while (stepBishops != 0)
            {

                maskWhiteBishops |= stepBishops;
                stepBishops = (stepBishops & nL) << startStep;
            }

            //up-right
            startStep = 9;
            stepBishops = (whiteBishops & nR) << startStep;
            while (stepBishops != 0)
            {
                maskWhiteBishops |= stepBishops;
                stepBishops = (stepBishops & nR) << startStep;
            }


            //down-left
            startStep = 9;
            stepBishops = (whiteBishops & nL) >> startStep;
            while (stepBishops != 0)
            {
                maskWhiteBishops |= stepBishops;
                stepBishops = (stepBishops & nL) >> startStep;
            }


            //down-right
            startStep = 7;
            stepBishops = (whiteBishops & nR) >> startStep;
            while (stepBishops != 0)
            {
                maskWhiteBishops |= stepBishops;
                stepBishops = (stepBishops & nR) >> startStep;
            }

            return maskWhiteBishops;
        }

        private ulong WhileQueensMask(int startPosition, int[] board)
        {
            int startStep = 0;
            ulong whiteQueens = 1ul << startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteQueens = 0;
            ulong stepQueens = 0;

            //left
            stepQueens = (whiteQueens & nL) >> 1;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nL) >> 1;
            }

            //up-left            
            startStep = 7;
            stepQueens = (whiteQueens & nL) << startStep;
            while (stepQueens != 0)
            {

                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nL) << startStep;
            }

            //up
            stepQueens = whiteQueens << 8;
            while (stepQueens != 0)
            {

                maskWhiteQueens |= stepQueens;
                stepQueens <<= 8;
            }

            //up-right
            startStep = 9;
            stepQueens = (whiteQueens & nR) << startStep;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nR) << startStep;
            }

            //right
            stepQueens = (whiteQueens & nR) << 1;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nR) << 1;
            }

            //down-right
            startStep = 7;
            stepQueens = (whiteQueens & nR) >> startStep;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nR) >> startStep;
            }

            //down
            stepQueens = whiteQueens >> 8;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens >>= 8;
            }

            //down-left
            startStep = 9;
            stepQueens = (whiteQueens & nL) >> startStep;
            while (stepQueens != 0)
            {
                maskWhiteQueens |= stepQueens;
                stepQueens = (stepQueens & nL) >> startStep;
            }
            return maskWhiteQueens;
        }
    }
}
