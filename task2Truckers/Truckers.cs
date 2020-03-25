﻿using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2Truckers
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
    class Truckers : Task
    {
        public override string Run(string[] data)
        {
            /*
            int startPosition = 18;
            ulong whiteRooks = 1ul << startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;           
            ulong maskWhiteRooks = 0;
            
            //up
            ulong stepRooks = whiteRooks << 8;
            while (stepRooks != 0)
            {

                maskWhiteRooks |= stepRooks;
                stepRooks <<= 8;
            }

            //down
            stepRooks = whiteRooks >> 8;
            while(stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks >>= 8;
            }


            //left
            stepRooks = whiteRooks >> 1;
            while (stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks = (stepRooks & nL) >> 1;
            }
            //right
            stepRooks = whiteRooks << 1;
            while (stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks = (stepRooks & nR) << 1;
            } 
            */



            int startPosition = 18;
            ulong whiteRooks = 1ul << startPosition;
            ulong nL = 0xFEFEFEFEFEFEFEFE;
            ulong nR = 0x7F7F7F7F7F7F7F7F;
            ulong maskWhiteRooks = 0;
            
            //up-left
            ulong stepRooks = whiteRooks << 8;
            while (stepRooks != 0)
            {

                maskWhiteRooks |= stepRooks;
                stepRooks <<= 8;
            }
            /*
            //down
            stepRooks = whiteRooks >> 8;
            while (stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks >>= 8;
            }


            //left
            stepRooks = whiteRooks >> 1;
            while (stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks = (stepRooks & nL) >> 1;
            }
            //right
            stepRooks = whiteRooks << 1;
            while (stepRooks != 0)
            {
                maskWhiteRooks |= stepRooks;
                stepRooks = (stepRooks & nR) << 1;
            }*/
            int a = 0;
            /*
            int[] board = new int[64];
            int index = 63;
            //2 ^ (64 - 1) == 9223372036854775808
            ulong position = 9223372036854775808;

            string positions = "5k2/8/4Q3/8/5B2/2R5/8/3K4";//data[0];
            position >>= 7;

            index -= 7;
            ulong currentPosition = position;
            foreach (char item in positions)
            {
                if (item == '/')
                {
                    index -= 8;
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
                        fillBoard(Piece.whiteQueens);

                        break;

                    case 'R':
                        fillBoard(Piece.whiteRooks);

                        break;

                    case 'B':
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
                        index += (int)Char.GetNumericValue(item);
                        currentPosition = currentPosition << (int)Char.GetNumericValue(item);
                        break;

                }
            }
            
             */
            /*
            String result = "";

            for (int i = 0; i < board.Length; i++)
            {
                if (result != "")
                    result += "\r\n";
                result += board[i].ToString();
            }
            */
            return "";


            /*
            void fillBoard(Piece piece)
            {
                board[index] = (int)piece;
                currentPosition <<= 1;
            };
 */           
        }
    }
}
