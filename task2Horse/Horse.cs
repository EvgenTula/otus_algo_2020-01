using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2Horse
{
    class Horse : Task
    {

        public override string Run(string[] data)
        {
            string result;
            int x = int.Parse(data[0]);
            ulong k = 1ul << x;

            ulong nA = 0xFEFEFEFEFEFEFEFE;
            ulong nAB = 0xFCFCFCFCFCFCFCFC;

            ulong nH = 0x7F7F7F7F7F7F7F7F;
            ulong nHG = 0x3F3F3F3F3F3F3F3F;

            ulong mask =
                        ((k & nA) << 15) | ((k & nH) >> 15) |

                        ((k & nH) << 17) | ((k & nA) >> 17) |

                        ((k & nAB) << 6) | ((k & nHG) >> 6) |

                        ((k & nHG) << 10) | ((k & nAB) >> 10);
            result = mask.ToString();
            long cnt = 0;
            while (mask > 0)
            {
                cnt++;
                mask &= mask - 1;
            }

            return cnt + "\r\n" + result;
        }        
    }
}
