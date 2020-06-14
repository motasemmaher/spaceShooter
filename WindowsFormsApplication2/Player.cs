using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    public class Player
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string SpaceShooter { get; set; }
        public int Balance = 0;

        public override string ToString()
        {
            return Name;
        }
    }
}
