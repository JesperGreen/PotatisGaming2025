using System;
using System.Collections.Generic;
using System.Dynamic;
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
        static int playerMaxMana;
        static int playerDamage;
        static int playerGold;

        static string[] enemyNames = { "Rat-Potato", "Goblin-Potato", "Skeleton-Potato", "Bandit-Potato", "Zombie-Potato", "Alien-Potato", "Necromancy-Potato"};
        static Random rnd = new Random();
        
        // Start-Meny och spel-loop
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
                playerMaxMana = 0;
            }
            else if (input == "2") 
            {
                playerClass = "Potatis-Mage";
                playerHP = playerMaxHP = 100;
                playerDamage = 25;
                playerMana = playerMaxMana = 200;
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
            bool alive = true;

            while (alive && playerHP > 0) 
            {
                Console.WriteLine("\n=== Meny ===");
                Console.WriteLine("1. Gå på äventyr");
                Console.WriteLine("2. Vila");
                Console.WriteLine("3. Status");
                Console.WriteLine("4. Avsluta");
                Console.Write("\nVälj ett alternativ: ");
                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        StartAdventure();
                        break;
                    case "2":
                        Rest();
                        break;
                    case "3":
                        ShowStatus();
                        break;
                    case "4":
                        alive = false;
                        break;
                    default:
                        Console.WriteLine("Wrong choice, noob.");
                        break;

                }
            }
        }
        // Metoder för att spela, vila och visa status
        static void ShowStatus() 
        {
            Console.WriteLine("\n--- Din status ---");
            Console.WriteLine($"Namn: {playerName}");
            Console.WriteLine($"Klass: {playerClass}");
            Console.WriteLine($"HP: {playerHP}/{playerMaxHP}");
            if (playerMaxMana > 0)
                Console.WriteLine($"Mana: {playerMana}/{playerMaxMana}");
            Console.WriteLine($"Skada: {playerDamage}");
            Console.WriteLine($"Guld: {playerGold}");
        }

        static void Rest() 
        {
            int heal = 25;
            playerHP += heal;
            
            if (playerHP > playerMaxHP) playerHP = playerMaxHP;
            if (playerMaxMana > 0)
            {
                int manaRegen = 25;
                playerMana += manaRegen;
                if (playerMana > playerMaxMana) playerMana = playerMaxMana;
                Console.WriteLine($"\nDu vilar och återhämtar {heal} HP och {manaRegen} mana.");
            }
            else 
            {
                Console.WriteLine($"\nDu vilar och regenererar {heal} HP.");
            }

            Console.WriteLine($"Ditt nuvarande HP är: {playerHP}/{playerMaxHP}");
            if (playerMaxMana > 0)
                Console.WriteLine($"Din nuvarande mana är: {playerMana}/{playerMaxMana}");
        }

        static void StartAdventure() 
        {
            string enemyName = enemyNames[rnd.Next(enemyNames.Length)];
            int enemyHP = rnd.Next(25, 80);
            int enemyDamage = rnd.Next(5, 15);
            int enemyGold = rnd.Next(1, 20);

            bool fighting = true;
            while (fighting && playerHP > 0 && enemyHP > 0) 
            {
                Console.WriteLine("\n Vad vill du göra?");
                Console.WriteLine("1. Attackera");
                Console.WriteLine("2. Vila");
                Console.WriteLine("3. Spring");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    if (playerClass == "Potatis-Mage")
                    {
                        int manaCost = 20;
                        if (playerMana >= manaCost)
                        {
                            playerMana -= manaCost;
                            enemyHP -= playerDamage;
                            Console.WriteLine($"\nDu kastar Potatobolt och använder {manaCost} mana. Fiendens HP är nu {enemyHP}.");
                        }
                        else
                        {
                            Console.WriteLine("\nDu har inte tillräckligt med mana för att attackera. Unlucky!");
                            continue;
                        }
                    }
                    else
                    {
                        enemyHP -= playerDamage;
                        Console.WriteLine($"\nDu kastar en fick-potatis på fienden. Fiendens HP är nu {enemyHP}.");
                    }
                    if (enemyHP > 0)
                    {
                        playerHP -= enemyDamage;
                        Console.WriteLine($"\n{enemyName} attackerar och gör {enemyDamage} skada. Ditt HP är nu {playerHP}/{playerMaxHP}.");
                    }
                }
                else if (action == "2")
                {
                    Rest();
                    if (enemyHP > 0) 
                    {
                        playerHP -= enemyDamage;
                        Console.WriteLine($"\n{enemyName} attackerar medan du vilar dig och gör {enemyDamage} skada. Ditt HP är nu {playerHP}/{playerMaxHP}.");
                    }
                }
                else if (action == "3")
                {
                    Console.WriteLine("\nDu springer iväg/utför en taktisk reträtt.");
                    fighting = false;
                }
                else 
                {
                    Console.WriteLine("\nFel val, försökte du välja ett annat alternativ?");
                }
            }
            if (enemyHP <= 0)
            {
                Console.WriteLine($"\nDu besegrade {enemyName}!");
                playerGold += enemyGold;
                Console.WriteLine($"Du lootar {enemyGold} guld. Totalt guld: {playerGold}");
            }
            else if (playerHP <= 0) 
            {
                Console.WriteLine($"\nNOOB DOWN. {playerName} the {playerClass} has died. Game over, better luck next time lol!");
            }
        }
    }
}
