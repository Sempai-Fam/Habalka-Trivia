using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Infrastructure.Core.Models.QuizQuestion
{
    public class ActiveTextQuestionModel
    {
        public string LocalizedQuestionHeader { get; set; }
        public string LocalizedQuestionDescription { get; set; }
        public List<string> LocalizedQuestionAnswers { get; set; }
        public Sprite QuestionImage { get; set; }
    }
}