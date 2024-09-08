
using Microsoft.AspNetCore.Http.HttpResults;
using UndecidedApp.Data.Models.PostModels;

namespace UndecidedApp.Helper
{

    public class PostBuilder
    {
        
        public string BuildPost(string postBody, Post post)
        {

            if (postBody == null)
            {
                return "";
            }

            postBody = ReplaceTitle(postBody, post);
            postBody = ReplaceImages(postBody, post);
            postBody = ReplaceTag(postBody, post);


            return postBody;
        }

        private string ReplaceTag(string postBody, Post post)
        {
            if (post.Tags != null && post.Tags.Count > 0)
            {
                string tags = "";
                foreach (var tag in post.Tags)
                {
                    tags += tag + " ";
                }
                postBody = postBody.Replace("#Tags#", tags);
            }
            else
            {
                postBody = postBody.Replace("#Tags#", "");
            }

            return postBody;
        }

        private string ReplaceImages(string postBody, Post post)
        {
            if (post.CoverImageURL != null)
            {
                postBody = postBody.Replace("#CoverImage#", String.Format("<img src='{0}' alt='Cover image' />", post.CoverImageURL.ToString()));
            }

            if (post.PostImages != null && post.PostImages.Count > 0)
            {
                for (int i = 1; i <= post.PostImages.Count; i++)
                {
                    postBody = postBody.Replace(String.Format("#PostImage_{0}", i.ToString()), String.Format("<img src='{0}' alt='Post Image_{1}' />", post.PostImages[i].ToString(), i.ToString()));
                }
            }


            return postBody;
        }

        private string ReplaceTitle(string postBody, Post post)
        {
            postBody = postBody.Replace("#Title#", String.Format("<h3>{0}</h3>", post.Title.ToString()));

            return postBody;

        }
    }
}
