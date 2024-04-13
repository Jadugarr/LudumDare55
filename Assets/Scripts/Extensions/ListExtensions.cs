using System.Collections.Generic;
using Unity.Mathematics;

namespace PotatoFinch.LudumDare55.Extensions {
	public static class ListExtensions {
		public static void Shuffle<T>(this List<T> list, Random random) {
			int n = list.Count;
			while (n > 1) {
				n--;
				int k = random.NextInt(n + 1);
				(list[k], list[n]) = (list[n], list[k]);
			}
		}
	}
}