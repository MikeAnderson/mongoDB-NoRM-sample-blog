using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using DomainModel.Abstract;
using DomainModel.Entities;
using MongoDB;
using MongoDB.Driver;

namespace DomainModel.Concrete
{
    public class MongoCSharpPostRepository : IPostRepository
    {
        MongoDB.Driver.Mongo db_server;
        MongoDB.Driver.IMongoCollection collection;

        private string _connectionString;

        public MongoCSharpPostRepository(string connectionString)
        {            
            _connectionString = connectionString;            
        }

        ~MongoCSharpPostRepository()
        {
            DisconnectFromDatabase();
        }

        // posts
        public IEnumerable<Post> GetPosts()
        {
            ConnectToDatabase();

            IList<Post> posts = new List<Post>();

            using (var all = collection.FindAll())
            {
                foreach (var doc in all.Documents)
                {
                    Post p = new Post { Id = doc["_id"].ToString().Replace("\"", ""), PostDate = Convert.ToDateTime(doc["PostDate"]), Title = doc["Title"].ToString(), Body = doc["Body"].ToString(), CharCount = Convert.ToInt32(doc["CharCount"]), CommentCount = Convert.ToInt32(doc["CommentCount"]) };

                    posts.Add(p);
                }   
            }

            DisconnectFromDatabase();

            return posts;
        }

        public Post GetPostById(string Id)
        {
            ConnectToDatabase();

            Document doc = collection.FindOne(new Document() { { "_id", new Oid(Id) } });

            IList<Comment> comments = new List<Comment>();

            //List<Document> comments  = (doc["Comments"] as Document[]).ToList();

            //var comments = (doc["Comments"] as Document[]);            

            //int x = ((Document[])doc["Comments"]).Count();

            Post post = new Post { Id = doc["_id"].ToString().Replace("\"", ""), PostDate = Convert.ToDateTime(doc["PostDate"]), Title = doc["Title"].ToString(), Body = doc["Body"].ToString(), CharCount = Convert.ToInt32(doc["CharCount"]), CommentCount = Convert.ToInt32(doc["CommentCount"]) };
            post.Comments = comments;

            DisconnectFromDatabase();

            return post;
        }

        public void CreatePost(Post post)
        {
            ConnectToDatabase();

            Document doc = new Document();
            doc["PostDate"] = post.PostDate;
            doc["Title"] = post.Title;
            doc["Body"] = post.Body;
            doc["CharCount"] = post.CharCount;
            doc["CommentCount"] = 0;

            collection.Save(doc);

            DisconnectFromDatabase();

            return;
        }

        public void DeletePost(string Id)
        {
            ConnectToDatabase();

            Oid id = new Oid(Id);

            var qry = new Document { { "_id", id } };

            collection.Delete(qry);

            DisconnectFromDatabase();

            return;
        }

        public void UpdatePost(Post post)
        {
            ConnectToDatabase();

            var qry = new Document { { "_id", new Oid(post.Id) } };

            Document doc = collection.FindOne(qry);

            doc["Title"] = post.Title;
            doc["Body"] = post.Body;
            doc["CharCount"] = post.CharCount;
            doc["CommentCount"] = 0;

            collection.Update(doc);

            DisconnectFromDatabase();

            return;
        }

        public IEnumerable<Post> SearchPosts(string SearchString)
        {
            //TODO: c# driver add search functionality

            IList<Post> posts = null;

            return posts;
        }

        // comments
        public void CreateComment(string PostId, Comment comment)
        {
            //TODO: mongodb-csharp driver add comment
        }

        public void DeleteComment(string PostId, string CommentId)
        {
            //TODO: mongodb-csharp driver delete comment
        }

        public void EditComment(string PostId, Comment comment)
        {
            //TODO: mongodb-csharp driver edit comment
        }

        // database
        private void ConnectToDatabase()
        {
            db_server = new MongoDB.Driver.Mongo(_connectionString);

            db_server.Connect();
            
            MongoDB.Driver.IMongoDatabase db = db_server.GetDatabase("MongoBlog");

            collection = db.GetCollection("blogposts");

            return;
        }

        private void DisconnectFromDatabase()
        {
            db_server.Disconnect();
        }

        private int GetNewCommentId(IEnumerable<Comment> comments)
        {
            //TODO: mongodb-csharp driver generate comment Id
            return 1;
        }
    }
}