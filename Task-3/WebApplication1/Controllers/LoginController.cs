using business_logic_layer;
using Data_logic_layer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public BALLogin _balLogin;

        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        ResponseResult result = new ResponseResult();

        [HttpPost]
        public ResponseResult LoginUser(User user)
        {
            try
            {
                result.Data = _balLogin.LoginUser(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}

    

