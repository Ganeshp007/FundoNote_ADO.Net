using BusinessLayer.Interface;
using DatabaseLayer.NoteModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNote_ADO.Net.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NoteController : Controller
    {
        INoteBL noteBL;
        public NoteController(INoteBL noteBL)
        {
            this.noteBL = noteBL;
        }

        [HttpPost("AddNote")]
        public async Task<IActionResult> AddNote(AddNoteModel addNoteModel)
        {
            if (addNoteModel == null)
            {
                return BadRequest("Note is null.");
            }
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                await this.noteBL.AddNote(UserId, addNoteModel);
                return Ok(new {sucess=true,Message="Note Created Successfully..."});
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
