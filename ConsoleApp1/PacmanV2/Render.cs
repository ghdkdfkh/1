using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanV2
{
    class Render
    {
        private ConsoleColor wall = ConsoleColor.Blue;
        private ConsoleColor bagCC = ConsoleColor.DarkGreen;

        private void Map(char[,] map)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.ForegroundColor = wall;
                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private void Bag(char[] bag)
        {
            Console.SetCursorPosition(0, 20);

            Console.ForegroundColor = bagCC;
            Console.Write("Сумка: ");
            Console.ResetColor();

            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write(bag[i] + " ");
            }
        }

        internal void Draw(char[,] map, char[] bag)
        {
            Map(map);
            Bag(bag);
        }
    }
}
