using System.Collections.Generic;
using Trivia.Infrastructure.Application.Constants.Core;
using Trivia.Infrastructure.Application.Constants.Localization;
using Trivia.Infrastructure.Application.Constants.Resource;
using Trivia.Infrastructure.Application.Database.LevelDatabase.Data;
using Trivia.Infrastructure.Application.Services.Localization;
using Trivia.Infrastructure.Application.Services.SpriteLoader;
using Trivia.Infrastructure.Core.Data.RunTimeData;
using Trivia.Infrastructure.Core.Models.QuizQuestion;
using UnityEngine;
using Zenject;

namespace Trivia.Infrastructure.Core.Builders.TextQuiz
{
    public class TextQuizBuilder : ILevelBuilder
    {
        private readonly LocalizationService _localizationService;
        private readonly LevelRunTimeData _levelRunTimeData;
        private readonly ActiveTextQuestionModel _activeTextQuestionModel;
        private readonly LocalizationConstants _localizationConstants;
        private readonly ResourcesConstants _resourcesConstants;
        private readonly CoreConstants _coreConstants;
        private readonly SpriteLoaderService _spriteLoaderService;

        private QuizQuestionDataModel _cachedDataModel = null;

        public TextQuizBuilder(LocalizationService localizationService,
            LevelRunTimeData levelRunTimeData,
            ActiveTextQuestionModel activeTextQuestionModel,
            LocalizationConstants localizationConstants,
            ResourcesConstants resourcesConstants,
            CoreConstants coreConstants,
            SpriteLoaderService spriteLoaderService)
        {
            _localizationService = localizationService;
            _levelRunTimeData = levelRunTimeData;
            _activeTextQuestionModel = activeTextQuestionModel;
            _localizationConstants = localizationConstants;
            _resourcesConstants = resourcesConstants;
            _coreConstants = coreConstants;
            _spriteLoaderService = spriteLoaderService;
        }
        
        public void Build()
        {
            CacheCurrentQuestionModel();
            SetUpQuestion();
            BuildQuestion();
        }

        private void CacheCurrentQuestionModel()
        {
            var tempQuestionsList = _levelRunTimeData.CurrentLevelDataModel.LevelQuestionList;
            var currentQuestionIndex = _levelRunTimeData.CurrentActiveQuestionIndex;
            _cachedDataModel = tempQuestionsList[currentQuestionIndex];
        }

        private void SetUpQuestion()
        {
            InitializeQuestionImage();
            InitializeQuestionHeader();
            InitializeQuestionBody();
            InitializeQuestionDescription();
        }

        private void BuildQuestion()
        {
            //Call factory to create quiz window
        }

        private void InitializeQuestionImage()
        {
            string atlasPath = 
                $"{_resourcesConstants.QUIZ_ATLAS_FOLDER_PATH}/{_resourcesConstants.QUIZ_LEVEL_FOLDER_PATH}{_levelRunTimeData.CurrentLevelDataModel.LevelNumber}";
            
            Sprite tempSprite = _spriteLoaderService.GetSpriteByPath(atlasPath, _cachedDataModel.QuestionImageName);

            _activeTextQuestionModel.QuestionImage = tempSprite;
        }

        private void InitializeQuestionHeader()
        {
            string localizedQuestionName = _localizationService
                .GetTranslation(_localizationConstants.QUESTION_FOLDER_KEY, _cachedDataModel.QuestionNameKey);

            _activeTextQuestionModel.LocalizedQuestionHeader = localizedQuestionName;
        }

        private void InitializeQuestionBody()
        {
            List<string> tempLocalizedAnswerList = new List<string>();
            for (int index = 0; index < _coreConstants.QUIZ_ANSWERS_COUNT; index++)
            {
                string localizedAnswer = _localizationService
                    .GetTranslation(_localizationConstants.ANSWER_FOLDER_KEY,
                        $"{_cachedDataModel.QuestionNameKey}_{index}");
                tempLocalizedAnswerList.Add(localizedAnswer);
            }
            
            _activeTextQuestionModel.LocalizedQuestionAnswers.AddRange(tempLocalizedAnswerList);
        }

        private void InitializeQuestionDescription()
        {
            string localizedDescription = _localizationService
                .GetTranslation(_localizationConstants.DESCRIPTION_FOLDER_KEY, _cachedDataModel.QuestionDescriptionKey);

            _activeTextQuestionModel.LocalizedQuestionDescription = localizedDescription;
        }
        
        public class Factory : PlaceholderFactory<TextQuizBuilder>
        {
        }
    }
}