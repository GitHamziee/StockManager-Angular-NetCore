using API.Data;
using API.Dtos.Comment;
using API.Models;

namespace API.Mappers.CommentMappers
{
    public static class CommentMapper
    {
        public static CommentDto MapToCommentDto(this Comment commentModel )
        {

            return new CommentDto { 
            
                Id = commentModel.Id ,
                Content = commentModel.Content ,
                 CreatedOn = commentModel.CreatedOn ,
                 StockId = commentModel.StockId ,
                 Title = commentModel.Title ,
            };


        }

    }
}
