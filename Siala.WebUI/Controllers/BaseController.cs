using System;
using Microsoft.AspNetCore.Mvc;
using Siala.Domain.Repository;

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        protected readonly IKillboardRepository Repository;
        protected readonly Int32 DefaultPageSize = 30;
        protected readonly Int32 DefaultPage = 1;

        protected BaseController(IKillboardRepository repository)
        {
            Repository = repository;
        }
        //protected JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings
        //{
        //    Formatting = Formatting.Indented,
        //    ContractResolver = new CamelCasePropertyNamesContractResolver()
        //};
    }
}
