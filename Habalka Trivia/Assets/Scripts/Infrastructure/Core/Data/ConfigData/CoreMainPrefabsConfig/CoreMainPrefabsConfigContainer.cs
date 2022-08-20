using Trivia.Infrastructure.Core.MonoModels.MapCell;
using UnityEngine;

namespace Trivia.Infrastructure.Core.Data.ConfigData.CoreMainPrefabsConfig
{
    [CreateAssetMenu(menuName = "Configs/Core/Main Prefabs/Prefabs Container", fileName = "Main_Prefabs_Container")]
    public class CoreMainPrefabsConfigContainer : ScriptableObject
    {
        [SerializeField] private CellCategoryViewModel _cellCategoryPrefab = null;

        public CellCategoryViewModel CellCategoryPrefab => _cellCategoryPrefab;
    }
}