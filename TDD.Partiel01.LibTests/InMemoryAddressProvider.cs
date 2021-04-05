using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;

namespace TDD.Partiel01.LibTests
{
    public class InMemoryAddressProvider : IAddressProvider
    {
        public bool Exist(string line1)
        {
            return line1 == "98 Avenue du saucisson" || line1 == "77 Avenue du Jambon";
        }
    }
}
