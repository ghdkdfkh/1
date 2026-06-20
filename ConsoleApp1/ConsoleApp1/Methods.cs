using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Methods
    {
        int bossHealth = 300;
        int bossDamage = 10;
        int playerHealth = 150;
        int playerDamageBasic = 10;
        int playerDamageFireball = 20;
        int playerDamageExplosive = 50;
        int playerHeal = 11;
        int playerMagicEnergy = 50;
        int playerMagicEnergyRecover = 5;
        int playerFireballCost = 25;
        int playerExplosiveCharge = 0;

        internal void ShowInfo(int bossHealth, int bossDamage, int playerHealth, int playerMagicEnergy)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"У вас {playerHealth} здоровья\n{playerMagicEnergy} маны\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"У босса {bossHealth} здоровья\n{bossDamage} урона\n");
            Console.ResetColor();
            Console.WriteLine("Битва начинается\n");
        }

        internal void Fight(ref int bossHealth, int bossDamage, ref int playerHealth, int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, ref int playerMagicEnergy, int playerMagicEnergyRecover, int playerFireballCost, ref int playerExplosiveCharge)
        {
            
            while (bossHealth > 0 && playerHealth > 0)
            {
                ShowActions(playerDamageBasic, playerDamageFireball, playerDamageExplosive, playerHeal, playerFireballCost);

                ChooseAction(ref bossHealth, ref playerHealth, playerDamageBasic, playerDamageFireball, playerDamageExplosive, playerHeal, ref playerMagicEnergy, playerFireballCost, ref playerExplosiveCharge);

                playerHealth -= bossDamage;

                if (playerMagicEnergy < 50)
                    playerMagicEnergy += playerMagicEnergyRecover;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Вы получили {bossDamage} урона и у вас {playerHealth} здоровья\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Вы восстановили {playerMagicEnergyRecover} маны и ее у вас {playerMagicEnergy}\n");
                Console.ResetColor();

                WinConditions(bossHealth, playerHealth);

            }


        }

        private static void WinConditions(int bossHealth, int playerHealth)
        {
            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Ничья");
                Console.ResetColor();
            }
            else if (playerHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Игрок проиграл");
                Console.ResetColor();
            }
            else if (bossHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Игрок победил! Босс повержен");
                Console.ResetColor();
            }
        }

        private static void ShowActions(int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, int playerFireballCost)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Выберите действие");
            Console.WriteLine($"1 - Нанести обычный удар с уроном {playerDamageBasic}");
            Console.WriteLine($"2 - Нанести удар фаерболом с уроном {playerDamageFireball} и тратой маны {playerFireballCost}");
            Console.WriteLine($"3 - Нанести удар взрывом с уроном {playerDamageExplosive} и тратой заряда взрыва");
            Console.WriteLine($"4 - Восстановить здоровье {playerHeal}");
            Console.ResetColor();
        }

        private static void ChooseAction(ref int bossHealth, ref int playerHealth, int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    bossHealth = BasicAttack(bossHealth, playerDamageBasic);
                    break;

                case "2":
                    if (playerMagicEnergy < playerFireballCost)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Недостаточно маны\n");
                        Console.ResetColor();
                        break;
                    }
                    FireballAttack(ref bossHealth, playerDamageFireball, ref playerMagicEnergy, playerFireballCost, ref playerExplosiveCharge);
                    break;

                case "3":
                    if (playerExplosiveCharge <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Недостаточно зарядов");
                        Console.ResetColor();
                        break;
                    }
                    ExplosionAttack(ref bossHealth, playerDamageExplosive, ref playerExplosiveCharge);
                    break;

                case "4":
                    if (playerHealth >= 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Здоровье полное нельзя вылечиться\n");
                        Console.ResetColor();
                        break;
                    }
                    playerHealth = Heal(playerHealth, playerHeal);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введена неправильная команда пропуск хода\n");
                    Console.ResetColor();
                    break;

            }
        }

        private static int Heal(int playerHealth, int playerHeal)
        {
            playerHealth += playerHeal;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Вы восстановили здоровье, у вас  {playerHealth} здоровья \n");
            Console.ResetColor();
            return playerHealth;
        }

        private static void ExplosionAttack(ref int bossHealth, int playerDamageExplosive, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageExplosive;
            playerExplosiveCharge--;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.WriteLine($"И вы потратили заряд взрыва!\n  У вас {playerExplosiveCharge} зарядов \n");
            Console.ResetColor();
        }

        private static void FireballAttack(ref int bossHealth, int playerDamageFireball, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageFireball;
            playerMagicEnergy -= playerFireballCost;
            playerExplosiveCharge++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n" +
                $"У вас осталось маны {playerMagicEnergy}\n" +
                $"И вы получили заряд взрыва!\nУ вас {playerExplosiveCharge} зарядов\n ");
            Console.ResetColor();
        }

        private static int BasicAttack(int bossHealth, int playerDamageBasic)
        {
            bossHealth -= playerDamageBasic;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.ResetColor();
            return bossHealth;
        }
    }
}
