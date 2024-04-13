using System;

namespace PotatoFinch.LudumDare55.Difficulty {
	[Serializable]
	public struct DifficultyData {
		public int NeededIngredients;
		public int SuccessfulDrinksToClear;
		public float TimeLimit;
	}
}