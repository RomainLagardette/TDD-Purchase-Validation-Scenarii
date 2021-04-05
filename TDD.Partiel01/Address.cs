using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib
{
    public class Address
    {
        public string Line1 { get; private set; }

        public Address()
        {
        }

        public Address(string line1)
        {
            Line1 = line1;
        }
    }
}
