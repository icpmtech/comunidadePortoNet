using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityNetPortoAngular.Helpers
{
    public class HelperSplit
    {
        public static List<List<T>> Split<T>(List<T> source)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 4)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}