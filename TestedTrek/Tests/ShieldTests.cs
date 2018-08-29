using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrek;

namespace MSTests
{
    [TestClass]
    public class ShieldTests
    {
        Shield shield;

        [TestInitialize]
        public void Init()
        {
            shield = new Shield();
        }

        [TestMethod]
        public void ShieldIsDown()
        {
            Assert.IsFalse(shield.IsUp);
        }

        [TestMethod]
        public void ShieldBuckles()
        {
            Assert.IsTrue(shield.IsBuckled());
        }

        [TestMethod]
        public void CanRaiseShield()
        {
            //Initialize
            shield.RaiseShield(false);

            //Act
            shield.RaiseShield(true);

            //Assert
            Assert.IsTrue(shield.IsUp);
        }

        [TestMethod]
        public void CanLowerShield()
        {
            //Initiailize
            shield.RaiseShield(true);

            //Act
            shield.RaiseShield(false);

            //Assert
            Assert.IsFalse(shield.IsUp);
        }
    }
}
