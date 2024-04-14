using PotatoFinch.LudumDare55.Localization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class DescriptionManager : MonoBehaviour {
		[SerializeField] private LocalizedTextfield _descriptionText;
		[SerializeField] private string[] _textsToShow;
		[SerializeField] private LocalizationKey[] _localizationKeys;

		private int _currentTextIndex;

		private SummoningGameInput _gameInput;
		private void Awake() {
			_gameInput = new SummoningGameInput();
			_gameInput.Enable();
			
			_gameInput.Summoning.NextDescription.performed += OnNextDescriptionPerformed;
			ShowText(_currentTextIndex);
		}

		private void OnDestroy() {
			_gameInput.Summoning.NextDescription.performed -= OnNextDescriptionPerformed;
		}

		private void OnNextDescriptionPerformed(InputAction.CallbackContext _) {
			_currentTextIndex++;

			if (_currentTextIndex >= _localizationKeys.Length) {
				SceneManager.LoadScene("GameScene");
				return;
			}
			
			ShowText(_currentTextIndex);
		}

		private void ShowText(int index) {
			_descriptionText.LocalizeText(_localizationKeys[index]);
		}
	}
}