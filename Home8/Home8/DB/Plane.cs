﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home8
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Airport> Airport { get; set; }
        public string Model { get; set; }
    }
}
