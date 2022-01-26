using System;
using System.Collections.Generic;

namespace ClassesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //base stats
            int playerhealth = 100;
            int wisdom = 0;
            
            //number generator
            Random basedamage = new Random();

            //create a random creature for each encounter
            string firsttype = "frost";
            string secondtype = "blood";
            string thirdtype = "unholy";
            string[] monstertype = { firsttype, secondtype, thirdtype };
            int monsterhealth = 100; 
            Random typeofmonster = new Random();  
            int index = typeofmonster.Next(monstertype.Length);  

            void EnemyAttack()
            {
                int monsterbasedamage = basedamage.Next(1, 8);
                playerhealth = playerhealth - monsterbasedamage;
                Console.WriteLine("The monster hits you for " + monsterbasedamage + "damage. You have " + playerhealth + " left.");
            }
           
            //use {monstertype[index]} to call monster type             
            //object from a class: swords
            Sword longsword = new Sword(10, "Fire");
            
            void Attack()
            {
                if (monstertype[index] == firsttype)
                {
                    longsword.weapondamage += 10;
                    Console.WriteLine("the fiery sword fends off frost creatures quite well!");

                }
                else if (monstertype[index] == thirdtype)
                {
                    longsword.weapondamage -= 5;
                    Console.WriteLine("The beast is unholy and laughs at your puny flames!");
                }
             }
            void Parry()
            {
                int chancetoparry = basedamage.Next(1, 100);
                if (chancetoparry > 50)
                {
                    Console.WriteLine("You successfully block the attack!");
                }
                else
                {
                    Console.WriteLine("You fail to block the attack.");
                    EnemyAttack();                   
                }
            }
            //magical objects

            Staff magicalstaff = new Staff("Rotten Greatwood", 5);

            void Unstablestaff()
            {
                int index2 = typeofmonster.Next(monstertype.Length);
                Console.WriteLine("The unstable staff has become of the " + monstertype[index2] + " type");

                if (monstertype[index2] == firsttype)
                {
                    if (monstertype[index] == firsttype)
                    {
                        Console.WriteLine("The staff becomes of frost, unable to penetrate the defenses of this frost creature");
                    }
                    else if (monstertype[index] == secondtype)
                    {
                        Console.WriteLine("the creature freezes, shocked by the sudden freezing nature of your staff.");
                        Console.WriteLine("You successfully deal" + basedamage + "to the creature") ;
                        monsterhealth = monsterhealth - (magicalstaff.basedamage);
                        EnemyAttack();
                    }
                    else if (monstertype[index] == thirdtype)
                    {
                        Console.WriteLine("Although not effective, the frost damage seems to repeal the unholy creature for this turn");
                        monsterhealth = monsterhealth - (magicalstaff.basedamage - 2);
                        Console.WriteLine("The creature now has" + monsterhealth + " hp left");
                    }
                }
                else if (monstertype[index2] == secondtype)
                {
                    if (monstertype[index] == firsttype)
                    {
                        Console.WriteLine("Your blood staff is uneffective against the frozen beast!");
                        EnemyAttack();
                    }
                    else if (monstertype[index] == secondtype)
                    {
                        Console.WriteLine("blood vs blood, it doesn't work!");
                        EnemyAttack();
                    }
                    else if (monstertype[index] == thirdtype)
                    {
                        Console.WriteLine("The blood attack purges the monster from the inside!");
                        monsterhealth = monsterhealth - (magicalstaff.basedamage * 2);
                    }

                }
                else if (monstertype[index2] == thirdtype)
                {
                    if (monstertype[index] == firsttype)
                    {
                        Console.WriteLine("The unholy staff yields an immense power over the frozen creature!");
                        monsterhealth = monsterhealth - (magicalstaff.basedamage * 2);
                        Console.WriteLine("The monster now has" + monsterhealth + " hp left.");
                    }
                    else if (monstertype[index] == secondtype)
                    {
                        Console.WriteLine("The unholy staff hits the bloody creature, staggering it for a moment, but dealing no damage.");
                        EnemyAttack();
                    }
                    else if (monstertype[index] == thirdtype)
                    {
                        Console.WriteLine("The cursed beast cannot be cursed any further!");
                        EnemyAttack();
                    }
                }



            }


            //void Earthquake;
            void Earthquake()
            {
                Random random = new Random();
                int earthdamage = random.Next(1, 30);
                monsterhealth = (monsterhealth - earthdamage);
                playerhealth = playerhealth - (earthdamage/2);
                Console.WriteLine("You cause a massive earthquake.");
                Console.WriteLine("You deal the monster " + earthdamage + " damage");
                Console.WriteLine("The monster has" + monsterhealth + " hp left. You also caused yourself some damage, and you have " + playerhealth + " hp left.");
            }

            // void Fireball();
            void Fireball()
            {
                Console.WriteLine("You hurl a fireball at your enemy, dealing a flat 15 damage!");
                monsterhealth = monsterhealth - 15;
                Console.WriteLine("The monster now has " + monsterhealth + " left");
            }

            void Heal()
            {
                playerhealth += 5;
                Console.WriteLine("You healed successfully. Your health is now " + playerhealth + " hitpoints");
                

            }

            //spellbook: allows you to learn up to three new spells. This one will be a bitch to program.

            void GatherKnowledge()
            {
                wisdom++;
                if (wisdom >= 0 && wisdom < 3 )
                {
                    Console.WriteLine("You read from the Spellbook, improving your wisdom. Your wisdom is now " + wisdom);
                    EnemyAttack();
                }
                if (wisdom == 3 )
                {
                    Console.WriteLine("You gathered enough wisdom to learn your first spell: HEAL. Say HEAL to HEAL.");
                    string magicalchoice = Console.ReadLine();
                    if (magicalchoice == "HEAL")
                    {
                        Heal();
                    }
                }
                else if (wisdom == 4)
                {
                    Console.WriteLine("You learnt a new spell: FIREBALL. use HEAL or FIREBALL");
                    string magicalchoice = Console.ReadLine();
                    if (magicalchoice == "HEAL")
                    {
                        Heal();
                    }
                    else if (magicalchoice == "FIREBALL")
                    {
                        Fireball();
                    }
                }
                else if (wisdom == 5)
                {
                    Console.WriteLine("You learnt to use EARTHQUAKE. Choose your spell carefully, young sorcerer!");
                    string magicalchoice = Console.ReadLine();
                    if (magicalchoice == "HEAL")
                    {
                        Heal();
                    }
                    else if (magicalchoice == "FIREBALL")
                    {
                        Fireball();
                    }
                    else if (magicalchoice == "EARTHQUAKE")
                    {
                        Earthquake();
                    }
                }
                else if (wisdom > 5)
                {
                    Console.WriteLine("HEAL, FIREBALL or EARTHQUAKE");    
                    string magicalchoice = Console.ReadLine();
                    if (magicalchoice == "HEAL")
                    {
                        Heal();
                    }
                    else if (magicalchoice == "FIREBALL")
                    {
                        Fireball();
                    }
                    else if (magicalchoice == "EARTHQUAKE")
                    {
                        Earthquake();
                    }
                }
            }


            //introduction and gearing
            Console.WriteLine($"you encounter a { monstertype[index]} Monster! What will you do?");
            //combat
            while (playerhealth > 0 && monsterhealth > 0)
            {
                Console.WriteLine("Choose your weapon: SWORD, SPELLBOOK or STAFF");
                string weaponchoice = Console.ReadLine();

                if(weaponchoice == "SWORD")
                {
                    Console.WriteLine(longsword.description);
                    Console.WriteLine("You pick it up, ready to ATTACK or PARRY.");
                    string meleechoice = Console.ReadLine();

                    if (meleechoice == "ATTACK")
                    {
                        Attack();
                        monsterhealth -= longsword.weapondamage;
                        Console.WriteLine("A successful hit! The monster now has" + monsterhealth + " hp left");
                    }
                    else if (meleechoice == "PARRY")
                    {
                        Parry();
                    }
                }
                else if (weaponchoice == "SPELLBOOK")
                {
                    GatherKnowledge();
                }
                else if (weaponchoice == "STAFF")
                {
                    Console.WriteLine(magicalstaff.description);
                    Unstablestaff();
                }
                else
                {
                    Console.WriteLine("Ensure you are writing in ALL CAPS!"); // create a validation to turn weaponchoice in all caps
                }
            }

           if (monsterhealth <= 0)
            {
                Console.WriteLine("Well done, you killed the monster!");
            }

           else if (playerhealth <= 0)
            {
                Console.WriteLine("Better luck next time!");
            }
            
            
        }
    }
}
