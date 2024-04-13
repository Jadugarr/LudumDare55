using UnityEngine;

namespace PotatoFinch.LudumDare55.Ingredients {
	public class IngredientDefinitionHolder {
		private readonly IngredientDefinition[] _ingredientDefinitions;

		public IngredientDefinitionHolder(IngredientDefinition[] ingredientDefinitions) {
			_ingredientDefinitions = ingredientDefinitions;
		}

		public bool TryGetIngredientDefinitionByType(IngredientType ingredientType, out IngredientDefinition ingredientDefinition) {
			ingredientDefinition = null;

			foreach (IngredientDefinition definition in _ingredientDefinitions) {
				if (definition.IngredientType != ingredientType) {
					continue;
				}

				ingredientDefinition = definition;
				return true;
			}
			
			Debug.LogError($"No ingredient definition set for type {ingredientType}");
			return false;
		}
	}
}