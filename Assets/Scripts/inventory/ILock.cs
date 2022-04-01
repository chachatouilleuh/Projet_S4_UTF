using System.Collections.Generic;

public interface ILock
    {
        void OpenLock(List<KeyType> p_playerKeys);
    }