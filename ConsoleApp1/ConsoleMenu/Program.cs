using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    //    2.5) ДЗ: Консольное меню
    //        При помощи всего, что вы изучили, создать приложение, которое может обрабатывать команды.
    //        Т.е.вы создаете меню, ожидаете ввода нужной команды, после чего выполняете действие, которое присвоено этой команде.
    //       Программа не должна завершаться после ввода, пользователь сам должен выйти из программы при помощи команды.
    //Меню должно содержать следующие команды:
    //- пара команд на вывод разного текста
    //- команда показать случайное число
    //- команда очистить консоль
    //- команда выхода
    //Если решение строится на switch, то принято работать с константами (в остальных случаях объявляются переменные). 

    class Program
    {
        static void Main(string[] args)
        {
            Utils utils = new Utils();

            bool isWorking = true;
            const string ShowRandomNumCase = "1";
            const string ShowTextCase = "2";
            const string ClearConsoleCase = "3";
            const string ExitCase = "0";

            isWorking = utils.ProgramExecute(isWorking, ShowRandomNumCase, ShowTextCase, ClearConsoleCase, ExitCase);
        }
    }
}
