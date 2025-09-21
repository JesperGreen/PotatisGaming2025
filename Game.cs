using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotatisGaming2025
{
    internal class Game
    {

        static string playerName;
        static string playerClass;
        static int playerHP;
        static int playerMaxHP;
        static int playerMana;
        static int playerDamage;
        static int playerGold;

        static string[] enemyNames = { "Potato-Rat", "Potato-Goblin", "Potato-Skeleton", "Potato-Bandit" };
        public static void StartGame()
        {
            Console.WriteLine("=== Potatis-Äventyr! ===");
            Console.Write("Vad heter du?: ");
            playerName = Console.ReadLine();

            Console.WriteLine("Välj din klass:");
            Console.WriteLine("1. Potatis-Warrior");
            Console.WriteLine("2. Potatis-Mage");
            Console.Write("Ditt val: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                playerClass = "Potatis-Warrior";
                playerHP = playerMaxHP = 150;
                playerDamage = 15;
                playerMana = 0;
            }
            else if (input == "2") 
            {
                playerClass = "Potatis-Mage";
                playerHP = playerMaxHP = 100;
                playerDamage = 20;
                playerMana = 100;
            }
            else
            {
                Console.WriteLine("Wrong choice, noob.");
            }

            playerGold = 0;
            Console.WriteLine($"\nVälkommen {playerName} the {playerClass}!");
        }

        public static void GameLoop()
        {

        }
    }
}
