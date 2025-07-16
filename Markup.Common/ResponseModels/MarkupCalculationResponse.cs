using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markup.Common.ResponseModels
{
    public class MarkupCalculationResponse
    {
        public int Id { get; set; }
        public decimal TotalBaseFare { get; set; }
        public decimal TotalMarkup { get; set; }
        public decimal TotalFare { get; set; }
    }
}
