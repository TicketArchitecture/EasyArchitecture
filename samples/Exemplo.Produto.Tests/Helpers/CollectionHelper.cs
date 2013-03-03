using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo.Produto.Tests.Helpers
{
    public static class CollectionHelper
    {
        public static T GetRandom<T>(IList<T> list)
        {
            return list.Skip(new Random().Next(0, list.Count)).Take(1).First();
        }
    }
}
