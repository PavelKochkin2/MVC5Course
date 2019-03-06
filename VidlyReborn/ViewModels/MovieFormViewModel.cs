using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyReborn.Models;

namespace VidlyReborn.ViewModels
{
    public class MovieFormViewModel
    {
        public List<Genre> Genres { get; set; }

        public Movie Movie { get; set; }
    }
}