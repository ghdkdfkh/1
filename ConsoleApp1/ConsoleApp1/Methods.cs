using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Methods
    {
        private const string _basicAttack = "1";
        private const string _fireballAttack = "2";
        private const string _explosionAttack = "3";
        private const string _cure = "4";

        private ConsoleColor anythingBad = ConsoleColor.Red;
        private ConsoleColor anythingGood = ConsoleColor.Green;
        private ConsoleColor anythingMid = ConsoleColor.DarkYellow;

        internal void ShowInfo(int bossHealth, int bossDamage, int playerHealth, int playerMagicEnergy)
        {
            Console.ForegroundColor = anythingGood;
            Console.WriteLine($"У вас {playerHealth} здоровья\n{playerMagicEnergy} маны\n");
            Console.ResetColor();
            Console.ForegroundColor = anythingBad;
            Console.WriteLine($"У босса {bossHealth} здоровья\n{bossDamage} урона\n");
            Console.ResetColor();
            Console.ForegroundColor = anythingMid;
            Console.WriteLine("Битва начинается\n");
            Console.ResetColor();
        }

        internal void Fight(int bossHealth, int bossDamage, int playerHealth, int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, int playerMagicEnergy, int playerMagicEnergyRecover, int playerFireballCost, int playerExplosiveCharge)
        {

            while (bossHealth > 0 && playerHealth > 0)
            {
                ShowActions(playerDamageBasic, playerDamageFireball, playerDamageExplosive, playerHeal, playerFireballCost);

                ChooseAction(ref bossHealth, ref playerHealth, playerDamageBasic, playerDamageFireball, playerDamageExplosive, playerHeal, ref playerMagicEnergy, playerFireballCost, ref playerExplosiveCharge);

                playerHealth -= bossDamage;

                if (playerMagicEnergy < 50)
                {
                    playerMagicEnergy += playerMagicEnergyRecover;

                    Console.ForegroundColor = anythingGood;
                    Console.WriteLine($"Вы восстановили {playerMagicEnergyRecover} маны и ее у вас {playerMagicEnergy}\n");
                    Console.ResetColor();
                }

                Console.ForegroundColor = anythingBad;
                Console.WriteLine($"Вы получили {bossDamage} урона и у вас {playerHealth} здоровья\n");
                Console.ResetColor();

                WinConditions(bossHealth, playerHealth);
            }
        }

        private void WinConditions(int bossHealth, int playerHealth)
        {
            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.ForegroundColor = anythingMid;
                Console.WriteLine("Ничья");
                Console.ResetColor();
            }
            else if (playerHealth <= 0)
            {
                Console.ForegroundColor = anythingBad;
                Console.WriteLine("Игрок проиграл");
                Console.ResetColor();
            }
            else if (bossHealth <= 0)
            {
                Console.ForegroundColor = anythingGood;
                Console.WriteLine("Игрок победил! Босс повержен");
                Console.ResetColor();
            }
        }

        private void ShowActions(int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, int playerFireballCost)
        {
            Console.ForegroundColor = anythingMid;
            Console.WriteLine("Выберите действие");
            Console.WriteLine($"{_basicAttack} - Нанести обычный удар с уроном {playerDamageBasic}");
            Console.WriteLine($"{_fireballAttack} - Нанести удар фаерболом с уроном {playerDamageFireball} и тратой маны {playerFireballCost}");
            Console.WriteLine($"{_explosionAttack} - Нанести удар взрывом с уроном {playerDamageExplosive} и тратой заряда взрыва");
            Console.WriteLine($"{_cure} - Восстановить здоровье {playerHeal}");
            Console.ResetColor();
        }

        private void ChooseAction(ref int bossHealth, ref int playerHealth, int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            switch (Console.ReadLine())
            {
                case _basicAttack:
                    bossHealth = BasicAttack(bossHealth, playerDamageBasic);
                    break;

                case _fireballAttack:
                    if (playerMagicEnergy < playerFireballCost)
                    {
                        Console.ForegroundColor = anythingBad;
                        Console.WriteLine("Недостаточно маны\n");
                        Console.ResetColor();
                        break;
                    }
                    FireballAttack(ref bossHealth, playerDamageFireball, ref playerMagicEnergy, playerFireballCost, ref playerExplosiveCharge);
                    break;

                case _explosionAttack:
                    if (playerExplosiveCharge <= 0)
                    {
                        Console.ForegroundColor = anythingBad;
                        Console.WriteLine("Недостаточно зарядов");
                        Console.ResetColor();
                        break;
                    }
                    ExplosionAttack(ref bossHealth, playerDamageExplosive, ref playerExplosiveCharge);
                    break;

                case _cure:
                    if (playerHealth >= 150)
                    {
                        Console.ForegroundColor = anythingBad;
                        Console.WriteLine("Здоровье полное нельзя вылечиться\n");
                        Console.ResetColor();
                        break;
                    }
                    playerHealth = Heal(playerHealth, playerHeal);
                    break;

                default:
                    Console.ForegroundColor = anythingBad;
                    Console.WriteLine("Введена неправильная команда пропуск хода\n");
                    Console.ResetColor();
                    break;

            }
        }

        private int Heal(int playerHealth, int playerHeal)
        {
            playerHealth += playerHeal;
            Console.ForegroundColor = anythingGood;
            Console.WriteLine($"Вы восстановили здоровье, у вас  {playerHealth} здоровья \n");
            Console.ResetColor();

            return playerHealth;
        }

        private void ExplosionAttack(ref int bossHealth, int playerDamageExplosive, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageExplosive;
            playerExplosiveCharge--;
            Console.ForegroundColor = anythingMid;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.WriteLine($"И вы потратили заряд взрыва!\n  У вас {playerExplosiveCharge} зарядов \n");
            Console.ResetColor();
        }

        private void FireballAttack(ref int bossHealth, int playerDamageFireball, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageFireball;
            playerMagicEnergy -= playerFireballCost;
            playerExplosiveCharge++;
            Console.ForegroundColor = anythingMid;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n" +
                $"У вас осталось маны {playerMagicEnergy}\n" +
                $"И вы получили заряд взрыва!\nУ вас {playerExplosiveCharge} зарядов\n ");
            Console.ResetColor();
        }

        private int BasicAttack(int bossHealth, int playerDamageBasic)
        {
            bossHealth -= playerDamageBasic;
            Console.ForegroundColor = anythingGood;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.ResetColor();
            return bossHealth;
        }
    }
}
