using ContextExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextExample.Data
{
    public class Context : IContext
    {
        public List<Movie> Movies { get; set; }


        public Context()
        {
            Movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Toy Story" },
                new Movie { Id = 2, Title = "Star Wars" },
                new Movie { Id = 3, Title = "Oceans 11" },
                new Movie { Id = 3, Title = "Oceans 12" }
            };
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetByTitle(string title)
        {
            return Movies.FirstOrDefault(x => x.Title == title);
        }

        public List<Movie> FindMovie(string title)
        {
             var result = Movies.Where<Movie>(mov => mov.Title.ToLower().Contains(title.ToLower())); //Linq search with lambda, comparison lowercase to make it case insensitive 
            return result.ToList();
        }
    }
}
