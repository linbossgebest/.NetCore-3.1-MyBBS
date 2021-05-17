using ApplicationCore.ViewModel;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyBBS.Filter
{
    /// <summary>
    /// 全局异常Filter
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public static ILog logger = LogManager.GetLogger(typeof(GlobalExceptionFilter));
        public void OnException(ExceptionContext context)
        {
            logger.Error("系统发生异常"+context.Exception);
            var result = new BaseResult()
            {
                ResultCode = ResultCodeAddMsgKeys.CommonExceptionCode,
                ResultMsg = ResultCodeAddMsgKeys.CommonExceptionMsg
            };
            context.Result = new ObjectResult(result);//返回结果
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//返回状态码
            context.ExceptionHandled = true;//异常是否已被处理
        }
    }
}
