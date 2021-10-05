using BlazorProject.Server.Models;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMessageRepository messageRepository;
        public MessagesController(IMessageRepository messageRepository,AppDbContext a)
        {
            this.messageRepository = messageRepository;
            context = a;
        }

        [HttpGet("{FromId:int}/{ToId:int}")]
        public async Task<ActionResult> GetMessages(int FromId, int ToId)
        {
            try
            {
                return Ok(await messageRepository.GetMessages(FromId, ToId));
                //return Ok(await context.Profiles.ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. {e.Message}. {e.StackTrace} {e.InnerException} {e.Source}");
            }
        }
        /*
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Message>> GetMessage(int messageId)
        {
            try
            {
                var result = await MessageRepository.GetMessage(messageId);
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        */
    }
}
