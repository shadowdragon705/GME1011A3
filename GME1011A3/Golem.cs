using GME1011A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroInheritance
{
    internal class Golem : Minion
    {
        //golem food count
        private int _stones;

        //contructor
        public Golem(int health, int armour, int stones) : base(health, armour)
        {
            if (stones < 0 || stones > 10)
                stones = 5;
            _stones = stones;
        }

        //golem heal methode
        public int RockMunch()
        {
            if (_stones > 0)
            {
                Console.WriteLine("**OM NOM NOM**");
                _stones--;
                _health += 5;
                return _stones;
            }

            //no stone = not happy
            else if (_stones <= 0)
            {
                Console.WriteLine("Sad Golem, Have no Stones");
                return _stones;
            }

            else
            {
                Console.WriteLine("Golem Got confused");
                return _stones;
            }
            
        }

        public override string ToString()
        {
            return "Golem[" + base.ToString() + ", " + _stones + "]";
        }

    }
}
