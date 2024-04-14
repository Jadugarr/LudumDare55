using PotatoFinch.LudumDare55.GameEvents;
using TMPro;
using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	public class LocalizedTextfield : MonoBehaviour {
		[SerializeField] private TMP_Text _textfield;
		[SerializeField] private LocalizationKey _preDefinedKey;

		private LocalizationKey _currentKey;

		private void Awake() {
			AddListeners();
			
			if (_preDefinedKey == null) {
				return;
			}
			
			LocalizeText(_preDefinedKey);
		}

		private void OnDestroy() {
			RemoveListeners();
		}

		private void AddListeners() {
			GameEventManager.Instance.AddListener<LanguageChangedEvent>(OnLanguageChanged);
		}

		private void RemoveListeners() {
			GameEventManager.Instance.RemoveListener<LanguageChangedEvent>(OnLanguageChanged);
		}

		public void LocalizeText(LocalizationKey localizationKey) {
			_currentKey = localizationKey;

			LocalizeCurrentKey();
		}

		public void LocalizeTextWithPlaceholders(LocalizationKey localizationKey, params object[] placeholderValues) {
			LocalizeText(localizationKey);

			_textfield.text = string.Format(_textfield.text, placeholderValues);
		}

		public void SetUnlocalizedText(string unlocalizedText) {
			_currentKey = null;
			_textfield.text = unlocalizedText;
		}

		private void LocalizeCurrentKey() {
			if (_currentKey == null) {
				return;
			}
			
			_textfield.text = GameLocalizationSingleton.Instance.GetLocalizedText(_currentKey);
		}

		private void OnLanguageChanged(LanguageChangedEvent _) {
			LocalizeCurrentKey();
		}
	}
}