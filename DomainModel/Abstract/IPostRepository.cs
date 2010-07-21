using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface IPostRepository
    {
        // Category info
        IEnumerable<Post> GetPosts();
        
        Post GetPostById(string Id);
        void DeletePost(string Id);

        void CreatePost(Post post);
        void UpdatePost(Post post);

        void CreateComment(string PostId, Comment comment);
        void EditComment(string PostId, Comment comment);
        void DeleteComment(string PostId, string CommentId);

        IEnumerable<Post> SearchPosts(string SearchString);

        //void ConnectToDatabase();
        //void DisconnectFromDatabase();
        //int GetNewCommentId(IEnumerable<Comment> comments);

    }
}
