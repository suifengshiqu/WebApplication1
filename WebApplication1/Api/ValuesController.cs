using FastCoding.Framework;
using FastCoding.Framework.Attributes;
using FastCoding.Framework.Entities;
using FastCoding.Framework.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Api
{
    [AllowAnonymous]
    public class ValuesController : BaseController
    {
        [HttpGet]
        public Result Get()
        {
            return Result.OK("kdalfdja");
        }
        [Log, HttpGet]
        public Result Enum()
        {
            return Result.OK(Utils.AsModel<TestEnum>());
        }
    }
}
