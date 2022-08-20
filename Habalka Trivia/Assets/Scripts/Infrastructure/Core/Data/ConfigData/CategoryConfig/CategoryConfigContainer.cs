using System;
using System.Collections.Generic;
using Trivia.Infrastructure.Core.Data.CellCategoryType;
using UnityEngine;

namespace Trivia.Infrastructure.Core.Data.ConfigData.CategoryConfig
{
    [CreateAssetMenu(menuName = "Configs/Core/Categories/Category Container", fileName = "Category_Container")]
    public class CategoryConfigContainer : ScriptableObject
    {
        [SerializeField] private List<CategoryDataModel> _categoryDataModels = new List<CategoryDataModel>();

        public CategoryDataModel GetCategoryModel(CellCategoryStatusType categoryStatusType)
        {
            return _categoryDataModels.Find(it => it.CategoryType == categoryStatusType);
        }
    }

    [Serializable]
    public class CategoryDataModel
    {
        [SerializeField] private CellCategoryStatusType _categoryType = CellCategoryStatusType.None;
        [SerializeField] private Sprite _categoryFrontSprite = null;
        [SerializeField] private Sprite _categoryBackSprite = null;

        public CellCategoryStatusType CategoryType => _categoryType;
        public Sprite CategoryFrontSprite => _categoryFrontSprite;
        public Sprite CategoryBackSprite => _categoryBackSprite;
    }
}