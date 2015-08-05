using System;
using System.Collections.Generic;

namespace Tony.Common.Infrastructure.Events
{
    public class ShowPageEvent 
    {
        public Type PageToShow { get; set; }

        public Dictionary<PageParamKey, object> Param { get; set; }

        public bool NewInstatnce { get; set; }
    }
}
