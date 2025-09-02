using API.Interfaces;
using Microsoft.AspNetCore.Http;
using API.Mappers.CommentMappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }

        [HttpGet]
        [Route("get-all-comments")]
        public async Task<IActionResult> GetAll ()
        {
            var comments = await _commentRepo.GetAllCommentsAsync();

            var commentDto = comments.Select(s => s.MapToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("get-by-id/{id}")]
        
         public async Task<IActionResult> GetByID( int id)
        {
           var comment =  await _commentRepo.GetCommentbyID(id);

            return Ok(comment?.MapToCommentDto());

        }


        }


    }

