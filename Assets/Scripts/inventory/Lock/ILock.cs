using System.Collections.Generic;
using inventory.Object;

namespace inventory.Lock
{
    public interface ILock
    {
        void OpenLock(List<KeyType> p_playerKeys);
    }
}
