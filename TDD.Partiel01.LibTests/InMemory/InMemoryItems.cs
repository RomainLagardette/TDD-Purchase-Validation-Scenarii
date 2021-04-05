using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.Partiel01.Lib;
using TDD.Partiel01.Lib.Ports;
using TDD.Partiel01.Lib.Purchases;

namespace TDD.Partiel01.LibTests.InMemory
{
    public class InMemoryItems : IItemCatalog
    {
        private List<Item> unavailableItems => new List<Item>
        {
            new Item("tee-shirt rouge"),
            new Item("pull rose")
        };

        public IEnumerable<Item> GetUnavailables(List<Item> items)
        {
            return items.Where(_ => unavailableItems.Select(__=>__.Name).Contains(_.Name));
        }

        public bool IsUnavailable(List<Item> items)
        {
            return items.Any(_ => unavailableItems.Select(__ => __.Name).Contains(_.Name));
        }
    }
}
