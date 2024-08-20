using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class ExceptionMessages
    {

        #region Category
        public const string CategoryNameExists = "Category Name Already exists";
        public const string CategoryShouldExistWhenRequested = "Requested brand does not exist";
        #endregion


        #region OperationClaim
        public const string OperationClaimNameExists = "OperationClaim Name Already exists";
        public const string OperationClaimShouldExistWhenRequested = "Requested OperationClaim does not exist";
        #endregion

        #region Tag
        public const string TagNameExists = "Tag Name Already exists";
        public const string TagShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region UserOperationClaim
        public const string UserOperationClaimNameExists = "UserOperationClaim Name Already exists";
        public const string UserOperationClaimShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region User
        public const string UserShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region Blog
        public const string BlogNameExists = "Blog Name Already exists";
        public const string BlogShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region Comment
        public const string OneUserCanAddFiveComment = "A user can only add up to five comments to a blog.";
        public const string CommentShouldExistWhenRequested = "Requested Comment does not exist";
        #endregion

        #region BlogTag

        public const string BlogTagExists = "Blog Tag Already exists";
        #endregion

        #region ContactUsMessage

        public const string ContactUsMessageShouldExistWhenRequested = "Requested Contact Us Message does not exist";
        #endregion

        #region CommentComplaintMessage

        public const string CommentComplaintShouldExistWhenRequested = "Requested Comment Complaint does not exist";
        #endregion

        #region BlogComplaintMessage

        public const string BlogComplaintShouldExistWhenRequested = "Requested Blog Complaint does not exist";
        #endregion

        #region BlogLikeDislike

        public const string BlogLikeDislikeShouldExistWhenRequested = "Requested Blog Like Dislike does not exist";
        #endregion
        #region CommentLikeDislike

        public const string CommentLikeDislikeShouldExistWhenRequested = "Requested Comment Like Dislike does not exist";
        #endregion

        #region BlogFavorite
        public const string BlogFavoriteShouldExistWhenRequested = "Requested Blog Favorite does not exist";
        #endregion

        #region Testimonial
        public const string TestimonialNameExists = "Testimonial  Already exists";
        public const string TestimonialShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region FAQ
        public const string FAQNameExists = "FAQ  Already exists";
        public const string FAQShouldExistWhenRequested = "Requested brand does not exist";
        #endregion
    }
}
