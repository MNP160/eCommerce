using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Filtering
{
    public class PagedCollectionResponce <T> where T:class
    {

        public IEnumerable<T> Items { get; set; }

        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

    }
}
