﻿using System;
using PotatoFinch.LudumDare55.Ingredients;
using PotatoFinch.LudumDare55.Orders;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameInitializer : MonoBehaviour {
		[SerializeField] private IngredientDefinition[] _ingredientDefinitions;
		[SerializeField] private Transform _ingredientSpawnPoint;

		private void Awake() {
			Random random = new Random(1 + (uint)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
			
			IngredientDefinitionHolder ingredientDefinitionHolder = new IngredientDefinitionHolder(_ingredientDefinitions);
			OrderManager.Initialize(ingredientDefinitionHolder, random);
			
			IngredientSpawner.Initialize(_ingredientSpawnPoint.position, ingredientDefinitionHolder);
		}
	}
}