using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Difficulty;
using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Ingredients;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.Orders {
	public class OrderManager {
		public static OrderManager Instance { get; private set; }

		public DifficultyData CurrentDifficulty => _currentDifficulty;

		private DifficultyDefinition _difficultyDefinition;
		
		private Random _random;
		private DifficultyData _currentDifficulty;
		private OrderedDrink _currentOrder;
		private int _currentClearedDrinks;
		private GameWonEvent _gameWonEvent = new();

		private OrderManager(Random random, DifficultyDefinition difficultyDefinition) {
			_difficultyDefinition = difficultyDefinition;
			_random = random;
		}

		public static void Initialize(Random random, DifficultyDefinition difficultyDefinition) {
			Instance = new OrderManager(random, difficultyDefinition);
		}

		public void GenerateOrder() {
			if (!_difficultyDefinition.TryGetDifficultyDataBySuccessfulDrinkAmount(_currentClearedDrinks, out _currentDifficulty)) {
				GameEventManager.Instance.SendEvent(_gameWonEvent);
				return;
			}
			
			List<IngredientType> orderedIngredients = new List<IngredientType>(_currentDifficulty.NeededIngredients);
			int possibleIngredientTypeAmount = Enum.GetValues(typeof(IngredientType)).Length;

			for (int i = 0; i < _currentDifficulty.NeededIngredients; i++) {
				IngredientType randomType = (IngredientType)_random.NextInt(0, possibleIngredientTypeAmount);
				orderedIngredients.Add(randomType);
			}

			_currentOrder = new OrderedDrink(orderedIngredients);
			GameEventManager.Instance.SendEvent(new NewOrderCreatedEvent { NewOrder = _currentOrder });
		}

		public bool CheckOrder(OrderedDrink generatedDrink) {
			var isSameDrink = _currentOrder.IsSameDrink(generatedDrink);

			if (isSameDrink) {
				_currentClearedDrinks += 1;
			}
			
			return isSameDrink;
		}

		public void Reset() {
			_currentClearedDrinks = 0;
		}
	}
}