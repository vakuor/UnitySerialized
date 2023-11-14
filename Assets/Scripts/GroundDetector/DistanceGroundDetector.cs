using UnityEngine;

namespace GroundDetector
{
	public class DistanceGroundDetector : MonoBehaviour, IGroundDetector
	{
		[field: SerializeField]
		public bool IsGrounded { get; private set; }

		[field: SerializeField]
		private float _detectionDistance = 0.01f;
		
		private void FixedUpdate()
		{
			IsGrounded = Physics.Raycast(transform.position, Vector3.down, _detectionDistance);
		}
	}
}