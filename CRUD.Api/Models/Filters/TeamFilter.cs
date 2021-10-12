using CRUD.Api.Framework.Models;

namespace CRUD.Api.Models.Filters
{
    public class TeamFilter : ModelFilter
    {
        public string Name { get; set; }
        public double? Income { get; set; }
    }
}
