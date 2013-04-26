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

    }
}
