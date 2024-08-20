using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class ValidationMessages
    {

        #region Common Messages
        public const string UserIdMustBeGreaterThanZero = "UserId must be greater than 0.";
        public const string TagIdMustBeGreaterThanZero = "TagId must be greater than 0.";
        public const string BlogIdMustBeGreaterThanZero = "BlogId must be greater than 0.";
        public const string CommentIdMustBeGreaterThanZero = "CommentId must be greater than 0.";
        public const string CategoryIdMustBeGreaterThanZero = "CategoryId must be greater than 0.";

        public const string TitleIsRequired = "TitleIsRequired";
        public const string ContentIsRequired = "Content is required";
        public const string DescriptionIsRequired = "Description is required";
        public const string TitleMaxCharacterExceed = "Title cannot exceed 255 characters.";
        public const string DescriptionMaxCharacterExceed = "Description cannot exceed 500 characters.";
        public const string ContentMaxCharacterExceed = "Content cannot exceed 500 characters.";
        public const string TopicIsRequired = "Topic is required";
        public const string TopicMaxCharacterExceed = "Topic can not exceed 100 characters";
        public const string MessageIsRequired = "Message is required";
        public const string MessageMaxCharacterExceed = "Message cannot exceed 500 characters.";

        #endregion

        #region Category
        public const string CategoryNameCanNotBeEmpty = "Category Name Can not be empty";
        public const string CategoryNameMinLength = "Category Name minimum length 2 character ";
        #endregion


        #region Tag
        public const string TagNameCanNotBeEmpty = "Tag Name Can not be empty";
        public const string TagNameMinLength = "Tag Name minimum length 2 character ";
        #endregion

        #region OperationClaim
        public const string OperationClaimNameCanNotBeEmpty = "OperationClaim Name Can not be empty";
        public const string OperationClaimNameMinLength = "OperationClaim Name minimum length 2 character ";
        #endregion
    }
}
