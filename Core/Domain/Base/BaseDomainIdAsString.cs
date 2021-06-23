using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public class BaseDomainIdAsString : AuditDomain, IBaseDomainIdAsString
    {
        public string Id { get; set; }
    }
}
