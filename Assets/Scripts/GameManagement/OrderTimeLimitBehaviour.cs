using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Orders;
using PotatoFinch.LudumDare55.UiComponents;
using UnityEngine;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class OrderTimeLimitBehaviour : MonoBehaviour {
		[SerializeField] private OrderTimeLimitDisplay _orderTimeLimitDisplay;
		[SerializeField] private AudioSource _outOfTimeAudio;
		
		private float _totalTime;
		private float _currentTime;
		private bool _gameRunning;
		private GameLostEvent _gameLostEvent = new();

		public void Initialize() {
			GameEventManager.Instance.AddListener<NewOrderCreatedEvent>(OnNewOrderCreated);
			GameEventManager.Instance.AddListener<GameWonEvent>(OnGameWonEvent);
		}

		private void OnGameWonEvent(GameWonEvent _) {
			_gameRunning = false;
			PlayOutOfTimeSound(false);
		}

		private void OnNewOrderCreated(NewOrderCreatedEvent _) {
			_totalTime = OrderManager.Instance.CurrentDifficulty.TimeLimit;
			_currentTime = 0f;
			_gameRunning = true;
		}

		private void Update() {
			if (!_gameRunning) {
				return;
			}

			if (_currentTime >= _totalTime) {
				GameEventManager.Instance.SendEvent(_gameLostEvent);
				PlayOutOfTimeSound(false);
				_gameRunning = false;
				return;
			}

			_currentTime += Time.deltaTime;
			_orderTimeLimitDisplay.UpdateTime(_currentTime, _totalTime);
			PlayOutOfTimeSound(1f - _currentTime / _totalTime <= 0.3f);
		}

		private void PlayOutOfTimeSound(bool shouldPlay) {
			if (_outOfTimeAudio.isPlaying && !shouldPlay) {
				_outOfTimeAudio.Stop();
			}

			if (!_outOfTimeAudio.isPlaying && shouldPlay) {
				_outOfTimeAudio.Play();
			}
		}
	}
}