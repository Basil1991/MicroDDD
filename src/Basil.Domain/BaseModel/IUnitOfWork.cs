using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basil.Domain.BaseModel {
    public interface IUnitOfWork : IDisposable {
        int Save();
    }
}
