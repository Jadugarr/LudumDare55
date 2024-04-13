using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Ingredients;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.Orders {
	public class OrderManager {
		public static OrderManager Instance { get; private set; }

		private IngredientDefinitionHolder _ingredientDefinitionHolder;
		private Random _random;
		private int _currentIngredientAmount;
		private int _minIngredientAmount = 1;
		private int _maxIngredientAmount = 4;
		private OrderedDrink _currentOrder;

		private OrderManager(IngredientDefinitionHolder ingredientDefinitionHolder, Random random) {
			_ingredientDefinitionHolder = ingredientDefinitionHolder;
			_random = random;
			_currentIngredientAmount = 1;
		}

		public static void Initialize(IngredientDefinitionHolder ingredientDefinitionHolder, Random random) {
			Instance = new OrderManager(ingredientDefinitionHolder, random);
		}

		public OrderedDrink GenerateOrder() {
			List<IngredientType> orderedIngredients = new List<IngredientType>(_currentIngredientAmount);
			int possibleIngredientTypeAmount = Enum.GetValues(typeof(IngredientType)).Length;

			for (int i = 0; i < _currentIngredientAmount; i++) {
				IngredientType randomType = (IngredientType)_random.NextInt(0, possibleIngredientTypeAmount);
				orderedIngredients.Add(randomType);
			}

			_currentOrder = new OrderedDrink(orderedIngredients);
			return _currentOrder;
		}

		public bool CheckOrder(OrderedDrink generatedDrink) {
			return _currentOrder.IsSameDrink(generatedDrink);
		}

		public void ChangeDifficulty(int ingredientAmountChange) {
			_currentIngredientAmount = math.clamp(_currentIngredientAmount + ingredientAmountChange, _minIngredientAmount, _maxIngredientAmount);
		}
	}
}