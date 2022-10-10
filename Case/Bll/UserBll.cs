using Case.Model;
using Case.Model.Const;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Case.Bll
{
    public partial class Bll
    {
        public string redisKeyUser = "user";
        public int redisDataDestroyTime = 60;
        public List<Users> GetAllUser()
        {
            var mainModel = new List<Product>();
            RedisCacheManager manager = new RedisCacheManager();
            return manager.Get<List<Users>>(redisKeyUser);
          
        }
        public void AddUser(int id,string name)
        {
            RedisCacheManager manager = new RedisCacheManager();
            manager.Set(redisKeyUser, new Users { Id = id, Name = name}, redisDataDestroyTime);

        }
        public void RemoveUserById(int id)
        {
            RedisCacheManager manager = new RedisCacheManager();
            List<Users> list = manager.Get<List<Users>>(redisKeyUser);
            manager.RemoveById(list.Where(l => l.Id == id).FirstOrDefault(), redisKeyUser);
           
        }
    }
}
