using UnityEngine;

public class Heal : MonoBehaviour
{
	[SerializeField] private float _heal = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerHealth playerHealth))
		{
			playerHealth.Heal(_heal);
			Destroy(gameObject);
		}
	}
}
