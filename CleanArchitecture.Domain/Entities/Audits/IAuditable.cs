using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Audits
{
    internal interface IAuditable
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
