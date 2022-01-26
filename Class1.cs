using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesExercise
{
    internal class Sword
    {
        //basic fields

        public int weapondamage;
        string elementaltype;
        public string description = "A basic sword. Great for stabbing things.";

        // constructor - prerequesite for an object, good for data validation
        public Sword(int weapondamage, string elementaltype)
        {
            this.weapondamage = weapondamage;
            this.elementaltype = elementaltype;
        }

        //method

        public void Harden()
        {
            weapondamage+=5;
        }
        
    }
}
