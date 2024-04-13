using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Extensions;
using PotatoFinch.LudumDare55.Ingredients;
using PotatoFinch.LudumDare55.Orders;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameManagerBehaviour : MonoBehaviour {
		public static GameManagerBehaviour Instance => _instance;
		private static GameManagerBehaviour _instance;

		private SummoningGameInput _inputActions;

		private Random _random;
		private List<IngredientType> _randomizedIngredientTypeList;

		private List<IngredientType> _currentIngredients = new();

		private bool _gameRunning;

		public void StartGame() {
			_inputActions = new SummoningGameInput();
			_inputActions.Enable();
			_random = new Random(1 + (uint)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
			AddListeners();

			RandomizeIngredientInputs();
			GetNewOrder();

			_gameRunning = true;
		}

		private void GetNewOrder() {
			OrderManager.Instance.GenerateOrder();
		}

		private void Awake() {
			_instance = this;
		}

		private void OnDestroy() {
			RemoveListeners();
		}

		private void AddListeners() {
			_inputActions.Summoning.Ingredient1.performed += OnIngredient1Performed;
			_inputActions.Summoning.Ingredient2.performed += OnIngredient2Performed;
			_inputActions.Summoning.Ingredient3.performed += OnIngredient3Performed;
			_inputActions.Summoning.Ingredient4.performed += OnIngredient4Performed;
			_inputActions.Summoning.DiscardIngredients.performed += OnDiscardPerformed;
			_inputActions.Summoning.CheckOrder.performed += OnCheckOrderPerformed;
		}

		private void RemoveListeners() {
			_inputActions.Summoning.Ingredient1.performed -= OnIngredient1Performed;
			_inputActions.Summoning.Ingredient2.performed -= OnIngredient2Performed;
			_inputActions.Summoning.Ingredient3.performed -= OnIngredient3Performed;
			_inputActions.Summoning.Ingredient4.performed -= OnIngredient4Performed;
			_inputActions.Summoning.DiscardIngredients.performed -= OnDiscardPerformed;
		}

		private void RandomizeIngredientInputs() {
			IngredientType[] values = Enum.GetValues(typeof(IngredientType)) as IngredientType[];
			_randomizedIngredientTypeList = new List<IngredientType>(values);

			_randomizedIngredientTypeList.Shuffle(_random);
		}

		private void OnIngredient1Performed(InputAction.CallbackContext _) {
			SpawnIngredientWithIndex(0);
		}

		private void OnIngredient2Performed(InputAction.CallbackContext _) {
			SpawnIngredientWithIndex(1);
		}

		private void OnIngredient3Performed(InputAction.CallbackContext _) {
			SpawnIngredientWithIndex(2);
		}

		private void OnIngredient4Performed(InputAction.CallbackContext _) {
			SpawnIngredientWithIndex(3);
		}

		private void OnDiscardPerformed(InputAction.CallbackContext _) {
			DiscardDrink();
		}

		private void DiscardDrink() {
			IngredientSpawner.Instance.DespawnAllIngredientObjects();
			_currentIngredients.Clear();
		}

		public void SpawnIngredientWithIndex(int index) {
			var randomizedIngredientType = _randomizedIngredientTypeList[index];
			_currentIngredients.Add(randomizedIngredientType);
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(randomizedIngredientType);
		}

		private void OnCheckOrderPerformed(InputAction.CallbackContext _) {
			OrderedDrink currentOrder = new OrderedDrink(_currentIngredients);
			var result = OrderManager.Instance.CheckOrder(currentOrder);

			DiscardDrink();
			if (!result) {
				return;
			}
			
			GetNewOrder();
		}
	}
}