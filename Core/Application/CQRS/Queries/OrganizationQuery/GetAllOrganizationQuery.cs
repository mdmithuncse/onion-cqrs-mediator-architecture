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
    public class GetAllOrganizationQuery : IRequest<IEnumerable<Organization>>
    {
        public class GetAllOrganizationQueryHandler : IRequestHandler<GetAllOrganizationQuery, IEnumerable<Organization>>
        {
            public readonly IAppDbContext context;

            public GetAllOrganizationQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<Organization>> Handle(GetAllOrganizationQuery query, CancellationToken cancellationToken)
            {
                var organizationList = await context.Organizations.ToListAsync();

                if (organizationList == null || !organizationList.Any())
                {
                    return default;
                }

                return organizationList.AsReadOnly();
            }
        }
    }
}
