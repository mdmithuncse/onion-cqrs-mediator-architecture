using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public interface IAuditDomain
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
