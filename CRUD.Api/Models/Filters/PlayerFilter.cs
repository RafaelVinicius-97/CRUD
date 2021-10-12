using CRUD.Api.Framework.Models;
using System;

namespace CRUD.Api.Models.Filters
{
    public class PlayerFilter : ModelFilter
    {
        public string Name { get; set; }
        public double? Wage { get; set; }
        public Guid? TeamId { get; set; }
    }
}
