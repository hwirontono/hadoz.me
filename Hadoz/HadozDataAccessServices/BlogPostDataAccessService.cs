using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using HadozDataModel;

namespace HadozDataAccessServices
{
    public class BlogPostDataAccessService
    {
        //CRUD
        public List<BlogPost> GetAllBlogPosts()
        {
            SqlConnection conn = new SqlConnection(Database.HadozDB());
            SqlCommand command = new SqlCommand("Blog_GetAllBlogPosts", conn);

            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@Email", SqlDbType.VarChar, 256).Value = "email";

            BlogPost bp;
            List<BlogPost> blogPosts = new List<BlogPost>();
            SqlDataReader reader = null;

            try {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
	            {
                    bp = new BlogPost(reader.GetInt32(reader.GetOrdinal("PostID")),
                                      reader.GetString(reader.GetOrdinal("Title")),
                                      reader.GetString(reader.GetOrdinal("Body")),
                                      reader.GetString(reader.GetOrdinal("Excerpt")),
                                      reader.GetDateTime(reader.GetOrdinal("CreateDate")).ToLongDateString(),
                                      reader.GetDateTime(reader.GetOrdinal("UpdateDate")).ToLongDateString(),
                                      reader.GetInt32(reader.GetOrdinal("Status")),
                                      reader.GetInt32(reader.GetOrdinal("AuthorID")));
                    blogPosts.Add(bp);
	            }

                reader.Close();
            }
            catch(Exception e){

            }
            finally {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return blogPosts;
        }


        public BlogPost GetABlogPost(int PostID)
        {
            SqlConnection conn = new SqlConnection(Database.HadozDB());
            SqlCommand command = new SqlCommand("Blog_GetABlogPost", conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;

            BlogPost bp = null;
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bp = new BlogPost(reader.GetInt32(reader.GetOrdinal("PostID")),
                                      reader.GetString(reader.GetOrdinal("Title")),
                                      reader.GetString(reader.GetOrdinal("Body")),
                                      reader.GetString(reader.GetOrdinal("Excerpt")),
                                      reader.GetDateTime(reader.GetOrdinal("CreateDate")).ToLongDateString(),
                                      reader.GetDateTime(reader.GetOrdinal("UpdateDate")).ToLongDateString(),
                                      reader.GetInt32(reader.GetOrdinal("Status")),
                                      reader.GetInt32(reader.GetOrdinal("AuthorID")));
                }

                reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
           
            return bp;
        }


        public List<BlogCategory> GetCategoriesForAPost(int PostID)
        {
            SqlConnection conn = new SqlConnection(Database.HadozDB());
            SqlCommand command = new SqlCommand("Blog_GetCategoriesForAPost", conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;

            BlogCategory bc;
            List<BlogCategory> blogCategories = new List<BlogCategory>();
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bc = new BlogCategory(reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                          reader.GetString(reader.GetOrdinal("CategoryName")));
                    blogCategories.Add(bc);
                }

                reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return blogCategories;
        }

        public List<BlogPostMetaTag> GetTagsForAPost(int PostID)
        {
            SqlConnection conn = new SqlConnection(Database.HadozDB());
            SqlCommand command = new SqlCommand("Blog_GetMetaTagsForAPost", conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;

            BlogPostMetaTag bt;
            List<BlogPostMetaTag> blogTags = new List<BlogPostMetaTag>();
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bt = new BlogPostMetaTag(reader.GetInt32(reader.GetOrdinal("TagID")),
                                             reader.GetInt32(reader.GetOrdinal("PostID")),
                                             reader.GetString(reader.GetOrdinal("TagKey")),
                                             reader.GetString(reader.GetOrdinal("TagValue")));
                    blogTags.Add(bt);
                }

                reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return blogTags;
        }


        public List<BlogComment> GetCommentsForAPost(int PostID)
        {
            SqlConnection conn = new SqlConnection(Database.HadozDB());
            SqlCommand command = new SqlCommand("Blog_GetCommentsForAPost", conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PostID", SqlDbType.Int).Value = PostID;

            BlogComment bc;
            List<BlogComment> blogComments = new List<BlogComment>();
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bc = new BlogComment(reader.GetInt32(reader.GetOrdinal("CommentID")),
                                         reader.GetInt32(reader.GetOrdinal("PostID")),
                                         reader.GetString(reader.GetOrdinal("CommentAuthor")),
                                         reader.GetString(reader.GetOrdinal("CommentAuthorEmail")),
                                         reader.GetString(reader.GetOrdinal("CommentAuthorIP")),
                                         reader.GetDateTime(reader.GetOrdinal("CommentDate")).ToLongDateString(),
                                         reader.GetString(reader.GetOrdinal("CommentBody")),
                                         reader.GetBoolean(reader.GetOrdinal("IsApproved")),
                                         reader.GetInt32(reader.GetOrdinal("CommentStatus")),
                                         reader.GetInt32(reader.GetOrdinal("Parent")));
                                         
                    blogComments.Add(bc);
                }

                reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return blogComments;
        }   

    }
}
