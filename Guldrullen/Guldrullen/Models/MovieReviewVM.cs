﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieReviewVM
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public int Rate { get; set; }

        public int MovieId { get; set; }
    }
}

