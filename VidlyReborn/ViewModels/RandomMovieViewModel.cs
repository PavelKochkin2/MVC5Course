using System.Collections.Generic;
using VidlyReborn.Models;

namespace VidlyReborn.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }
    }
}