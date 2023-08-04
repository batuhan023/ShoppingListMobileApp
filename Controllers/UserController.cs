using Microsoft.Extensions.Configuration;
using System.Web.Mvc;

namespace ShoppingListMobileApp1.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDTO registerDto)
        //{
        //    var httpClient = new HttpClient();
        //    string apiUrl = _configuration["MyConfigurations:MyApiUrl"];
        //    var response = await httpClient.PostAsJsonAsync(apiUrl + "Mail/verificationMail", registerDto);

        //    var message = response.Content.ReadAsStringAsync();



        //    var verifyDto = new VerifyDTO
        //    {
        //        Register = registerDto as RegisterDTO, // RegisterDTO nesnesini doğrudan VerifyDTO içine aktarabilirsiniz
        //        verifyCode = message.Result.ToString().Trim()// response.Content.ToString() ile elde ettiğiniz değeri "Code" özelliğine atayın
        //    };
        //    string serializedModel = JsonConvert.SerializeObject(verifyDto);
        //    TempData["MyUser"] = serializedModel;
        //    return RedirectToAction("VerifyAccount", "Session");

        //}

    }
}
