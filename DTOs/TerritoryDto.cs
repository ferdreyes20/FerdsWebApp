using System.Collections.Generic;

namespace FerdsWebApp.DTOs
{
    public class TerritoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public List<TerritoryDto> territories { get; set; }
    }
}