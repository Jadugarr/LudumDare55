using PotatoFinch.LudumDare55.Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class DiscardIngredientsButtonBehaviour : MonoBehaviour {
		[SerializeField] private Button _button;

		private void OnEnable() {
			_button.onClick.AddListener(OnDiscardButtonClicked);
		}

		private void OnDisable() {
			_button.onClick.RemoveListener(OnDiscardButtonClicked);
		}

		private void OnDiscardButtonClicked() {
			IngredientSpawner.Instance.DespawnAllIngredientObjects();
		}
	}
}