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
    public class BeersRepositoryTests
    {
        
        public BeersRepository _repo = new BeersRepository();


        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(_repo.Get().Count(), 5);

        }

        [TestMethod()]
        public void AddBeerTest()
        {
            int firstCount = _repo.Get().Count();
            _repo.Add(new Beer { Name = "Svaneke Brown Ale", ABV = 5 });
            Assert.AreEqual(_repo.Get().Count(), firstCount + 1);
        }


        [TestMethod()]
        public void DeleteBeerTest()
        {
            int firstCount = _repo.Get().Count();
            _repo.Remove(1);
            Assert.AreEqual(_repo.Get().Count(), firstCount - 1);
        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            Beer beer = new Beer() { Id = 3, Name = "Thy Øko Humle", ABV = 5.8 };
            _repo.Update(3, beer);
            
            Assert.AreEqual(_repo.GetById(3).Name, beer.Name);
            Assert.AreEqual(_repo.GetById(3).ABV, beer.ABV);

        }
    }
}