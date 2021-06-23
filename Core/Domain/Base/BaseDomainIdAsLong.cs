using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public class BaseDomainIdAsLong : AuditDomain, IBaseDomainIdAsLong
    {
        public long Id { get; set; }
    }
}
