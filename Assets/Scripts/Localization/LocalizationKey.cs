using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	[CreateAssetMenu(fileName = "LocalizationKey", menuName = "ScriptableObjects/Localization/LocalizationKey", order = 0)]
	public class LocalizationKey : ScriptableObject {
		[SerializeField] private TranslationData[] _translations;

		public bool TryGetTranslation(LanguageCodeValue languageCodeValue, out string translation) {
			translation = string.Empty;

			foreach (var translationData in _translations) {
				if (translationData.LanguageCodeValue != languageCodeValue) continue;
				translation = translationData.Translation;
				return true;
			}

			return false;
		}
	}
}