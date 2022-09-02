using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserRepository
{
    public class EfUserDal : EfEntityRepositoryBase<User, DemoDbContext>, IUserDal
    {
        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            using (var context = new DemoDbContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(x => x.UserId == userId)
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId
                             equals operationClaim.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.OrderBy(x => x.Name).ToList();
            }
        }
    }
}
