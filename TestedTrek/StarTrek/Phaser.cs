using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTrek
{
    public class Phaser : IWeapon
    {
        private Galaxy _wg;
        int _e;

        private Phaser() { }
        public Phaser(Galaxy wg, int e=10000)
        {
            _wg = wg;
            _e = e;
        }
        public void Fire()
        {
 
        }

        public int CalculateDamage(int val1, int val2)
        {
            throw new NotImplementedException();
        }

        /*
        public int DamageCaused(int seed)
        {
            return (new Random()).Next(seed);
        }
        */



    }
}
