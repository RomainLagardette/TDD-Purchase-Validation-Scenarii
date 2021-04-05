using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib.Purchases
{
    public class Item
    {
        public string Name { get; private set; }

        public Item(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
