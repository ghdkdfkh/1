using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanV2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#'},
                {'#','$','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#','#','#',' ','#'},
                {'#',' ','#',' ','#',' ','$','#',' ','#'},
                {'#',' ','#',' ','#',' ','#','#',' ','#'},
                {'#',' ','#','#','#',' ',' ','#',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ','#'},
                {'#',' ','#','#','#',' ','#','#',' ','#'},
                {'#',' ','#','$',' ',' ','#',' ',' ','#'},
                {'#',' ','#','#','#','#','#',' ','#','#'},
                {'#','$',' ',' ',' ',' ',' ',' ','$','#'},
                {'#','#','#','#','#','#','#','#','#','#'},
            };

            int userX = 4, userY = 3;
            char[] bag = new char[1];

            Console.SetCursorPosition(0, 0);

            while (true)
            {
                Bag(bag);
                Map(map);

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                ConsoleKeyInfo charkey = Console.ReadKey();
                Controls(map, ref userX, ref userY, charkey);
                if (map[userX, userY] == '$')
                {
                    map[userX, userY] = 'O';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = '$';
                    bag = tempBag;
                }
                Console.Clear();

            }
        }

        private static void Controls(char[,] map, ref int userX, ref int userY, ConsoleKeyInfo charkey)
        {
            switch (charkey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != '#')
                    {
                        userX++;
                    }
                    break;
            }
        }

        private static void Map(char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Bag(char[] bag)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("Сумка: ");
            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write(bag[i] + " ");
            }
        }
    }
}
