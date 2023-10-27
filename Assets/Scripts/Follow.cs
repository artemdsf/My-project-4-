using UnityEngine;

public class Follow : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothTime = 0.3f;

	private Vector3 _velocity = Vector3.zero;

	private void LateUpdate()
	{
		Vector3 targetPosition = new(_target.position.x, _target.position.y, transform.position.z);

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
	}
}
