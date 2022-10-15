using System.Collections.Generic;

namespace P3D.Game.Utility
{
    public static class CollectionExtensions
    {
        public static T First<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                return default;

            return list[0];
        }
    }
}