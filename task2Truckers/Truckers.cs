using SimpleTester;
using System;

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

            string positions = data[0];
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
                        board[currentIndex++] = (int)Piece.whiteKing;
                        currentPosition <<= 1;
                        break;

                    case 'Q':
                        positionWhiteQueens = currentIndex;
                        board[currentIndex++] = (int)Piece.whiteQueens;
                        currentPosition <<= 1;
                        break;

                    case 'R':
                        positionWhiteRooks = currentIndex;
                        board[currentIndex++] = (int)Piece.whiteRooks;
                        currentPosition <<= 1;
                        break;

                    case 'B':
                        positionWhiteBishops = currentIndex;
                        board[currentIndex++] = (int)Piece.whiteBishops;
                        currentPosition <<= 1;
                        break;

                    case 'N': 
                        board[currentIndex++] = (int)Piece.whiteKnights;
                        currentPosition <<= 1;
                        break;

                    case 'P': 
                        board[currentIndex++] = (int)Piece.whitePawns;
                        currentPosition <<= 1;
                        break;


                    case 'k': 
                        board[currentIndex++] = (int)Piece.blackKing;
                        currentPosition <<= 1;
                        break;

                    case 'q': 
                        board[currentIndex++] = (int)Piece.blackQueens;
                        currentPosition <<= 1;
                        break;

                    case 'r': 
                        board[currentIndex++] = (int)Piece.blackRooks;
                        currentPosition <<= 1;
                        break;

                    case 'b': 
                        board[currentIndex++] = (int)Piece.blackBishops;
                        currentPosition <<= 1;
                        break;

                    case 'n': 
                        board[currentIndex++] = (int)Piece.blackKnights;
                        currentPosition <<= 1;
                        break;

                    case 'p': 
                        board[currentIndex++] = (int)Piece.blackPawns;
                        currentPosition <<= 1;
                        break;

                    default:
                        currentIndex += (int)Char.GetNumericValue(item);
                        currentPosition = currentPosition << (int)Char.GetNumericValue(item);
                        break;

                }
            }
            
            return WhiteRooksMask(positionWhiteRooks, board) + "\r\n" + WhiteBishopsMask(positionWhiteBishops, board) + "\r\n" + WhileQueensMask(positionWhiteQueens, board);           
        }
        
        private ulong WhiteRooksMask(int startPosition, int[] board)
        {
            int startStep = 0;
            ulong whiteRooks = 1ul << startPosition;            
            int currentPosition = startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteRooks = 0;

            //up
            startStep = 8;
            currentPosition = startPosition + startStep;
            ulong stepRooks = whiteRooks << startStep;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];

                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition += startStep;
                stepRooks <<= startStep;
                
                if (figureOnBoard > 6)
                {                
                    break;
                }                
            }

            //down
            startStep = 8;
            currentPosition = startPosition - startStep;
            stepRooks = whiteRooks >> startStep;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition -= startStep;
                stepRooks >>= startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }        
            }


            //left
            startStep = 1;
            currentPosition = startPosition - startStep;
            stepRooks = (whiteRooks & nL) >> startStep;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition -= startStep;
                stepRooks = (stepRooks & nL) >> startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }
            //right
            startStep = 1;
            currentPosition = startPosition + startStep;
            stepRooks = (whiteRooks & nR) << startStep;
            while (stepRooks != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteRooks |= stepRooks;
                currentPosition += startStep;
                stepRooks = (stepRooks & nR) << startStep;

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
            int currentPosition = startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteBishops = 0;

            //up-left            
            startStep = 7;
            currentPosition = startPosition + startStep;
            ulong stepBishops = (whiteBishops & nL) << startStep;
            while (stepBishops != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteBishops |= stepBishops;
                currentPosition += startStep;
                stepBishops = (stepBishops & nL) << startStep;              

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            //up-right
            startStep = 9;
            currentPosition = startPosition + startStep;
            stepBishops = (whiteBishops & nR) << startStep;
            while (stepBishops != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteBishops |= stepBishops;
                currentPosition += startStep;
                stepBishops = (stepBishops & nR) << startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }


            //down-left
            startStep = 9;
            currentPosition = startPosition - startStep;
            stepBishops = (whiteBishops & nL) >> startStep;
            while (stepBishops != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteBishops |= stepBishops;
                currentPosition -= startStep;
                stepBishops = (stepBishops & nL) >> startStep;                

                if (figureOnBoard > 6)
                {
                    break;
                }
            }


            //down-right
            startStep = 7;
            currentPosition = startPosition - startStep;
            stepBishops = (whiteBishops & nR) >> startStep;
            while (stepBishops != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteBishops |= stepBishops;
                currentPosition -= startStep;
                stepBishops = (stepBishops & nR) >> startStep;               

                if (figureOnBoard > 6)
                {
                    break;
                }

            }

            return maskWhiteBishops;
        }

        private ulong WhileQueensMask(int startPosition, int[] board)
        {
            int startStep = 0;
            ulong whiteQueens = 1ul << startPosition;
            int currentPosition = startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteQueens = 0;
            ulong stepQueens = 0;

            //left
            startStep = 1;
            currentPosition = startPosition - startStep;
            stepQueens = (whiteQueens & nL) >> startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition -= startStep;
                stepQueens = (stepQueens & nL) >> startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            //up-left            
            startStep = 7;
            currentPosition = startPosition + startStep;
            stepQueens = (whiteQueens & nL) << startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition += startStep;
                stepQueens = (stepQueens & nL) << startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }                
            }

            //up
            startStep = 8;
            currentPosition = startPosition + startStep;
            stepQueens = whiteQueens << startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition += startStep;
                stepQueens <<= startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            //up-right
            startStep = 9;
            currentPosition = startPosition + startStep;
            stepQueens = (whiteQueens & nR) << startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition += startStep;
                stepQueens = (stepQueens & nR) << startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            //right
            startStep = 1;
            currentPosition = startPosition + startStep;
            stepQueens = (whiteQueens & nR) << startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition += startStep;
                stepQueens = (stepQueens & nR) << startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }                
            }

            //down-right
            startStep = 7;
            currentPosition = startPosition - startStep;
            stepQueens = (whiteQueens & nR) >> startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition -= startStep;
                stepQueens = (stepQueens & nR) >> startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }
            }

            //down
            startStep = 8;
            currentPosition = startPosition - startStep;
            stepQueens = whiteQueens >> startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition -= startStep;
                stepQueens >>= startStep;

                if (figureOnBoard > 6)
                {
                    break;
                }                
            }

            //down-left
            startStep = 9;
            currentPosition = startPosition - startStep;
            stepQueens = (whiteQueens & nL) >> startStep;
            while (stepQueens != 0)
            {
                int figureOnBoard = board[currentPosition];
                if (figureOnBoard != 0 && figureOnBoard <= 6)
                {
                    break;
                }

                maskWhiteQueens |= stepQueens;
                currentPosition -= startStep;
                stepQueens = (stepQueens & nL) >> startStep;
                if (figureOnBoard > 6)
                {
                    break;
                }
            }
            return maskWhiteQueens;
        }
    }
}
