using Microsoft.Extensions.Configuration;

namespace Constants
{
    public class TestSettings
    {
        static TestSettings()
        {
            SetDefaultValues();
        }

        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
        public static int ImplicitWait { get; set; }
        public static string ExtendedPageUrl { get; set; }
        public static string FavoritePageUrl { get; set; }
        public static string GirlfriendExperiencePage { get; set; }
        public static string MainPageUrl { get; set; }
        public static string PassportPageUrl { get; set; }
        public static string SettingsEditingPageUrl { get; set; }
        public static string FilmName { get; set; }
        public static string RussianFilmName { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string LoginErrorMessage { get; set; }
        public static string PasswordErrorMessage { get; set; }
        public static string UserName { get; set; }
        public static string UserSecondName { get; set; }

        public static void SetDefaultValues()
        {
            ImplicitWait = int.Parse(TestConfiguration["Settings:Common:ImplicitWait"]);
            ExtendedPageUrl = TestConfiguration["Settings:Common:ExtendedPageUrl"];
            FavoritePageUrl = TestConfiguration["Settings:Common:FavoritePageUrl"];
            GirlfriendExperiencePage = TestConfiguration["Settings:Common:GirlfriendExperiencePage"];
            MainPageUrl = TestConfiguration["Settings:Common:MainPageUrl"];
            PassportPageUrl = TestConfiguration["Settings:Common:PassportPageUrl"];
            SettingsEditingPageUrl = TestConfiguration["Settings:Common:SettingsEditingPageUrl"];
            FilmName = TestConfiguration["Settings:Common:FilmName"];
            RussianFilmName = TestConfiguration["Settings:Common:RussianFilmName"];
            Login = TestConfiguration["Settings:Common:Login"];
            Password = TestConfiguration["Settings:Common:Password"];
            LoginErrorMessage = TestConfiguration["Settings:Common:LoginErrorMessage"];
            PasswordErrorMessage = TestConfiguration["Settings:Common:PasswordErrorMessage"];
            UserName = TestConfiguration["Settings:Common:UserName"];
            UserSecondName = TestConfiguration["Settings:Common:UserSecondName"];
        }
    }
}
