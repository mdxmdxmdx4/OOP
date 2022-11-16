﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork4true
{
    class Continent
    {
        public string Name;
        public override string ToString()                       //переопределение метода ToString()
        {
            return ($"Континент {this.Name}, население = {this.Humanity}");
        }
        public double PrecOfC;
        public long Humanity;
        public Continent(string name, long humanity)
        {
            PrecOfC = 100;
            Name = name;
            Humanity = humanity;
        }
        public Continent() { }
        public virtual void PrintName()
        {
            Console.WriteLine("Название объекта - " + Name);
        }

    }

}
