using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;

namespace TDD.Partiel01.LibTests
{
    public class InMemoryAddressProvider : IAddressProvider
    {
        public List<string> existingAddresses = new List<string>
        {
            "98 Avenue du saucisson",
            "77 Avenue du Jambon"
        };

        public bool Exist(string line1)
        {
            return existingAddresses.Contains(line1);
        }
    }
}
