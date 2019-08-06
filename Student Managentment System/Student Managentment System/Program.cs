using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
    class Program
    {
        static void Main(string[] args)
        {

            if (XmlHelper.Init())
            {
                UI ui = new UI();
                ui.mainMenu();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("文件加载失败");
                Console.ReadKey();
            }

        }
    }
}
