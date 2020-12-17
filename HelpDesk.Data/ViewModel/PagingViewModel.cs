using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Data.ViewModel
{
    public class PagingViewModel
    {
        public int NumberOfPages { get; set; }

        public int CurrentPage { get; set; }

        public object Data { get; set; }
    }
}
