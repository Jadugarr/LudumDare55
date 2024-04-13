using UnityEngine;

namespace PotatoFinch.LudumDare55.Ingredients {
	public class IngredientBehaviour : MonoBehaviour {
		[SerializeField] private IngredientType _ingredientType;

		public IngredientType IngredientType => _ingredientType;
	}
}