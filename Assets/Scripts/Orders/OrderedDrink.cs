using System.Collections.Generic;
using PotatoFinch.LudumDare55.Ingredients;

namespace PotatoFinch.LudumDare55.Orders {
	public class OrderedDrink {
		private List<IngredientType> _ingredientTypes;

		public List<IngredientType> IngredientTypes => _ingredientTypes;

		public OrderedDrink(List<IngredientType> ingredientTypes) {
			_ingredientTypes = ingredientTypes;
		}

		public bool IsSameDrink(OrderedDrink otherDrink) {
			if (otherDrink == null) {
				return false;
			}
			
			if (IngredientTypes.Count != otherDrink.IngredientTypes.Count) {
				return false;
			}

			foreach (var ingredientType in IngredientTypes) {
				if (!otherDrink.IngredientTypes.Contains(ingredientType)) {
					return false;
				}
			}

			return true;
		}
	}
}