using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FactIO.Api.Contracts.Area
{
    public class UpdateAreaRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
