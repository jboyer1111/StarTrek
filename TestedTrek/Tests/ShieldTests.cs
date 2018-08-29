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
            Assert.IsFalse(shield.IsUp());
        }

        [TestMethod]
        public void ShieldBuckles()
        {
            Assert.IsTrue(shield.IsBuckled());
        }
    }
}
