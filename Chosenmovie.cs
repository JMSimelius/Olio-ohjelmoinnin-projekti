﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ConsoleApp3;

namespace ConsoleApp3

{
    [Serializable]
    public class Chosenmovie : Movie
    {
        public string Chosen { get; set; }
    }
}