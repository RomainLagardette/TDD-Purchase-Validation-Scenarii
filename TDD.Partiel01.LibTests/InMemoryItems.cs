using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.Partiel01.Lib;

namespace TDD.Partiel01.LibTests
{
    public class InMemoryItems : IItemCatalog
    {
        public IEnumerable<Item> GetUnavailables(List<Item> items)
        {
            return items.Where(_ => _.Name == "tee-shirt rouge" || _.Name == "pull rose");
        }

        public bool IsUnavailable(List<Item> items)
        {
            return items.Any(_ => _.Name == "tee-shirt rouge") || items.Any(_ => _.Name == "pull rose");
        }
    }
}
