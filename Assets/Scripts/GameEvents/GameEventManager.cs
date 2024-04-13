using System;
using System.Collections.Generic;

namespace PotatoFinch.LudumDare55.GameEvents {
	public class GameEventManager {

		public static GameEventManager Instance { get; private set; }

		private Dictionary<Type, List<Delegate>> _listeners = new();

		public static void Initialize() {
			Instance = new GameEventManager();
		}

		private GameEventManager() { }

		public void AddListener<T>(Action<T> listener) where T : IGameEvent {
			if (!_listeners.TryGetValue(typeof(T), out List<Delegate> listeners)) {
				listeners = new List<Delegate> { listener };
				_listeners.Add(typeof(T), listeners);
			}

			if (listeners.Contains(listener)) {
				return;
			}
			
			listeners.Add(listener);
		}

		public void RemoveListener<T>(Action<T> listener) where T : IGameEvent {
			if (!_listeners.TryGetValue(typeof(T), out List<Delegate> listeners)) {
				return;
			}

			if (!listeners.Contains(listener)) {
				return;
			}

			listeners.Remove(listener);
		}

		public void SendEvent<T>(T eventData) where T : IGameEvent {
			if (!_listeners.TryGetValue(typeof(T), out List<Delegate> listeners)) {
				return;
			}

			for (int i = listeners.Count - 1; i >= 0; i--) {
				(listeners[i] as Action<T>)?.Invoke(eventData);
			}
		}
	}
}