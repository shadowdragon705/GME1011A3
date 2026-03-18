using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Magician : Hero
    {
        private int mana;

        //zero-argument constructor. : base( ) will call the superclass constructor
        //to set default values for health and name.
        public Magician() : base()
        {
            this.mana = 5;
        }

        public Magician(int health, string name, int mana) : base(health, name)
        {
            if (this.health > 50)  //max the Magician at 50 health
            {
                this.health = 50;  //we can do this because Hero.health is protected
            }

            if (mana < 0 || mana > 10)  //if the argument came in less than 0 or more than 10
                mana = 5;

            //Set the Magician's unique attribute
            this.mana = mana;

        }

        //Magicians do their own damage, so let's override the Hero's version
        //There are lots of ways to do this.
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(1, 15);
        }

        //Like the constructor, we can set a Magician-specific health
        //thanks to the protected keyword in Hero
        public override void Heal(int health)
        {
            this.health += health;
            if (this.health > 50) this.health = 50;
        }

        //Specific method for the Magician
        public int GetMana() { return this.mana; }

        //Specific method for the Healer
        //Max out at 10, just because
        public void AddMana() { if (this.mana <= 9) mana++; }

        //Special move for the Magician:
        public int LightningStrike()
        {
            if (mana > 1)
            {
                mana -= 2;
                Random rng = new Random();
                return rng.Next(80, 100); //return this much health to apply to party member in Main()
            }
            else
            {
                return 0; //no dexterity, no healing
            }
        }

        //Override the ToString so that it works better for our Healer
        public override string ToString()
        {
            return "Magician[" + base.ToString() + ", mana: " + this.mana + "]";
        }
    }
}
