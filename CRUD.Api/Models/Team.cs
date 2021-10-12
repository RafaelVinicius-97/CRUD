using CRUD.Api.Framework.Models;
using System.Collections.Generic;

namespace CRUD.Api.Models
{
    public class Team : ModelBase
    {
        public string Name { get; set; }
        public double Income { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
