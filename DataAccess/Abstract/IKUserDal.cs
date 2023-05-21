using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IKUserDal : IEntityRepository<UsersK>
    {
        List<OperationClaim> GetClaims(UsersK user);
    }
}
