using StarTrek;
using System;
using System.Collections.Generic;
using Untouchables;

public class Game {

	private int _energyRemaining = 10000;
	private int _torpedoStrength = 8;

    public int Torpedoes
    {
        set
        {
            _torpedoStrength = value;
        }
        get
        {
            return _torpedoStrength;
        }
    }


    public int EnergyRemaining() {
        return _energyRemaining;
    }

    public int CalculatePhotonDamage(int magicNum, int randomSeed)
    {
        return magicNum + Rnd(randomSeed);

    }
    public void FirePhoton( Galaxy wg)
    {
        Klingon enemy = (Klingon)wg.Variable("target");
        if (_torpedoStrength > 0)
        {
            int distance = enemy.Distance();
            if ((Rnd(4) + ((distance / 500) + 1) > 7))
            {
                wg.WriteLine("Torpedo missed Klingon at " + distance + " sectors...");
            }
            else
            {
                //int damage = 800 + Rnd(50);
                int damage = CalculatePhotonDamage( 800, 50);

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
            _torpedoStrength -= 1;

        }
        else
        {
            wg.WriteLine("No more photon torpedoes!");
        }

    }

    

    public void FirePhaser( Galaxy wg)
    {
        int amount = int.Parse(wg.Parameter("amount"));
        Klingon enemy = (Klingon)wg.Variable("target");
        if (_energyRemaining >= amount)
        {
            int distance = enemy.Distance();
            if (distance > 4000)
            {
                wg.WriteLine("Klingon out of range of phasers at " + distance + " sectors...");
            }
            else
            {
                int damage = amount - (((amount / 20) * distance / 200) + Rnd(200));
                if (damage < 1)
                    damage = 1;
                wg.WriteLine("Phasers hit Klingon at " + distance + " sectors with " + damage + " units");
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
            _energyRemaining -= amount;

        }
        else
        {
            wg.WriteLine("Insufficient energy to fire phasers!");
        }

    }


    public void FireWeapon(WebGadget wg) {
        FireWeapon(new Galaxy(wg));
    }

    public void FireWeapon(Galaxy wg) {

        IWeapon myWeapon = null;

        if (wg.Parameter("command").Equals("phaser")) {
            /*
            myWeapon = new Phaser( wg, e );
            myWeapon.Fire();
            */
         
            FirePhaser(wg);

        } else if (wg.Parameter("command").Equals("photon")) {

            //FirePhoton(wg);
            Klingon enemy = (Klingon)wg.Variable("target");
            if (_torpedoStrength > 0)
            {
  
                myWeapon = new PhotonTorpedo(enemy, wg);
                myWeapon.Fire();
               
                _torpedoStrength -= 1;

            }
            else
            {
                wg.WriteLine("No more photon torpedoes!");
            }




        }
    }


    // note we made generator public in order to mock it
    // it's ugly, but it's telling us something about our *design!* ;-)
	public static Random generator = new Random();
	public static int Rnd(int maximum) {
		return generator.Next(maximum);
	}


}
