using Microsoft.AspNetCore.Mvc;

namespace Case.Controllers
{
    public class BasketController : Controller
    {
        #region Basket
        [HttpPost]
        [Route("api/AddBasket")]
        public void AddBasket(int productId, int userId)
        {
            buisnesLogicLayer().AddBasket(productId, userId);
            
        }

        [HttpDelete]
        [Route("api/RemoveBasket")]
        public void RemoveBasket(int productId, int userId)
        {
           buisnesLogicLayer().RemoveBasketProductByUserId(productId, userId);
         
        }

        [HttpOptions]
        [Route("api/GetBasketByUserId")]
        public dynamic GetBasketByUserId(int? userId)
        {
           return buisnesLogicLayer().GetBasketByUserId(userId);
           
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
