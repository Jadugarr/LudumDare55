using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Extensions;
using PotatoFinch.LudumDare55.Ingredients;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameManagerBehaviour : MonoBehaviour {
		private SummoningGameInput _inputActions;

		private Random _random;
		private List<IngredientType> _randomizedIngredientTypeList;

		private void Awake() {
			_inputActions = new SummoningGameInput();
			_inputActions.Enable();
			_random = new Random(1 + (uint)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
			
			RandomizeIngredientInputs();
			AddListeners();
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
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(_randomizedIngredientTypeList[0]);
		}

		private void OnIngredient2Performed(InputAction.CallbackContext _) {
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(_randomizedIngredientTypeList[1]);
		}

		private void OnIngredient3Performed(InputAction.CallbackContext _) {
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(_randomizedIngredientTypeList[2]);
		}

		private void OnIngredient4Performed(InputAction.CallbackContext _) {
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(_randomizedIngredientTypeList[3]);
		}

		private void OnDiscardPerformed(InputAction.CallbackContext _) {
			IngredientSpawner.Instance.DespawnAllIngredientObjects();
		}
	}
}