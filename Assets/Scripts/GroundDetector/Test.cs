using UnityEngine;

namespace GroundDetector
{
	public class Test : MonoBehaviour
	{
		[SerializeField]
		private GroundDetectorPicker _groundDetectorPicker;
		
		private void Update()
		{
			Debug.Log(_groundDetectorPicker.Value.IsGrounded);
		}
	}
}