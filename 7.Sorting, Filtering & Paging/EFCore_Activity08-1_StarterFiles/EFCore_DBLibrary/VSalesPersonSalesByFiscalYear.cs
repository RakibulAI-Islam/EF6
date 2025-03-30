using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_DBLibrary
{
    /// <summary>
    /// Uses PIVOT to return aggregated sales information for each sales representative.
    /// </summary>
    public partial class VSalesPersonSalesByFiscalYear
    {
        public int? SalesPersonId { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string SalesTerritory { get; set; }
        public decimal? _2002 { get; set; }
        public decimal? _2003 { get; set; }
        public decimal? _2004 { get; set; }
    }
}
