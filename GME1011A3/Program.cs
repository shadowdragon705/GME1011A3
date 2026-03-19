using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Player input for Hero Variables plus console color change to yellow temporarily
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What is your hero's name?: ");
            string heroName = Console.ReadLine();
            Console.WriteLine("How much Health does your hero have? (0 - 100): ");
            string heroHealth = Console.ReadLine();
            Console.WriteLine("How much strength does your hero posses? (0 - 10): ");
            string heroStrength = Console.ReadLine();

            //Epic battle goes here :)
            Random rng = new Random();

            Fighter hero = new Fighter(int.Parse(heroHealth), heroName, int.Parse(heroStrength));
            Console.WriteLine("Here is our heroic hero: " + hero + "\n\n");
            //change back to white console
            Console.ForegroundColor = ConsoleColor.White;

            //Number of enemies input
            Console.WriteLine("How many foes will you hero face?: ");
            string numFoes = Console.ReadLine();
            int numBaddies = int.Parse(numFoes);
            int numAliveBaddies = numBaddies;


            //List modified to contain the super class "Minion" instead of just goblins
            List<Minion> baddies = new List<Minion>();



            for (int i = 0; i < numBaddies; i++)
            {
                //random chance number used to determine which of the 2 enemy types will spawn
                int enemyChance = rng.Next(0, 101);

                //the if arguments for said spawn selection
                if (enemyChance < 50)
                {
                    baddies.Add(new Goblin(rng.Next(30, 35), rng.Next(1, 5), rng.Next(1, 10)));
                }
                else if (enemyChance >= 50)
                {
                    //Skellies :)
                    baddies.Add(new Skellie(rng.Next(25, 31), 0));
                }


            }

            //this should work even after you make the changes above
            Console.WriteLine("Here are the baddies!!!");
            for(int i = 0; i < baddies.Count; i++)
            {
                Console.WriteLine(baddies[i]);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Let the EPIC battle begin!!!");
            Console.WriteLine("----------------------------");


            //loop runs as long as there are baddies still alive and the hero is still alive!!
            while (numAliveBaddies > 0 && !hero.isDead())
            {
                //figure out which enemy we are going to battle - the first one that isn't dead
                int indexOfEnemy = 0;
                while (baddies[indexOfEnemy].isDead())
                {
                    indexOfEnemy++;
                }

                //Checking if Hero has strength
                if (hero.GetStrength() > 0)
                {
                    //made an entire special atk chance system before realising Beserk() was a thing. Kept it in just to be safe.
                    int specialATKChance = rng.Next(0, 101);
                    int heroDamage = hero.DealDamage();

                    if (specialATKChance <= 33)
                    {
                        //pretty much regular atk but with Beserk values
                        hero.Berserk();
                        Console.WriteLine(hero.GetName() + " is attacking enemy #" + (indexOfEnemy + 1) + " of " + numBaddies + ". Eek, it's a " + baddies[indexOfEnemy].GetType().Name);
                        Console.WriteLine("Hero deals " + hero.Berserk() + " beserk damage.");
                        baddies[indexOfEnemy].TakeDamage(hero.Berserk());
                    }

                    else if (specialATKChance > 33)
                    {
                        Console.WriteLine(hero.GetName() + " is attacking enemy #" + (indexOfEnemy + 1) + " of " + numBaddies + ". Eek, it's a " + baddies[indexOfEnemy].GetType().Name);
                        Console.WriteLine("Hero deals " + heroDamage + " heroic damage.");
                        baddies[indexOfEnemy].TakeDamage(heroDamage);
                    }

                }
                else if (hero.GetStrength() <= 0)
                {
                    //hero deals damage first
                    Console.WriteLine(hero.GetName() + " is attacking enemy #" + (indexOfEnemy + 1) + " of " + numBaddies + ". Eek, it's a " + baddies[indexOfEnemy].GetType().Name);
                    int heroDamage = hero.DealDamage();  //how much damage?
                    Console.WriteLine("Hero deals " + heroDamage + " heroic damage.");
                    baddies[indexOfEnemy].TakeDamage(heroDamage); //baddie takes the damage
                }




                //TODO: The hero doesn't ever use their special attack - but they should. Change the above to 
                //have a 33% chance that the hero uses their special, and 67% that they use their regular attack.
                //If the hero doesn't have enough special power to use their special attack, they do their regular 
                //attack instead - but make a note of it in the output. There's no way for the hero to get more special
                //power points, but if you want to craft a way for that to happen, that's fine.




                //NOTE to coders - armour affects how much damage goblins take, and skellies take
                //half damage - remember that when reviewing the output

                //did we vanquish the baddie we were battling?
                if (baddies[indexOfEnemy].isDead())
                {
                    numAliveBaddies--; //one less baddie to worry about.
                    Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " has been dispatched to void.");
                }
                else //baddie survived, now attacks the hero
                {
                    int baddieDamage = baddies[indexOfEnemy].DealDamage();  //how much damage?
                    Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " deals " + baddieDamage + " damage!");
                    hero.TakeDamage(baddieDamage); //hero takes damage




                    //TODO: The baddie doesn't ever use their special attack - but they should. Change the above to 
                    //have a 33% chance that the baddie uses their special, and 67% that they use their regular attack.
                    



                    //let's look in on our hero.
                    Console.WriteLine(hero.GetName() + " has " + hero.GetHealth() + " health remaining.");
                    if (hero.isDead()) //did the hero die
                    {
                        Console.WriteLine(hero.GetName() + " has died. All hope is lost.");
                    }

                }
                Console.WriteLine("-----------------------------------------");
            }
            //if we made it this far, the hero is victorious! (that's what the message says.
            if(!hero.isDead())
                Console.WriteLine("\nAll enemies have been dispatched!! " + hero.GetName() + " is victorious!");
        }

    }
}