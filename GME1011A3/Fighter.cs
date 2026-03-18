using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Fighter : Hero
    {
        private int strength;

        //zero-argument constructor. : base( ) will call the superclass constructor
        //to set default values for health and name.
        public Fighter() : base()
        {
            this.strength = 5;
        }

        public Fighter(int health, string name, int strength) : base(health, name)
        {
            if (strength < 0 || strength > 10)  //if the argument came in less than 0 or more than 10
                strength = 5;

            //Set the Fighter's unique attribute
            this.strength = strength;

        }

        //Fighters do their own damage, so let's override the Hero's version
        //There are lots of ways to do this.
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(8, 15);
        }

        //Unlike the Healer, the Fighter has the same Heal method as a default hero. 
        //So, we don't override it

        //Specific method for the Figher
        public int GetStrength() { return this.strength; }

        //Specific method for the Figher
        //Max out at 10, just because
        public void AddStrength() { if (this.strength <= 9) strength++; }

        //Special move for the Fighter:
        public int Berserk()
        {
            if (strength > 0)
            {
                strength--;
                Random rng = new Random();
                return rng.Next(10, 20) * strength; //return this damage to deal to an enemy in Main()
            }
            else
            {
                return 0; //no strength, no berserk
            }
        }

        //Override the ToString so that it works better for our Fighter
        public override string ToString()
        {
            return "Fighter[" + base.ToString() + ", strength: " + this.strength + "]";
        }
    }
}
