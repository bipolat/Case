using Case.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Case.Controllers
{
    public class UserController : Controller
    {

        #region User
        [HttpGet]
        [Route("api/GetAllUser")]
        public List<Users> GetAllUser()
        {
            return buisnesLogicLayer().GetAllUser();
        }

        [HttpPost]
        [Route("api/AddUser")]
        public void AddUser(int id, string name)
        {
            buisnesLogicLayer().AddUser(id,name);
           
        }

        [HttpDelete]
        [Route("api/RemoveUserById")]
        public int RemoveUserById(int id)
        {
            buisnesLogicLayer().RemoveUserById(id);
            return 1;
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
