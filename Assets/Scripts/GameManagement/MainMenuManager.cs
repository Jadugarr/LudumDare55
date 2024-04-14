using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class MainMenuManager : MonoBehaviour {
		[SerializeField] private Button _startGameButton;
		[SerializeField] private Button _quitGameButton;

		private void OnEnable() {
			_startGameButton.onClick.AddListener(OnStartGameButtonClicked);
			_quitGameButton.onClick.AddListener(OnQuitGameButtonClicked);
		}

		private void OnDisable() {
			_startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
			_quitGameButton.onClick.RemoveListener(OnQuitGameButtonClicked);
		}

		private void OnStartGameButtonClicked() {
			SceneManager.LoadScene("GameScene");
		}

		private void OnQuitGameButtonClicked() {
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}