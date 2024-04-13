using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	[CreateAssetMenu(fileName = "LocalizationKey", menuName = "ScriptableObjects/Localization/Key")]
	public class LocalizationKey : ScriptableObject {
		[SerializeField] private LocalizationData[] _localizationDatas;

		public bool TryGetTextByLanguageCode(LanguageCode languageCode, out string localizedText) {
			localizedText = string.Empty;
			
			foreach (var localizationData in _localizationDatas) {
				if (localizationData.LanguageCode != languageCode) {
					continue;
				}

				localizedText = localizationData.Text;
				return true;
			}

			Debug.LogError($"No localization defined for language {languageCode} in key {name}");
			return false;
		}
	}
}