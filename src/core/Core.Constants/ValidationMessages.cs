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
        public const string IndustryTypeIdMustBeGreaterThanZero = "IndustryTypeId must be greater than 0.";
  
        public const string TitleIsRequired = "TitleIsRequired";
        public const string NameIsRequired = "Name is required";
        public const string ContentIsRequired = "Content is required";
        public const string DescriptionIsRequired = "Description is required";
        public const string TitleMaxCharacterExceed = "Title cannot exceed 255 characters.";
        public const string NameMaxCharacterExceed = "Name cannot exceed 100 characters.";
        public const string WebsiteIsRequired = "Website is required";
        public const string DescriptionMaxCharacterExceed = "Description cannot exceed 500 characters.";
        public const string ContentMaxCharacterExceed = "Content cannot exceed 500 characters.";
        public const string TopicIsRequired = "Topic is required";
        public const string TopicMaxCharacterExceed = "Topic can not exceed 100 characters";
        public const string MessageIsRequired = "Message is required";
        public const string MessageMaxCharacterExceed = "Message cannot exceed 500 characters.";

        #endregion

        #region IndustryType
        public const string IndustryTypeNameCanNotBeEmpty = "IndustryType Name Can not be empty";
        public const string IndustryTypeNameMinLength = "IndustryType Name minimum length 2 character ";
        #endregion


      

        #region OperationClaim
        public const string OperationClaimNameCanNotBeEmpty = "OperationClaim Name Can not be empty";
        public const string OperationClaimNameMinLength = "OperationClaim Name minimum length 2 character ";
        #endregion
    }
}
