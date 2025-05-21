using MediatR;
using Microsoft.EntityFrameworkCore;
using UserModule.Contracts.Queries;
using UserModule.Contracts.Repositories;
using UserModule.Domain.Entities;

namespace UserModule.Application.Handlers
{
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, List<User>>
    {
        private readonly IUserRepository userRepository;

        public GetListUserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetListUserQuery query, CancellationToken cancellationToken)
        {
            IQueryable<User> dbQuery = await userRepository.ListAllAsync();
            
            if (query.searchRequest.name != null)
            {
                dbQuery = dbQuery.Where(user => user.Name.StartsWith(query.searchRequest.name)).AsQueryable();
            }

            if (query.searchRequest.surname != null)
            {
                dbQuery = dbQuery.Where(user => user.Surname.StartsWith(query.searchRequest.surname)).AsQueryable();
            }

            if (query.searchRequest.email != null)
            {
                dbQuery = dbQuery.Where(user => user.Email.StartsWith(query.searchRequest.email)).AsQueryable();
            }

            if (query.searchRequest.roles != null)
            {
                dbQuery = dbQuery.Where(user => user.Roles.Select(role => role.RoleName).Intersect(query.searchRequest.roles).Count() > 0).AsQueryable();
            }

            return dbQuery.Include(user => user.Roles).ToList();
        }
    }
}
