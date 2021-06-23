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
    public class DeleteOrganizationByIdCommand : IRequest<long>
    {
        public long Id { get; set; }

        public class DeleteOrganizationByIdCommandHandler : IRequestHandler<DeleteOrganizationByIdCommand, long>
        {
            private readonly IAppDbContext context;

            public DeleteOrganizationByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<long> Handle(DeleteOrganizationByIdCommand command, CancellationToken cancellationToken)
            {
                var organization = await context.Organizations.Where(x => x.Id == command.Id).FirstOrDefaultAsync();

                if (organization == null) 
                    return default;

                context.Organizations.Remove(organization);
                await context.SaveChangesAsync();

                return organization.Id;
            }
        }
    }
}
