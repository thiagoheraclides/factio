using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FactIO.Api.Contracts.Company
{
    public class CompanyUpdateRequest
    {        
        public string Alias { get; set; }
        public string FullName { get; set; }
    }
}
