using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrek;

namespace MSTests
{
    [TestClass]
    public class ShieldTests
    {
        [TestMethod]
        public void ShieldIsDown()
        {
            Shield shield = new Shield();
            Assert.IsFalse(shield.IsUp());
        }
    }
}
