using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportFinderApi.Models;

namespace SportFinderTest.DomainModelTest
{
    [TestClass]
    public class DomainLogicTest
    {
        [TestMethod]
        public void User_Calculate_Rating()
        {
            User user = new User();

            //dodaj test rating objekt
            user.Ratings = new List<Rating>();
            user.Ratings.Add(new Rating() { Id = 1, Value = 4.5M });

            //dodaj novi rating korisniku
            user.AddRating(5M, 1);
            Assert.AreEqual(4.75M, user.Ratings.Where(x => x.Id == 1).SingleOrDefault().Value);
        }
    }
}
