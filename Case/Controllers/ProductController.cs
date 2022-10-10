using Case.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Case.Controllers
{
    public class ProductController : Controller
    {

        #region Product
        [HttpGet]
        [Route("api/GetAllProducts")]

        public List<Product> GetAllProducts()
        {
            return buisnesLogicLayer().GetAllProducts(); 
        }

        [HttpPost]
        [Route("api/AddProduct")]
        public void AddProduct(int id, string name, int price)
        {
            buisnesLogicLayer().AddProduct(id, name,price);
        }


        [HttpDelete]
        [Route("api/RemoveProductById")]
        public void RemoveProductById(int id)
        {
            buisnesLogicLayer().RemoveProductById(id);
        }
        #endregion
        #region Helper
        public Bll.Bll buisnesLogicLayer()
        {
            return new Bll.Bll();
        }
        #endregion
    }
}
