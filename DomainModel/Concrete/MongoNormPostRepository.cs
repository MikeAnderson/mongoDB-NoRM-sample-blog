using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using Norm;
using Norm.Collections;
using DomainModel.Abstract;
using DomainModel.Entities;
using System.Reflection;

namespace DomainModel.Concrete
{
    public class MongoNormPostRepository : IPostRepository
    {
        // constructor
        Mongo db_server;
        IMongoCollection<Post> collection;

        private string _connectionString;

        public MongoNormPostRepository(string connectionString)
        {            
            _connectionString = connectionString;
        }

        // not really necessary
        ~MongoNormPostRepository()
        {
            DisconnectFromDatabase();
        }

        // posts
        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> posts = null;

            try
            {
                ConnectToDatabase();

                posts = collection.Find().OrderByDescending(x => x.PostDate);

                // OR for pure LinQ
                // IEnumerable<Post> _posts = collection.Find();
                // posts = _posts.OrderByDescending(x => x.PostDate);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

            return posts;
        }

        public Post GetPostById(string Id)
        {
            Post post = null;

            try
            {
                ConnectToDatabase();

                post = collection.Find().Where(x => x.Id == Id).FirstOrDefault();

                // OR for pure LinQ
                // IEnumerable<Post> _posts = collection.Find();
                // posts = _posts.Where(x => x.Id == Id).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }


            return post;
        }

        public void CreatePost(Post post)
        {
            try
            {
                ConnectToDatabase();

                post.Id = Guid.NewGuid().ToString();
                collection.Insert(post);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

            return;
        }

        public void DeletePost(string Id)
        {
            try
            {
                ConnectToDatabase();

                Post post = collection.FindOne(new { _id = Id });

                collection.Delete(post);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

            return;
        }

        public void UpdatePost(Post post)
        {
            try
            {
                ConnectToDatabase();

                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.Title, post.Title));
                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.Body, post.Body));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

            return;
        }

        public IEnumerable<Post> SearchPosts(string SearchString)
        {
            //TODO: add search functionality

            IList<Post> posts = null;

            try
            {
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

            return posts;
        }

        // comments
        public void CreateComment(string Id, Comment comment)
        {
            try
            {
                ConnectToDatabase();

                Post post = collection.FindOne(new { _id = Id });

                comment._CommentId = GetNewCommentId(post.Comments);

                if (comment._CommentId == 1)
                    post.Comments = new List<Comment>();
                
                post.Comments.Add(comment);
                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.Comments, post.Comments));
                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.CommentCount, post.Comments.Count));

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }
        }

        public void DeleteComment(string Id, string CommentId)
        {
            Post post = null;

            try
            {
                ConnectToDatabase();

                post = collection.Find().Where(x => x.Id == Id).FirstOrDefault();

                IList<Comment> comments = new List<Comment>();

                foreach (var comment in post.Comments)
                {
                    if (comment._CommentId.ToString() != CommentId)
                        comments.Add(comment);
                }
                
                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.Comments, comments));
                collection.Update(new { _id = post.Id }, x => x.SetValue(p => p.CommentCount, (post.Comments.Count == 0) ? 0 : post.CommentCount - 1));

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                DisconnectFromDatabase();
            }

        }

        public void EditComment(string Id, Comment comment)
        {
            //TODO: edit comment
        }

        // database
        private void ConnectToDatabase()
        {
            db_server = Mongo.Create(_connectionString);

            collection = db_server.GetCollection<Post>("blogposts");

            return;
        }

        private void DisconnectFromDatabase()
        {
            if (db_server != null)
                db_server.Dispose();
        }

        private int GetNewCommentId(IEnumerable<Comment> comments)
        {
            int rtnId = 1;

            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    rtnId = (rtnId <= comment._CommentId) ? comment._CommentId + 1: rtnId;
                }
            }

            return rtnId;
        }
    }
}