using Basil.User.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.User.Core.IService {
    public interface IUserService {
        void Add(m_User user);
        int AddAndReturnId(m_User user);
    }
}
