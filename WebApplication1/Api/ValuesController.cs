using FastCoding.Framework.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Api
{
    public class ValuesController : BaseController
    {
        [HttpGet]
        public Result Get()
        {
            return Result.OK("kdalfdja");
        }
    }
}
