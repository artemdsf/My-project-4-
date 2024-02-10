using UnityEngine;

public class SawEnemyViewing : MonoBehaviour
{
	[SerializeField] private MoveBetweenPoints _moveBetweenPoints;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerHealth _))
		{
			_moveBetweenPoints.SetTarget(collision.transform);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerHealth _))
		{
			_moveBetweenPoints.RemoveTarget();
		}
	}
}
