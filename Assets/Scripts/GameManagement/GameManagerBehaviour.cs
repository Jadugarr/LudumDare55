using System;
using System.Collections.Generic;
using PotatoFinch.LudumDare55.Extensions;
using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Ingredients;
using PotatoFinch.LudumDare55.Orders;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameManagerBehaviour : MonoBehaviour {
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private AudioSource _orderResultSource;
		[SerializeField] private AudioClip[] _summonSounds;
		[SerializeField] private AudioClip _correctClip;
		[SerializeField] private AudioClip _wrongClip;
		
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
			_inputActions.Summoning.QuitGame.performed += OnQuitGamePerformed;
			GameEventManager.Instance.AddListener<GameLostEvent>(OnGameLostEvent);
			GameEventManager.Instance.AddListener<GameWonEvent>(OnGameWonEvent);
			GameEventManager.Instance.AddListener<RestartGameEvent>(OnGameRestartEvent);
		}

		private void OnQuitGamePerformed(InputAction.CallbackContext _) {
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		private void RemoveListeners() {
			_inputActions.Summoning.Ingredient1.performed -= OnIngredient1Performed;
			_inputActions.Summoning.Ingredient2.performed -= OnIngredient2Performed;
			_inputActions.Summoning.Ingredient3.performed -= OnIngredient3Performed;
			_inputActions.Summoning.Ingredient4.performed -= OnIngredient4Performed;
			_inputActions.Summoning.DiscardIngredients.performed -= OnDiscardPerformed;
			_inputActions.Summoning.CheckOrder.performed -= OnCheckOrderPerformed;
			_inputActions.Summoning.QuitGame.performed -= OnQuitGamePerformed;
			GameEventManager.Instance.RemoveListener<GameLostEvent>(OnGameLostEvent);
			GameEventManager.Instance.RemoveListener<GameWonEvent>(OnGameWonEvent);
			GameEventManager.Instance.RemoveListener<RestartGameEvent>(OnGameRestartEvent);
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
			if (!_gameRunning) {
				return;
			}

			IngredientSpawner.Instance.DespawnAllIngredientObjects();
			_currentIngredients.Clear();
		}

		public void SpawnIngredientWithIndex(int index) {
			if (!_gameRunning) {
				return;
			}

			var randomizedIngredientType = _randomizedIngredientTypeList[index];
			_currentIngredients.Add(randomizedIngredientType);
			IngredientSpawner.Instance.SpawnIngredientObjectAsync(randomizedIngredientType);
			PlayRandomSummonSound();
		}

		private void OnCheckOrderPerformed(InputAction.CallbackContext _) {
			CheckOrder();
		}

		public void CheckOrder() {
			OrderedDrink currentOrder = new OrderedDrink(_currentIngredients);
			var result = OrderManager.Instance.CheckOrder(currentOrder);

			DiscardDrink();
			PlayOrderResultSound(result);
			if (!result) {
				return;
			}

			GetNewOrder();
		}

		private void OnGameLostEvent(GameLostEvent _) {
			_gameRunning = false;
		}

		private void OnGameWonEvent(GameWonEvent _) {
			_gameRunning = false;
		}

		private void OnGameRestartEvent(RestartGameEvent _) {
			_gameRunning = true;
			DiscardDrink();
			OrderManager.Instance.Reset();
			OrderManager.Instance.GenerateOrder();
		}

		private void PlayRandomSummonSound() {
			_audioSource.clip = _summonSounds[_random.NextInt(_summonSounds.Length)];
			_audioSource.Play();
		}

		private void PlayOrderResultSound(bool isCorrect) {
			_orderResultSource.clip = isCorrect ? _correctClip : _wrongClip;
			_orderResultSource.Play();
		}
	}
}