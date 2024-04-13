using PotatoFinch.LudumDare55.Orders;

namespace PotatoFinch.LudumDare55.GameEvents {
	public class NewOrderCreatedEvent : IGameEvent {
		public OrderedDrink NewOrder;
	}
}