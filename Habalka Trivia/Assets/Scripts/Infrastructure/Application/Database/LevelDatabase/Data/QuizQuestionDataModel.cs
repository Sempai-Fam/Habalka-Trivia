namespace Trivia.Infrastructure.Application.Database.LevelDatabase.Data
{
    public class QuizQuestionDataModel
    {
        public int QuestionIndex { get; }
        public QuizQuestionCategory QuestionCategory { get; }
        public string QuestionNameKey { get; }
        public string QuestionDescriptionKey { get; }
        public string QuestionImageName { get; }

        public QuizQuestionDataModel(int questionIndex, QuizQuestionCategory questionCategory, string questionNameKey, string questionDescriptionKey, string questionImageName)
        {
            QuestionIndex = questionIndex;
            QuestionCategory = questionCategory;
            QuestionNameKey = questionNameKey;
            QuestionDescriptionKey = questionDescriptionKey;
            QuestionImageName = questionImageName;
        }
    }
}