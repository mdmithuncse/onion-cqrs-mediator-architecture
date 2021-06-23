using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.OrganizationCommand
{
    public class CreateOrganizationCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }

        public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, long>
        {
            private readonly IAppDbContext context;

            public CreateOrganizationCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<long> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
            {
                var organization = new Organization
                {
                    Name = command.Name,
                    RegistrationNumber = command.RegistrationNumber,
                    TaxIdentificationNumber = command.TaxIdentificationNumber
                };

                context.Organizations.Add(organization);
                await context.SaveChangesAsync();

                return organization.Id;
            }
        }
    }
}
