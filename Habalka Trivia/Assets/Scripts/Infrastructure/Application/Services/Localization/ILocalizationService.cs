namespace Trivia.Infrastructure.Application.Services.Localization
{
    public interface ILocalizationService
    {
        public void SetNewLanguage(LanguageType languageType);
        public LanguageType GetCurrentLanguage();
        public string GetTranslation(string folderName, string key);
        public string GetTranslation(string key);
    }
}