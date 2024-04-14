using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.Audio {
	public class PlaySoundOnClick : MonoBehaviour {
		[SerializeField] private Button _button;
		[SerializeField] private AudioSource _audioSource;

		private void OnEnable() {
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick() {
			_audioSource.Play();
		}
	}
}