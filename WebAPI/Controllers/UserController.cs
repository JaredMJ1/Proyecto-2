
using Core.Managers;
using Entities.DTO;
using Entities.DTO2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost("Create")]
        public IActionResult Create([FromBody] UsuarioDTO u)
        {
            try
            {
                var um = new UserManager();
                um.Create(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        [HttpGet("RetrieveAll")]
        public IActionResult RetrieveAll()
        {
            try
            {
                var um = new UserManager();
                var result = um.RetrieveAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("RetrieveById/{id}")]
        public IActionResult RetrieveById(int id)
        {
            try
            {
                var um = new UserManager();
                var user = um.RetrieveById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

      
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UsuarioDTO u)
        {
            try
            {
                var um = new UserManager();
                um.Update(u);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] UsuarioDTO u)
        {
            try
            {
                var um = new UserManager();
                um.Delete(u.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}