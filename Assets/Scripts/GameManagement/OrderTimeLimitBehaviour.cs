using PotatoFinch.LudumDare55.GameEvents;
using PotatoFinch.LudumDare55.Orders;
using PotatoFinch.LudumDare55.UiComponents;
using UnityEngine;

namespace PotatoFinch.LudumDare55.GameManagement {
	public class OrderTimeLimitBehaviour : MonoBehaviour {
		[SerializeField] private OrderTimeLimitDisplay _orderTimeLimitDisplay;
		
		private float _totalTime;
		private float _currentTime;
		private bool _gameRunning;

		public void Initialize() {
			GameEventManager.Instance.AddListener<NewOrderCreatedEvent>(OnNewOrderCreated);
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
				Debug.Log("Game lost!");
				_gameRunning = false;
			}

			_currentTime += Time.deltaTime;
			_orderTimeLimitDisplay.UpdateTime(_currentTime, _totalTime);
		}
	}
}