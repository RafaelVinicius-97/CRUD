
using CRUD.Api.Framework.Models;
using System;

namespace CRUD.Api.Models
{
    public class Player : ModelBase
    {
        public string Name { get; set; }
        public double Wage { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
