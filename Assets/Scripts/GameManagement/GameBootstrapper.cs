using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class GameBootstrapper : MonoBehaviour {
		[SerializeField] private GameLanguageConfig _gameLanguageConfig;
		
		private void Awake() {
			GameEventManager.Initialize();
			GameLocalizationSingleton.Initialize(_gameLanguageConfig);

			SceneManager.LoadScene("MainMenu");
		}
	}
}