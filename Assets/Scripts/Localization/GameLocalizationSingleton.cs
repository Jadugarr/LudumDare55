using System.Collections.Generic;
using PotatoFinch.LudumDare55.GameEvents;
using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	public class GameLocalizationSingleton {
		private static GameLocalizationSingleton _instance;

		public static GameLocalizationSingleton Instance => _instance;

		public LanguageCodeValue CurrentLanguageCode => _currentLanguageCode;

		private LanguageCodeValue _currentLanguageCode = LanguageCodeValue.En;

		private GameLanguageConfig _gameLanguageConfig;

		private Dictionary<LanguageCodeValue, string> _languageCodeToNameMap = new() {
			{ LanguageCodeValue.En, "En" },
			{ LanguageCodeValue.De, "De" },
			{ LanguageCodeValue.Pt, "Pt" },
		};

		public static void Initialize(GameLanguageConfig gameLanguageConfig) {
			_instance = new GameLocalizationSingleton(gameLanguageConfig);
		}

		private GameLocalizationSingleton(GameLanguageConfig gameLanguageConfig) {
			_gameLanguageConfig = gameLanguageConfig;
		}

		public string GetLocalizedText(LocalizationKey localizationKey) {
			if (!localizationKey.TryGetTranslation(_currentLanguageCode, out string translation)) {
				Debug.LogError($"No translation defined for {localizationKey.name} for language {_currentLanguageCode}!");
				return string.Empty;
			}

			return translation;
		}

		public void ChangeLanguage(LanguageCodeValue languageCodeValue) {
			if (_currentLanguageCode == languageCodeValue) {
				return;
			}

			_currentLanguageCode = languageCodeValue;
			GameEventManager.Instance.SendEvent(new LanguageChangedEvent());
		}

		public bool TryGetConfigByLanguageCode(LanguageCodeValue languageCodeValue, out LanguageConfigData languageConfigData) {
			return _gameLanguageConfig.TryGetConfigByLanguageCode(languageCodeValue, out languageConfigData);
		}

		public bool TryGetLanguageNameByValue(LanguageCodeValue languageCodeValue, out string name) {
			return _languageCodeToNameMap.TryGetValue(languageCodeValue, out name);
		}
	}
}