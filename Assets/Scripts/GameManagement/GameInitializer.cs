using System;
using PotatoFinch.LudumDare55.Difficulty;
using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Ingredients;
using PotatoFinch.LudumDare55.Orders;
using PotatoFinch.LudumDare55.UiComponents;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameInitializer : MonoBehaviour {
		[SerializeField] private IngredientDefinition[] _ingredientDefinitions;
		[SerializeField] private Transform _ingredientSpawnPoint;

		[SerializeField] private RequiredOrderDisplayBehaviour _requiredOrderDisplayBehaviour;
		[SerializeField] private DifficultyDefinition _difficultyDefinition;

		private void Awake() {
			Random random = new Random(1 + (uint)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
			random.NextInt(5);
			
			GameEventManager.Initialize();
			
			IngredientDefinitionHolder ingredientDefinitionHolder = new IngredientDefinitionHolder(_ingredientDefinitions);
			OrderManager.Initialize(random, _difficultyDefinition);
			
			IngredientSpawner.Initialize(_ingredientSpawnPoint.position, ingredientDefinitionHolder);
			
			_requiredOrderDisplayBehaviour.Initialize(ingredientDefinitionHolder);
			
			GameManagerBehaviour.Instance.StartGame();
		}
	}
}