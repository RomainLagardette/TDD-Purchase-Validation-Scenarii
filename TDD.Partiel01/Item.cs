using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib
{
    public class Item
    {
        private string name;

        public Item(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
