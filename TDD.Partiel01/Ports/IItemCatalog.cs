using System.Collections.Generic;
using TDD.Partiel01.Lib.Purchases;

namespace TDD.Partiel01.Lib.Ports
{
    public interface IItemCatalog
    {
        bool IsUnavailable(List<Item> items);
        IEnumerable<Item> GetUnavailables(List<Item> items);
    }
}