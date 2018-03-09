using Basil.User.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Basil.User.EntityFrameworkCore.Repositories;
using Basil.Domain.Repositories;
using Basil.User.Core.IRepositories;
using Basil.User.Repository.Repositories;
using Basil.User.Core.Model;
using Basil.User.Repository;
using AspectCore.Injector;
using Basil.Util.Cache;
using System.Threading.Tasks;
using Basil.Util.Json;

namespace Basil.User.EntityFrameworkCore.Repositories {
    public class ClientRepository : UserRepositoryBase<m_Client>, IClientRepository {
    }
}
