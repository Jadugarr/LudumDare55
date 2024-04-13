using System;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace PotatoFinch.LudumDare55.Ingredients {
	public class RandomAngularVelocityOnSpawn : MonoBehaviour {
		[SerializeField] private Rigidbody2D _rigidbody;
		
		private void Awake() {
			Random random = new Random(1 + (uint)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds());
			random.NextInt(5);

			_rigidbody.angularVelocity = random.NextFloat(-359, 359);
		}
	}
}