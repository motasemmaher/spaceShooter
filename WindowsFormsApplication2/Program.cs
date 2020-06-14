using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    static class Program
    {

        public static List<Player> playerlist = new List<Player>();
        public static List<Game> gamelist = new List<Game>();
        public static menu m;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m = new menu();
            Application.Run(m);
        }
    }
}
