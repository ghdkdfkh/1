using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();

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

            methods.ShowInfo(bossHealth, bossDamage, playerHealth, playerMagicEnergy);
            methods.Fight( bossHealth, bossDamage,  playerHealth, playerDamageBasic, playerDamageFireball, playerDamageExplosive,
                           playerHeal,  playerMagicEnergy, playerMagicEnergyRecover, playerFireballCost,  playerExplosiveCharge);
        }
    }
}

