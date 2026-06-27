using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Methods
    {
        private const string _basicAttackCase = "1";
        private const string _fireballAttackCase = "2";
        private const string _explosionAttackCase = "3";
        private const string _cureCase = "4";

        private ConsoleColor _CC_Red = ConsoleColor.Red;
        private ConsoleColor _CC_Green = ConsoleColor.Green;
        private ConsoleColor _CC_DarkYellow = ConsoleColor.DarkYellow;

        internal void ShowInfo(int bossHealth, int bossDamage, int playerHealth, int playerMagicEnergy)
        {
            Console.ForegroundColor = _CC_Green;
            Console.WriteLine($"У вас {playerHealth} здоровья\n{playerMagicEnergy} маны\n");
            Console.ResetColor();

            Console.ForegroundColor = _CC_Red;
            Console.WriteLine($"У босса {bossHealth} здоровья\n{bossDamage} урона\n");
            Console.ResetColor();

            Console.ForegroundColor = _CC_DarkYellow;
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

                    Console.ForegroundColor = _CC_Green;
                    Console.WriteLine($"Вы восстановили {playerMagicEnergyRecover} маны и ее у вас {playerMagicEnergy}\n");
                    Console.ResetColor();
                }

                Console.ForegroundColor = _CC_Red;
                Console.WriteLine($"Вы получили {bossDamage} урона и у вас {playerHealth} здоровья\n");
                Console.ResetColor();

                WinConditions(bossHealth, playerHealth);
            }
        }

        private void WinConditions(int bossHealth, int playerHealth)
        {
            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.ForegroundColor = _CC_DarkYellow;
                Console.WriteLine("Ничья");
                Console.ResetColor();
            }

            else if (playerHealth <= 0)
            {
                Console.ForegroundColor = _CC_Red;
                Console.WriteLine("Игрок проиграл");
                Console.ResetColor();
            }

            else if (bossHealth <= 0)
            {
                Console.ForegroundColor = _CC_Green;
                Console.WriteLine("Игрок победил! Босс повержен");
                Console.ResetColor();
            }
        }

        private void ShowActions(int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, int playerFireballCost)
        {
            Console.ForegroundColor = _CC_DarkYellow;
            Console.WriteLine("Выберите действие");
            Console.WriteLine($"{_basicAttackCase} - Нанести обычный удар с уроном {playerDamageBasic}\n" +
                              $"{_fireballAttackCase} - Нанести удар фаерболом с уроном {playerDamageFireball} и тратой маны {playerFireballCost}\n" +
                              $"{_explosionAttackCase} - Нанести удар взрывом с уроном {playerDamageExplosive} и тратой заряда взрыва\n" +
                              $"{_cureCase} - Восстановить здоровье {playerHeal}");
            Console.ResetColor();
        }

        private void ChooseAction(ref int bossHealth, ref int playerHealth, int playerDamageBasic, int playerDamageFireball, int playerDamageExplosive, int playerHeal, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            switch (Console.ReadLine())
            {
                case _basicAttackCase:
                    bossHealth = BasicAttack(bossHealth, playerDamageBasic);
                    break;

                case _fireballAttackCase:
                    if (playerMagicEnergy < playerFireballCost)
                    {
                        Console.ForegroundColor = _CC_Red;
                        Console.WriteLine("Недостаточно маны\n");
                        Console.ResetColor();
                        break;
                    }

                    FireballAttack(ref bossHealth, playerDamageFireball, ref playerMagicEnergy, playerFireballCost, ref playerExplosiveCharge);
                    break;

                case _explosionAttackCase:
                    if (playerExplosiveCharge <= 0)
                    {
                        Console.ForegroundColor = _CC_Red;
                        Console.WriteLine("Недостаточно зарядов");
                        Console.ResetColor();
                        break;
                    }

                    ExplosionAttack(ref bossHealth, playerDamageExplosive, ref playerExplosiveCharge);
                    break;

                case _cureCase:
                    if (playerHealth >= 150)
                    {
                        Console.ForegroundColor = _CC_Red;
                        Console.WriteLine("Здоровье полное нельзя вылечиться\n");
                        Console.ResetColor();
                        break;
                    }

                    playerHealth = Heal(playerHealth, playerHeal);
                    break;

                default:
                    Console.ForegroundColor = _CC_Red;
                    Console.WriteLine("Введена неправильная команда пропуск хода\n");
                    Console.ResetColor();
                    break;

            }
        }

        private int Heal(int playerHealth, int playerHeal)
        {
            playerHealth += playerHeal;

            Console.ForegroundColor = _CC_Green;
            Console.WriteLine($"Вы восстановили здоровье, у вас  {playerHealth} здоровья \n");
            Console.ResetColor();

            return playerHealth;
        }

        private void ExplosionAttack(ref int bossHealth, int playerDamageExplosive, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageExplosive;
            playerExplosiveCharge--;

            Console.ForegroundColor = _CC_DarkYellow;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.WriteLine($"И вы потратили заряд взрыва!\n  У вас {playerExplosiveCharge} зарядов \n");
            Console.ResetColor();
        }

        private void FireballAttack(ref int bossHealth, int playerDamageFireball, ref int playerMagicEnergy, int playerFireballCost, ref int playerExplosiveCharge)
        {
            bossHealth -= playerDamageFireball;
            playerMagicEnergy -= playerFireballCost;
            playerExplosiveCharge++;

            Console.ForegroundColor = _CC_DarkYellow;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n" +
                $"У вас осталось маны {playerMagicEnergy}\n" +
                $"И вы получили заряд взрыва!\nУ вас {playerExplosiveCharge} зарядов\n ");
            Console.ResetColor();
        }

        private int BasicAttack(int bossHealth, int playerDamageBasic)
        {
            bossHealth -= playerDamageBasic;

            Console.ForegroundColor = _CC_Green;
            Console.WriteLine($"У босса осталось {bossHealth} здоровья\n");
            Console.ResetColor();

            return bossHealth;
        }
    }
}
