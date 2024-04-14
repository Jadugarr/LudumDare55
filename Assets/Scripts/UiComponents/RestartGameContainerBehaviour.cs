using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class RestartGameContainerBehaviour : MonoBehaviour {
		[SerializeField] private LocalizedTextfield _gameResultText;
		[SerializeField] private Button _restartGameButton;
		[SerializeField] private GameObject _restartElementsContainer;

		[SerializeField] private LocalizationKey _gameWonText;
		[SerializeField] private LocalizationKey _gameLostText;

		private RestartGameEvent _restartGameEvent = new();

		public void Initialize() {
			GameEventManager.Instance.AddListener<GameLostEvent>(OnGameLostEvent);
			GameEventManager.Instance.AddListener<GameWonEvent>(OnGameWonEvent);
		}

		private void OnEnable() {
			_restartElementsContainer.SetActive(false);
			_restartGameButton.onClick.AddListener(OnRestartButtonClicked);
		}

		private void OnDisable() {
			_restartGameButton.onClick.RemoveListener(OnRestartButtonClicked);
		}

		private void OnRestartButtonClicked() {
			GameEventManager.Instance.SendEvent(_restartGameEvent);
			_restartElementsContainer.SetActive(false);
		}

		private void OnGameLostEvent(GameLostEvent _) {
			_gameResultText.LocalizeText(_gameLostText);
			_restartElementsContainer.SetActive(true);
		}

		private void OnGameWonEvent(GameWonEvent _) {
			_gameResultText.LocalizeText(_gameWonText);
			_restartElementsContainer.SetActive(true);
		}
	}
}