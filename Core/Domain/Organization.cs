using Domain.Base;
using System;

namespace Domain
{
    public class Organization : BaseDomainIdAsLong
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
    }
}
