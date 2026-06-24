using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanV2
{
    class Program
    {
        static ConsoleColor player = ConsoleColor.DarkYellow;

        static void Main(string[] args)
        {
            #region переменные и другое

            Render render = new Render();
            Controls controls = new Controls();

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
            #endregion

            Launch(render, controls, map, userX, userY, bag);
        }

        private static void Launch(Render render, Controls controls, char[,] map, int userX, int userY, char[] bag)
        {
            while (true)
            {
                render.Draw(map, bag);

                Console.SetCursorPosition(userY, userX);

                Console.ForegroundColor = player;
                Console.Write('@');
                Console.ResetColor();

                ConsoleKeyInfo charkey = Console.ReadKey();
                controls.Walk(map, ref userX, ref userY, charkey);

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
    }
}
