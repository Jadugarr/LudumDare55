using System;
using PotatoFinch.LudumDare55.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class ChangeLanguageButtonBehaviour : MonoBehaviour {
		[SerializeField] private LocalizedTextfield _textfield;
		[SerializeField] private Button _button;
		[SerializeField] private LocalizationKey _selectedLanguageKey;

		private void Awake() {
			_button.onClick.AddListener(OnButtonClicked);
			DisplaySelectedLanguage();
		}

		private void OnDestroy() {
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked() {
			LanguageCodeValue[] availableLanguageCodes = Enum.GetValues(typeof(LanguageCodeValue)) as LanguageCodeValue[];
			if (availableLanguageCodes == null) {
				Debug.Log("Null!");
				return;
			}

			int currentLanguage = (int)GameLocalizationSingleton.Instance.CurrentLanguageCode + 1;
			if (currentLanguage >= availableLanguageCodes.Length) {
				currentLanguage = 0;
			}

			GameLocalizationSingleton.Instance.ChangeLanguage((LanguageCodeValue)currentLanguage);
			DisplaySelectedLanguage();
		}

		private void DisplaySelectedLanguage() {
			var gameLocalizationSingleton = GameLocalizationSingleton.Instance;
			if (!gameLocalizationSingleton.TryGetLanguageNameByValue(gameLocalizationSingleton.CurrentLanguageCode, out string languageName)) {
				return;
			}

			_textfield.LocalizeTextWithPlaceholders(_selectedLanguageKey, languageName);
		}
	}
}