using Basil.Domain.Repositories;
using Basil.User.Core.IRepositories;
using Basil.User.Core.Model;
using Basil.User.EntityFrameworkCore;
using Basil.User.Repository;
using Basil.User.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.User.EntityFrameworkCore.Repositories {
    public class UserRepository : UserRepositoryBase<m_User>, IUserRepository {
    }
}
