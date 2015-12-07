using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormationLibrary;

namespace FormationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthorTest()
        {
            Author a = new Author { Id = 2, Name = "toto" };
            Assert.AreEqual(2, a.Id);
        }

        [TestMethod]
        public void BookTest()
        {
            Book b = new Book { Id = 2, NbPage = 5, Publisher = new Publisher { Id = 1, Name = "Super Publisher" }, Price = 10 };
            Assert.AreEqual(5, b.NbPage);
            Assert.AreEqual("Super Publisher", b.Publisher.Name);
            Assert.AreEqual(10 * 1.05, b.VATPrice);
        }

        [TestMethod]
        public void AddAuthorTest()
        {
            Book b = new Book { Id = 2, NbPage = 5, Publisher = new Publisher { Id = 1, Name = "Super Publisher" }, Price = 10 };
            Author a = new Author { Id = 1, Name = "Jean Val Jean" };
            b.Authors.Add(a);
            Assert.AreEqual(1, b.Authors.Count);
        }

    }
}
