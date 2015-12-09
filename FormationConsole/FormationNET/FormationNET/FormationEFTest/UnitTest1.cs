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
            Book b = new Book { Title = "EF en .NET", Price = 10.0m }; //m pour decimal
            entities.Books.Add(b); //add a book
            entities.SaveChanges();
            b = entities.Books.First();
            b.Price += 1;
            entities.SaveChanges(); //update a book
            b = entities.Books.Find(1); //GetByPrimaryKey

            //LINQ
            IEnumerable<Book> ie = from book in entities.Books
                                   where book.Price < 15
                                   orderby book.Id
                                   select book;

            IEnumerable<Book> ie2 = from book in entities.Books
                                   where book.Title.ToUpper().Contains(".NET")
                                   orderby book.Id
                                   select book;

            IEnumerable<Book> ie3 = ie2.Intersect(ie);

            IEnumerable<decimal?> ie4 = from book in entities.Books             // Retourne une collection de livres
                                    where book.Title.ToUpper().Contains(".NET")
                                    orderby book.Id
                                    select book.Price;

            //Mieux que LINQ, lambda expressions :
            //f(x) = x+1 <=> x => x+1
            ie = entities.Books.Where(book => book.Price < 15).OrderBy(book => book.Id);
            ie2 = entities.Books.Where(book => book.Title.ToUpper().Contains(".NET")).OrderBy(book => book.Id);

            Func<Book, bool> f = book => book.Title.ToUpper().Contains(".NET");
            ie2 = entities.Books.Where(f).OrderBy(book => book.Id);
            //entities.Set<Book> <=> entities.Books

        }

        [TestMethod]
        public void BookRepositoryTest()
        {
            BookRepository repo = new BookRepository { Entities = new FormationEntities()};
            int count = repo.GetAll().Count();
            Book b = new Book { Title = "EF en .NET", Price = 10.0m }; //m pour decimal
            Book b2 = new Book { Title = "Second Livre", Price = 85.4m }; //m pour decimal

            repo.Insert(b);
            repo.Save();

            Assert.IsNotNull(repo.GetById(1));

            repo.Insert(b2);
            repo.Save();

            Assert.AreEqual(count+2, repo.GetAll().Count());

            Func<Book, bool> f = book => book.Price > 50;
            Assert.AreEqual("Second Livre", repo.GetByLambda(f).First().Title);

            repo.Remove(entity: b); //passage par nom == repo.Remove(b);
            repo.Remove(b2);
            repo.Save();
            Assert.AreEqual(count, repo.GetAll().Count());
            Assert.AreEqual(1, repo.GetByLambda(book => book.Price < 15, 1, 2).ToList().Count());

            string s = "toto";
            s.ToUpperFirstLetter(); //On croit que c'est une methode native de string
        }

    }
}
