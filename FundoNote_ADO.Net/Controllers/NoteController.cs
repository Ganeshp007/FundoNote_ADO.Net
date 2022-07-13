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

        [Authorize]
        [HttpGet("GetALlNote")]
        public async Task<IActionResult> GetAllNote()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                if (UserId <=0)
                {
                    return BadRequest("There is no Note Exists!!");
                }
                var NoteData=await this.noteBL.GetAllNote(UserId);
                return Ok(new { sucess = true, Message = "Notes Data Retrieved successfully..." ,data=NoteData});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("UpdateNote")]
        public async Task<IActionResult> UpdateNote(int NoteId,UpdateNoteModel updateNoteModel)
        {
            if (updateNoteModel == null)
            {
                return BadRequest("Note is null.");
            }
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);
                if(updateNoteModel.Title=="" || updateNoteModel.Title=="string" && updateNoteModel.Description == "string" && updateNoteModel.Bgcolor == "string")
                {
                    return this.BadRequest(new { sucess = false, Message = "Please Provide Valid Fields for Note!!" });
                }
                await this.noteBL.UpdateNote(UserId,NoteId,updateNoteModel);
                return Ok(new { sucess = true, Message = "Note Updated Successfully..." });
            }
            catch (Exception ex)
            {
                if(ex.Message== "Note Does Not Exist!!")
                {
                    return this.BadRequest(new { sucess = false, Message = "Note Does not Exists!!" });
                }
                throw ex;
            }
        }
    }
}

