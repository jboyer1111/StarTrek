using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTrek
{
    class PhotonTorpedo : IWeapon
    {
        Klingon enemy;
        Galaxy wg;


        public int CalculateDamage(int magicNum, int randomSeed)
        {
            return magicNum + Game.Rnd(randomSeed);

        }


        public PhotonTorpedo(Klingon inEnemy, Galaxy inWg)
        {
            enemy = inEnemy;
            wg = inWg;
        }
        public void Fire()
        {
            //int damage = 800 + Rnd(50);
            int damage = CalculateDamage(800, 50);
            int distance = enemy.Distance();

            if ((Game.Rnd(4) + ((enemy.Distance() / 500) + 1) > 7))
            {
                wg.WriteLine("Torpedo missed Klingon at " + distance + " sectors...");
            }
            else
            {
                wg.WriteLine("Photons hit Klingon at " + distance + " sectors with " + damage + " units");
                if (damage < enemy.GetEnergy())
                {
                    enemy.SetEnergy(enemy.GetEnergy() - damage);
                    wg.WriteLine("Klingon has " + enemy.GetEnergy() + " remaining");
                }
                else
                {
                    wg.WriteLine("Klingon destroyed!");
                    enemy.Delete();
                }
            }
        }
    }
}
