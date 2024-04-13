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

			List<IngredientType> tempList = new List<IngredientType>(_ingredientTypes);
			
			foreach (var ingredientType in otherDrink.IngredientTypes) {
				var couldRemove = tempList.Remove(ingredientType);

				if (!couldRemove) {
					return false;
				}
			}

			return true;
		}
	}
}