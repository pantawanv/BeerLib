using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib
{
    public class BeersRepository
    {
        private int _nextId = 1;
        private readonly List<Beer> _beers = new();

        public BeersRepository() 
        {
            _beers.Add(new Beer() { Id = _nextId++, Name = "Albani Odense Classic", ABV = 4.6 });
            _beers.Add(new Beer() { Id = _nextId++, Name = "Braunstein Brown Ale", ABV = 5.4});
            _beers.Add(new Beer() { Id = _nextId++, Name = "Carlsberg Elephant Beer", ABV = 7.2 });
            _beers.Add(new Beer() { Id = _nextId++, Name = "Gamle Carlsberg Porter", ABV = 8.2 });
            _beers.Add(new Beer() { Id = _nextId++, Name = "Herslev Pale Ale", ABV = 6 });
            
        }

        public IEnumerable<Beer> Get(int? abv = null, string? name = null, string? orderBy = null)
        {
            IEnumerable<Beer> result = new List<Beer>(_beers); 

            if (abv != null)
            {
                result = result.Where(b => b.ABV > abv);
            }
            
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "name":
                    case "name_asc":
                        result = result.OrderBy(b => b.Name);
                        break;
                    case "name_desc":
                        result = result.OrderByDescending(b => b.Name);
                        break;
                    case "abv_asc":
                        result = result.OrderBy(b => b.ABV); 
                        break;
                    case "abv_desc":
                        result = result.OrderByDescending(b => b.ABV);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Beer? GetById(int id)
        {
            return _beers.Find(b => b.Id == id);
        }
       
        public Beer Add(Beer beer)
        {
            beer.Validate();
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }

        public Beer? Remove (int id)
        {
            Beer? beer = GetById(id);
            if (beer == null)
            {
                return null;
            }
            _beers.Remove(beer);
            return beer;

        }

        public Beer? Update(int id, Beer beer)
        {
            beer.Validate();
            Beer? existingBeer = GetById (id);
            if (existingBeer == null)
            {
                return null;
            }
            existingBeer.Name = beer.Name;
            existingBeer.ABV = beer.ABV;
            return existingBeer;
        }
    }
}
