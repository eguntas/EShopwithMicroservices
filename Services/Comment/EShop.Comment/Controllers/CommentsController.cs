using EShop.Comment.Context;
using EShop.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;
        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddComment(UserComment userComment)
        {
            _commentContext.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Added comment success");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Updated comment success");
        }

        [HttpDelete]
        public IActionResult UpdateComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Deleted comment success");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);

        }
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            var values = _commentContext.UserComments.Where(x => x.Status == true).Count();
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            var values = _commentContext.UserComments.Where(x => x.Status == false).Count();
            return Ok(values);
        }
        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            var values = _commentContext.UserComments.Count();
            return Ok(values);
        }

    }
}
