namespace Devs.Application.Constants;

public static class Messages
{
    public static string ProgrammingLanguage_NotFound = "Programlama dili bulunamadı!";
    public static string ProgrammingLanguage_Id_NotEmpty = "Programlama dili Id alanı boş olamaz";
    public static string ProgrammingLanguage_Name_Exists = "Programlama dili zaten var!";
    public static string ProgrammingLanguage_Name_NotEmpty = "Programlama dili boş olamaz!";
    public static string ProgrammingLanguage_Name_MinLen = "Programlama dili en az 2 karakter olmalı!";
    public static string ProgrammingLanguage_Name_MaxLen = "Programlama dili en fazla 24 karakter olmalı!";


    public static string Technology_NotFound = "Programlama dili bulunamadı!";
    public static string Technology_Name_Exists = "Teknoloji zaten var!";


    public static string SocialProfile_NotFound = "Böyle bir sosyal profil bulunamadı!";
    public static string SocialProfile_DeveloperId_NotFound = "Böyle bir kullanıcı bulunamadı!";
    public static string SocialProfile_GithubUrl_AlreadyExist = "Github profili zaten atanmış!";
    public static string SocialProfile_LinkedinUrl_AlreadyExist = "LinkedIn profili zaten atanmış!";
    public static string SocialProfile_PersonalWebSiteUrl_AlreadyExist = "Kişisel Web profili zaten atanmış!";


    public static string User_NotFound = "Kullanıcı bulunamadı!";
    public static string User_Email_AlreadyExist = "Bu e-posta adresi kullanılmış!";
    public static string User_CredentialsError = "E-posta veya şifre hatalı!";
}