using UnityEngine;

public class EnemyAttack : CharacterAttack
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerHealth playerHealth))
		{
			TryAttack(playerHealth);
		}
	}
}
