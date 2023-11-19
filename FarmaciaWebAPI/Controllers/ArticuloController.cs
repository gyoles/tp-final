using Microsoft.AspNetCore.Mvc;

namespace FarmaciaWebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IDataApi dataApi;
    }
}
