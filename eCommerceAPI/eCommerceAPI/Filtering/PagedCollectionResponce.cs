using farmersAPi.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Filtering
{
    public class PagedCollectionResponce <TDto> where TDto:IDto
    {

        public IEnumerable<TDto> Items { get; set; }

        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

    }
}
