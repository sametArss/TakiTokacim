using BusiniessLayer.Abstract;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TakiTokacim.Controllers
{
    
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int productId, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                TempData["CommentError"] = "Yorum boş olamaz.";
                return RedirectToAction("Details", new { id = productId });
            }

            // UserId'yi almak için
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                TempData["CommentError"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Details", new { id = productId });
            }

            var comment = new Comments
            {
                ProductId = productId,
                Subject = subject,
                Message = message,
                CommentDate = DateTime.Now,
                CommentStatus = false,
                UserId = userId
            };
            _commentService.Insert(comment);
            TempData["CommentSuccess"] = "Yorumunuz alınmıştır, admin onayından sonra yayınlanacaktır.";
            return RedirectToAction("Details","Products", new { id = productId });
        }


        // Onay bekleyen yorumlar
        public IActionResult Pendings()
        {
            var comments = _commentService.GetCommentFalse();
            return View(comments);
        }

        // Yorum onayla
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var comment = _commentService.GetCommentsId(id);
            if (comment != null)
            {
                comment.CommentStatus = true;
                _commentService.Update(comment);
            }
            return RedirectToAction("Pendings");
        }



    }
} 