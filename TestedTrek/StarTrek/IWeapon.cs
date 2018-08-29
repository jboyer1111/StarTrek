using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTrek
{
    public interface IWeapon
    {
        void Fire();
        int CalculateDamage(int val1, int val2);
        //int DamageCaused(int seed);
    }

    
}
