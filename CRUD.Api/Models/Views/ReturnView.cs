using System.Collections.Generic;
using System;
using System.Linq;

namespace CRUD.Api.Models.Views
{
    public class ReturnView<T>
    {
        public T result { get; set; }
        public string message { get; set; }
        public int numberPage { get; set; }
        public int sizPage { get; set; }
    }
}
