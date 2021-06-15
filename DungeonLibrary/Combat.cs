using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will not have fields, properties, or ctors as it is just a 'warehouse' for different methods.

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //if the attacker hit, calc damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!\n", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed!\n", attacker.Name);
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //player attack first
            DoAttack(player, monster);

            //If monster is still allive it attacks
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
