using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Messager {
    public interface IMessager<TMessagerConfig> where TMessagerConfig : MessageInfo {
        void Send(TMessagerConfig config);
    }
}
