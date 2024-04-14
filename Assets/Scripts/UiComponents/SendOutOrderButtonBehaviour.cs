using PotatoFinch.LudumDare55.GameManagement;
using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class SendOutOrderButtonBehaviour : MonoBehaviour {
		[SerializeField] private Button _button;

		private void OnEnable() {
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonClicked);
		}
		
		private void OnButtonClicked() {
			GameManagerBehaviour.Instance.CheckOrder();
		}
	}
}