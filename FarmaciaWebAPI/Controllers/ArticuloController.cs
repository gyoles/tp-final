using FarmaciaData.Fachada;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using FarmaciaData.Dominio;

namespace FarmaciaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IDataImp dataApi;

        public ArticuloController()
        {
            dataApi = new DataApiImp();
        }

        [HttpGet("/GetArticulos")]
        public IActionResult GetArticulos()
        {
            List<Articulo> lst = null;
            try
            {
                lst = dataApi.GetArticulos();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }

}
