using UnityEngine;

namespace PotatoFinch.LudumDare55.Localization {
	public class GameLocalizationSingletonInitializer : MonoBehaviour {
		[SerializeField] private GameLanguageConfig _gameLanguageConfig;
		
		public void Awake() {
			GameLocalizationSingleton.Initialize(_gameLanguageConfig);
		}
	}
}