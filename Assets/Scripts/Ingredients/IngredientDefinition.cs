using PotatoFinch.LudumDare55.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PotatoFinch.LudumDare55.Ingredients {
	[CreateAssetMenu(fileName = "IngredientDefinition", menuName = "ScriptableObjects/IngredientDefinition")]
	public class IngredientDefinition : ScriptableObject {
		[SerializeField] private AssetReference _ingredientPrefab;
		[SerializeField] private AssetReference _ingredientUiPrefab;
		[SerializeField] private IngredientType _ingredientType;
		[SerializeField] private LocalizationKey _localizationKey;

		public AssetReference IngredientPrefab => _ingredientPrefab;
		public AssetReference IngredientUiPrefab => _ingredientUiPrefab;
		public IngredientType IngredientType => _ingredientType;

		public LocalizationKey LocalizationKey => _localizationKey;

	}
}