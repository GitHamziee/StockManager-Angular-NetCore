using API.Models;

namespace API.Interfaces
{
    public interface ICommentRepository
    {

        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment?> GetCommentbyID(int id);
        

    }
}
