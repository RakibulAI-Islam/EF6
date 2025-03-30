using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_DBLibrary
{
    /// <summary>
    /// Product names and descriptions. Product descriptions are provided in multiple languages.
    /// </summary>
    public partial class VProductAndDescription
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductModel { get; set; }
        public string CultureId { get; set; }
        public string Description { get; set; }
    }
}
