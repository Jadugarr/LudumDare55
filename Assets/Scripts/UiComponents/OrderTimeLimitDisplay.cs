using UnityEngine;
using UnityEngine.UI;

namespace PotatoFinch.LudumDare55.UiComponents {
	public class OrderTimeLimitDisplay : MonoBehaviour {
		[SerializeField] private Image _fillImage;
		[SerializeField] private Color _lotsOfTimeColor;
		[SerializeField] private Color _almostOutTimeColor;

		public void UpdateTime(float currentTime, float timeLimit) {
			float progress = 1f - currentTime / timeLimit;
			_fillImage.fillAmount = progress;

			_fillImage.color = progress <= 0.3f ? _almostOutTimeColor : _lotsOfTimeColor;
		}
	}
}