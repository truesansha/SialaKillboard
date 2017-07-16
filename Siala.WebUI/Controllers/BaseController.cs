using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Siala.WebUI.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        //protected JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings
        //{
        //    Formatting = Formatting.Indented,
        //    ContractResolver = new CamelCasePropertyNamesContractResolver()
        //};
    }
}
