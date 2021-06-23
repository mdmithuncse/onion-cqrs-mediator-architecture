using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.OrganizationCommand
{
    public class UpdateOrganizationCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }

        public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, long>
        {
            private readonly IAppDbContext context;

            public UpdateOrganizationCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<long> Handle(UpdateOrganizationCommand command, CancellationToken cancellationToken)
            {
                var organization = await context.Organizations.Where(x => x.Id == command.Id).FirstOrDefaultAsync();

                if (organization == null)
                    return default;

                organization.Name = command.Name;
                organization.RegistrationNumber = command.RegistrationNumber;
                organization.TaxIdentificationNumber = command.TaxIdentificationNumber;
                organization.Updated = DateTime.UtcNow;
                
                await context.SaveChangesAsync();

                return organization.Id;
            }
        }
    }
}
