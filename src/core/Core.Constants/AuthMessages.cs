using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class AuthMessages
    {
        public const string SectionName = "Auth";

        public const string EmailAuthenticatorDontExists = "Email Authenticator Dont Exists";
        public const string OtpAuthenticatorDontExists = "OtpAuthenticatorDontExists";
        public const string AlreadyVerifiedOtpAuthenticatorIsExists = "AlreadyVerifiedOtpAuthenticatorIsExists";
        public const string EmailActivationKeyDontExists = "EmailActivationKeyDontExists";
        public const string UserDontExists = "UserDontExists";
        public const string UserHaveAlreadyAAuthenticator = "UserHaveAlreadyAAuthenticator";
        public const string RefreshDontExists = "RefreshDontExists";
        public const string InvalidRefreshToken = "InvalidRefreshToken";
        public const string UserMailAlreadyExists = "UserMailAlreadyExists";
        public const string PasswordDontMatch = "PasswordDontMatch";

        public static string UserAdded = "Kullanici basariyla eklendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
