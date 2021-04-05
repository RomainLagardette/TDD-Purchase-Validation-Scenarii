using System.Collections.Generic;

namespace TDD.Partiel01.Lib
{
    public interface IItemCatalog
    {
        bool IsUnavailable(List<Item> items);
        IEnumerable<Item> GetUnavailables(List<Item> items);
    }
}