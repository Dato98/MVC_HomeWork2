﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MovieVM
    {
        public IEnumerable<Movie> Movies { get; set; }

        public Movie Movie { get; set; }
    }
}
