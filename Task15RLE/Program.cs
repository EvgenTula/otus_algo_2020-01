using System;
using System.Linq;

namespace Task15RLE
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHelp();
            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                //command = @"simple compress D:\dev\1.jpg D:\dev\1_s_c";
                //command = @"simple decompress D:\dev\1_s_c D:\dev\1_s_c.jpg";
                //command = @"improved compress D:\dev\1.jpg D:\dev\1_i_c";
                //command = @"improved decompress D:\dev\1_i_c D:\dev\1_i_c.jpg";
                string[] param = command.Split(" ");
                if (param.Count() != 4)
                {
                    Console.WriteLine("wrong command");
                    continue;
                }
                Archiver archiver = null;                
                if (param[0] == "simple")
                    archiver = new Archiver(new RLE());
                if (param[0] == "improved")
                    archiver = new Archiver(new ImprovedRLE());
                if (archiver == null)
                    param[1] = "абырвалг";
                switch (param[1])
                {
                    case "compress":
                        Console.WriteLine(archiver.Compress(param[2], param[3]));
                        break;
                    case "decompress":
                        Console.WriteLine(archiver.Decompress(param[2], param[3]));
                        break;
                    default:
                        Console.WriteLine("wrong command");
                        break;

                }
            }            
        }

        static void PrintHelp()
        {
            Console.WriteLine("Доступные команды:\t");
            Console.WriteLine("simple\\improved\t - алгоритм");
            Console.WriteLine("compress in_file out_file\t - сжатие");
            Console.WriteLine("decompress in_file out_file\t - распаковка");
            Console.WriteLine("exit\t\t\t\t - выход");
        }
    }
}
