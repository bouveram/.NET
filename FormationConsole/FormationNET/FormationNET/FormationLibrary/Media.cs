using System.Collections.Generic;

namespace FormationLibrary
{
    public abstract class Media : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public List<Author> Authors = new List<Author>();
        public virtual double VATPrice
        {
            get {
                return Price * 1.20;
            }
        }

    }

}
