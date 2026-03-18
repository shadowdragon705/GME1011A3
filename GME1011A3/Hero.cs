using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Hero
    {
        //superclass (or base class) attributes
        protected int health;
        private string name;

        //zero-argument constructor
        public Hero()
        {
            health = 100;
            name = "unnamed hero";
        }

        //argumented constructor
        public Hero(int health, string name)
        {
            if (health < 0 || health > 100) { health = 100; }
            this.health = health;
            if(name == "") { name = "unnamed hero"; }
            this.name = name;
        }

        //simple accessors
        public int GetHealth() { return health; }
        public string GetName() { return name; }    

        //helper method (doesn't interact with attributes)
        public virtual int DealDamage() { return 10; }

        //mutators (Heal and TakeDamage affect health)
        public virtual void Heal(int health) 
        { 
            this.health += health; 
            if(this.health > 100) this.health = 100;
        }

        public void TakeDamage(int damage) 
        { 
            this.health -= damage;
            if(this.health < 0) { this.health = 0; }
        }

        //Is our hero dead? Check to see if health < 0 - this will be a true/false statement
        public bool isDead() { return health <= 0; }

        //Handy-dandy ToString for debugging
        public override String ToString()
        {
            return "Hero[" + health + ", " + name + "]";    
        }

    }
}
