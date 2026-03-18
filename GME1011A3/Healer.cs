using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Healer : Hero
    {
        private int dexterity;

        //zero-argument constructor. : base( ) will call the superclass constructor
        //to set default values for health and name.
        public Healer() : base()
        {
            this.dexterity = 5;
        }

        public Healer(int health, string name, int dexterity) : base(health, name) 
        {
            if (this.health > 80)  //max the Healer at 80 health
            {
                this.health = 80;  //we can do this because Hero.health is protected
            }

            if (dexterity < 0 || dexterity > 10)  //if the argument came in less than 0 or more than 10
                dexterity = 5; 

            //Set the Healer's unique attribute
            this.dexterity = dexterity;

        }

        //Healers do their own damage, so let's override the Hero's version
        //There are lots of ways to do this.
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(3, 9);
        }

        //Like the constructor, we can set a Healer-specific health
        //thanks to the protected keyword in Hero
        public override void Heal(int health)
        {
            this.health += health;
            if (this.health > 80) this.health = 80;
        }

        //Specific method for the Healer
        public int GetDexterity() { return this.dexterity; }

        //Specific method for the Healer
        //Max out at 10, just because
        public void AddDexterity() { if(this.dexterity <= 9) dexterity++; }

        //Special move for the Healer:
        public int HealPartyMember()
        {
            if(dexterity > 0)
            {
                dexterity--;
                Random rng = new Random();
                return rng.Next(20, 35); //return this much damage in Main()
            }
            else
            {
                return 0; //no mana, no lightning
            }
        }

        //Override the ToString so that it works better for our Healer
        public override string ToString()
        {
            return "Healer[" + base.ToString() + ", dexterity: " + this.dexterity + "]";
        }

    }
}
