using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;
using TDD.Partiel01.Lib.Ports;

namespace TDD.Partiel01.LibTests.InMemory
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
