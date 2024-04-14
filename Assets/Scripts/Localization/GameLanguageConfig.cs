using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	[CreateAssetMenu(fileName = "GameLanguageConfig", menuName = "ScriptableObjects/Localization/GameLanguageConfig", order = 0)]
	public class GameLanguageConfig : ScriptableObject {
		[SerializeField] private LanguageConfigData[] _languageConfigDatas;

		public bool TryGetConfigByLanguageCode(LanguageCodeValue languageCodeValue, out LanguageConfigData languageConfigData) {
			languageConfigData = default;

			foreach (LanguageConfigData currentLanguageConfigData in _languageConfigDatas) {
				if (currentLanguageConfigData.LanguageCode != languageCodeValue) continue;
				languageConfigData = currentLanguageConfigData;
				return true;
			}

			return false;
		}
	}
}