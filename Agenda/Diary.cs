using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Borrar clases SPRITE Y GAME (no necesarias)
// https://www.google.es/search?ei=VWzQXLGoKbWJjLsP8L2LmAI&q=api+notification+windows+c%23+console+application&oq=api+notifications+windows+C%23+console+app&gs_l=psy-ab.1.0.33i22i29i30.11711.15367..17349...0.0..0.157.1326.2j10......0....1..gws-wiz.......33i21j33i160.rG9_C6sszY8
// https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotifier
// https://stackoverflow.com/questions/38062177/is-it-possible-to-send-toast-notification-from-console-application
// https://social.msdn.microsoft.com/Forums/vstudio/en-US/ac75bb7a-4fc5-4308-99c4-f9c19e3038f2/notify-icon-in-c-console-application?forum=csharpgeneral
// http://blog.plasticscm.com/2016/08/how-to-send-windows-toast-notifications.html
// https://www.google.es/search?q=tao+sdl+draw+square&oq=tao+sdl+draw+square&aqs=chrome..69i57.9055j0j7&sourceid=chrome&ie=UTF-8
// https://stackoverflow.com/questions/19730964/how-to-draw-a-square-with-sdl-2-0
// https://www.google.es/search?q=c%23+create+and+save+json+file&oq=C%23+create+and+save+j&aqs=chrome.2.69i57j69i58j0.13736j0j4&sourceid=chrome&ie=UTF-8
// https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
// https://www.newtonsoft.com/json

namespace Agenda
{
    class Diary
    {
        static void Main(string[] args)
        {
            bool fullScreen = false;
            SdlHardware.Init(1024, 768, 24, fullScreen);
            //Font font18 = new Font("data/Joystix.ttf", 18);

            Menu m = new Menu();

            do
            {
                m.Run();

                switch (m.GetOptionSelected())
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        Console.WriteLine("Good Bye");
                        break;
                }
            } while (m.GetOptionSelected() != 7);
        }
    }
}
