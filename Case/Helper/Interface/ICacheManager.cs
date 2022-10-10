using System;

namespace Data
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Set(string key, object data, int cacheTime);
        void RemoveById(object obj, string key);
        //bool IsSet(string key);
        //bool Remove(string key);
        //void RemoveByPattern(string pattern);
        //void Clear();
    }
}