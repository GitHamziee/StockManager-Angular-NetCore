using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context; 
            

        }
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentbyID(int id)
        {
            return await _context.comments.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
