using Case.Model;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Case.Bll
{
    public partial class Bll
    {
        public string redisKeyProduct = "product";

        public List<Product> GetAllProducts()
        {
            var mainModel = new List<Product>();
            RedisCacheManager manager = new RedisCacheManager();
            return manager.Get<List<Product>>(redisKeyProduct);
        }
        public void RemoveProductById(int id)
        {
            RedisCacheManager manager = new RedisCacheManager();
            List<Product> list = manager.Get<List<Product>>(redisKeyProduct);
            manager.RemoveById(list.Where(l => l.Id == id).FirstOrDefault(), redisKeyProduct);
        }
        public void AddProduct(int id, string name, int price)
        {
            RedisCacheManager manager = new RedisCacheManager();
            manager.Set(redisKeyProduct, new Product { Id = id, Name = name , Price=price }, redisDataDestroyTime);
        }

    }
}
