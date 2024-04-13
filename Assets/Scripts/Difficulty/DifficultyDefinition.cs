using UnityEngine;

namespace PotatoFinch.LudumDare55.Difficulty {
	[CreateAssetMenu(fileName = "DifficultyDefinition", menuName = "ScriptableObjects/DifficultyDefinition", order = 0)]
	public class DifficultyDefinition : ScriptableObject {
		[SerializeField] private DifficultyData[] _difficulties;

		public DifficultyData[] Difficulties => _difficulties;

		public bool TryGetDifficultyDataBySuccessfulDrinkAmount(int successfulDrinks, out DifficultyData difficultyData) {
			difficultyData = default;
			int remainingDrinks = successfulDrinks;

			foreach (var currentDifficulty in _difficulties) {
				remainingDrinks -= currentDifficulty.SuccessfulDrinksToClear;

				if (remainingDrinks < 0) {
					difficultyData = currentDifficulty;
					return true;
				}
			}

			return false;
		}
	}
}