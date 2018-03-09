using Basil.Domain.Repositories;
using Basil.User.Core.ICacherRepository;
using Basil.User.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Basil.User.Core.IRepositories {
    public interface IClientRepository : IRepository<m_Client>, ICacherRepository<m_Client> {
    }
}
