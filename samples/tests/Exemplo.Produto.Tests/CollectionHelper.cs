using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo.Produto.Tests
{
    public static class CollectionHelper
    {
        public static T GetRandom<T>(IList<T> list)
        {
            return list.Skip(new Random().Next(0, list.Count)).Take(1).First();
        }
    }
}
