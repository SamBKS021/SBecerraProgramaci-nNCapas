using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.White;
            bool y = true;
            while (y)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("¿Qué opción desea ejecutar?\n\n1.INSERT\n2.UPDATE\n3.DELETE\n4.GETById\n5.GETAll\n6.CargarMasivaTxt\n\n7.EXIT");
                byte x = byte.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Usuario.Add();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Usuario.Update();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Usuario.Delete();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Usuario.GetById();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Usuario.GetAll();
                        break;
                    case 6:
                        Usuario.CargaMasivaTxt();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Opción no valida");
                        break;
                }
                Console.WriteLine("--¿Desea hacer otra operación?--\ny/n");
                y = Console.ReadLine() == "y";


                Console.Clear();
            }
            //Console.ReadKey();
        }
    }
}
