using Case.Model;
using Data;
using System.Collections.Generic;
using System.Linq;
using Case.Model.Const;
using System.Xml.Linq;

namespace Case.Bll
{
    public partial class Bll
    {
        public string redisKeyBasketProduct = "basketproduct";
        public void AddBasket(int userId,int productId)
        {
            RedisCacheManager manager = new RedisCacheManager();
            manager.Set(redisKeyBasketProduct, new BasketProduct { UserId = userId,  ProdID= productId }, redisDataDestroyTime);
        }

        public void RemoveBasketProductByUserId(int userId, int prodId)
        {
            RedisCacheManager manager = new RedisCacheManager();
            List<BasketProduct> list = manager.Get<List<BasketProduct>>(redisKeyBasketProduct);
            manager.RemoveById(list.Where(l => l.UserId == userId && l.ProdID == prodId).FirstOrDefault(), redisKeyBasketProduct);
        }

        public object GetBasketByUserId(int? userId)
        {
            RedisCacheManager manager = new RedisCacheManager();
            List<BasketProduct> basketProducts = manager.Get<List<BasketProduct>>(redisKeyBasketProduct);
            List<Product> products = manager.Get<List<Product>>(redisKeyProduct);
            List<Users> user = manager.Get<List<Users>>(redisKeyUser);
            if (products != null && basketProducts != null && basketProducts != null)
            {
               basketProducts=userId!=null?basketProducts.Where(b=>b.UserId==userId).ToList():basketProducts;
                return from b in basketProducts
                       join p in products on b.ProdID equals p.Id
                       join u in user on b.UserId equals u.Id
                       orderby u.Name descending
                       select new { User = u.Name, Product = p.Name, Price = p.Price,Uid=u.Id,Pid=p.Id };
                
            }
            else
                return null;
        } 
    }
    
}
