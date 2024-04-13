using UnityEngine;

namespace PotatoFinch.LudumDare55.Difficulty {
	[CreateAssetMenu(fileName = "DifficultyDefinition", menuName = "ScriptableObjects/DifficultyDefinition", order = 0)]
	public class DifficultyDefinition : ScriptableObject {
		[SerializeField] private DifficultyData[] _difficulties;

		public DifficultyData[] Difficulties => _difficulties;

		public DifficultyData GetDifficultyDataBySuccessfulDrinkAmount(int successfulDrinks) {
			int remainingDrinks = successfulDrinks;

			foreach (var currentDifficulty in _difficulties) {
				remainingDrinks -= currentDifficulty.SuccessfulDrinksToClear;

				if (remainingDrinks < 0) {
					return currentDifficulty;
				}
			}

			return _difficulties[^1];
		}
	}
}