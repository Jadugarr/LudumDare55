using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Task = System.Threading.Tasks.Task;

namespace PotatoFinch.LudumDare55.Ingredients {
	public class IngredientSpawner {
		public static IngredientSpawner Instance { get; private set; }

		private Vector3 _ingredientSpawnPosition;
		private IngredientDefinitionHolder _ingredientDefinitionHolder;
		private List<GameObject> _spawnedIngredientObjects;

		private IngredientSpawner(Vector3 ingredientSpawnPosition, IngredientDefinitionHolder ingredientDefinitionHolder) {
			_ingredientSpawnPosition = ingredientSpawnPosition;
			_ingredientDefinitionHolder = ingredientDefinitionHolder;

			_spawnedIngredientObjects = new List<GameObject>();
		}

		public static void Initialize(Vector3 spawnPosition, IngredientDefinitionHolder ingredientDefinitionHolder) {
			Instance = new IngredientSpawner(spawnPosition, ingredientDefinitionHolder);
		}

		public async Task SpawnIngredientObjectAsync(IngredientType ingredientType) {
			if (!_ingredientDefinitionHolder.TryGetIngredientDefinitionByType(ingredientType, out IngredientDefinition ingredientDefinition)) {
				return;
			}

			_spawnedIngredientObjects.Add(await ingredientDefinition.IngredientPrefab.InstantiateAsync(_ingredientSpawnPosition, Quaternion.identity).Task);
		}

		public void DespawnAllIngredientObjects() {
			for (int i = _spawnedIngredientObjects.Count - 1; i >= 0; i--) {
				var spawnedIngredientObject = _spawnedIngredientObjects[i];
				var ingredientType = spawnedIngredientObject.GetComponent<IngredientBehaviour>().IngredientType;
				_spawnedIngredientObjects.Remove(spawnedIngredientObject);
				if (!_ingredientDefinitionHolder.TryGetIngredientDefinitionByType(ingredientType, out IngredientDefinition ingredientDefinition)) {
					Object.Destroy(spawnedIngredientObject);
				}
				else {
					ingredientDefinition.IngredientPrefab.ReleaseInstance(spawnedIngredientObject);
				}
			}
		}
	}
}