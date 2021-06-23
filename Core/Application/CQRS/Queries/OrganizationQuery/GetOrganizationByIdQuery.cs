using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.OrganizationQuery
{
    public class GetOrganizationByIdQuery : IRequest<Organization>
    {
        public long Id { get; set; }

        public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, Organization>
        {
            public readonly IAppDbContext context;

            public GetOrganizationByIdQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<Organization> Handle(GetOrganizationByIdQuery query, CancellationToken cancellationToken)
            {
                var organization = await context.Organizations.Where(x => x.Id == query.Id).FirstOrDefaultAsync();

                if (organization == null)
                {
                    return default;
                }

                return organization;
            }
        }
    }
}
