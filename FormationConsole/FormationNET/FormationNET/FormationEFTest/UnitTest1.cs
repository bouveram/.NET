using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormationEF;
using System.Collections.Generic;
using System.Linq;

namespace FormationEFTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EFTest()
        {
            FormationEntities entities = new FormationEntities();
            List<Book> l = entities.Books.ToList();
        }
    }
}
