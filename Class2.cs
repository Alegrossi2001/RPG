using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesExercise
{

    internal class Staff
    {
        public string description = "This magical staff changes its properties every time you pick it up";
        public string name;
        public int basedamage;

        public Staff(string name, int basedamage)
        {
            this.name = name;
            this.basedamage = basedamage;
        }
    }

}
