using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Domain.Entities;
using UserModule.Infrastructure;

namespace UserModule.Persistence.Repositories
{
    public class UserRepository : BaseEntityRepository<User>
    {
        private readonly UserModuleDbContext _dbContext;
        public UserRepository(DbContext context, UserModuleDbContext dbContext) : base(context)
        {
            _dbContext = dbContext;
        }


    }
}
