using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib.Tests
{
    [TestClass()]
    public class BeerTests
    {
        private readonly Beer _beer = new Beer() { Id =1, Name = "Carlsberg Pilsner", ABV = 4.6 };
        private readonly Beer _nullName = new Beer() { Id = 2, ABV = 4.0 };
        private readonly Beer _shortName = new Beer() { Id = 3, Name = "Øl", ABV = 5 };
        private readonly Beer _ABVLow = new Beer() { Id = 4, Name = "Tuborg Classic", ABV = -4.5 };
        private readonly Beer _ABVHigh = new Beer() { Id = 5, Name = "Braunstein Classic", ABV = 70 };


        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Carlsberg Pilsner 4,6", _beer.ToString());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            _beer.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => _nullName.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => _shortName.ValidateName());
        }

        [TestMethod()]
        public void ValidateABVTest()
        {
            _beer.ValidateABV();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ABVLow.ValidateABV());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ABVHigh.ValidateABV());
        }

        [TestMethod]
        public void ValidateTest()
        {
            _beer.Validate();
        }
    }
}