using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Ingredients;
using PotatoFinch.LudumDare55.Orders;
using UnityEngine;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class RequiredOrderDisplayBehaviour : MonoBehaviour {
		[SerializeField] private Transform _ingredientContainer;

		private IngredientDefinitionHolder _ingredientDefinitionHolder;
		private List<GameObject> _spawnedIngredientDisplays = new();
		
		public void Initialize(IngredientDefinitionHolder ingredientDefinitionHolder) {
			_ingredientDefinitionHolder = ingredientDefinitionHolder;
		}

		public void ShowRequiredOrder(OrderedDrink orderedDrink) {
			if (_spawnedIngredientDisplays.Count > 0) {
				DespawnRequiredIngredients();
			}
			
			SpawnRequiredIngredientsInBackground(orderedDrink);
		}

		private async void SpawnRequiredIngredientsInBackground(OrderedDrink orderedDrink) {
			_spawnedIngredientDisplays.Clear();
			
			foreach (IngredientType orderedIngredientType in orderedDrink.IngredientTypes) {
				if (!_ingredientDefinitionHolder.TryGetIngredientDefinitionByType(orderedIngredientType, out IngredientDefinition ingredientDefinition)) {
					continue;
				}

				try {
					_spawnedIngredientDisplays.Add(await ingredientDefinition.IngredientUiPrefab.InstantiateAsync(_ingredientContainer).Task);
				}
				catch (Exception e) {
					Debug.LogException(e);
				}
			}
		}

		private void DespawnRequiredIngredients() {
			for (int i = _spawnedIngredientDisplays.Count - 1; i >= 0; i--) {
				var spawnedIngredientObject = _spawnedIngredientDisplays[i];
				var ingredientType = spawnedIngredientObject.GetComponent<IngredientBehaviour>().IngredientType;
				_spawnedIngredientDisplays.Remove(spawnedIngredientObject);
				if (!_ingredientDefinitionHolder.TryGetIngredientDefinitionByType(ingredientType, out IngredientDefinition ingredientDefinition)) {
					Destroy(spawnedIngredientObject);
				}
				else {
					ingredientDefinition.IngredientPrefab.ReleaseInstance(spawnedIngredientObject);
				}
			}
		}
	}
}