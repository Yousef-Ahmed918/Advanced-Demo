using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Demo
{

    class MovieEqualityComparer : IEqualityComparer<Movie>
    {
        public bool Equals(Movie? x, Movie? y)
        {
            return x?.Id.Equals(y?.Id)??y is null ? true : false;
        }

        public int GetHashCode([DisallowNull] Movie obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    internal class Movie:IEquatable<Movie>
    {
        public Movie(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        
        public override string ToString()
        {
            return $"ID: {Id} , Title: {Title} , Price: {Price}";
        }

        //for more better performance implemented the IEquatable interface
        //public override bool Equals(object? obj)
        //{
        //    Movie? movie = obj as Movie; //casting
        //    return this.Id.Equals(movie?.Id ?? 0) &&
        //        this.Title.Equals(movie.Title) &&
        //        this.Price.Equals(movie.Price);

        //}
        public bool Equals(Movie? movie)
        {
            return this.Id.Equals(movie?.Id ?? 0) &&
                 this.Title.Equals(movie.Title) &&
                 this.Price.Equals(movie.Price);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Title,Price);
        }

    }
}
