using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Helper;
using ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyBBS.Controllers
{
    public class AccountController : Controller
    {
        private readonly string CaptchaCodeSessionName = "CaptchaCode";

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCaptchaImage()
        {
            string captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = CaptchaHelper.GetImage(116, 36, captchaCode);
            HttpContext.Session.SetString(CaptchaCodeSessionName, captchaCode);
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "image/png");
        }

        [HttpPost, ValidateAntiForgeryToken, Route("Account/SignIn")]
        public async Task<String> SignInAsync(LoginModel model)
        {
            BaseResult result = new BaseResult();
          
            result.ResultCode = ResultCodeAddMsgKeys.CommonObjectSuccessCode;
            result.ResultMsg = ResultCodeAddMsgKeys.CommonObjectSuccessMsg;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "test"),
                    new Claim(ClaimTypes.Role,"admin"),

                    new Claim("Id","123"),
                    new Claim("LoginCount","1"),
                    new Claim("LoginLastIp","0.0.0.1"),
                    new Claim("LoginLastTime",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return JsonHelper.ObjectToJSON(result);
        }

        [Route("Account/SignOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}