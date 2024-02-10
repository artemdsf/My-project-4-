using UnityEngine;

public class PlayerAttack : CharacterAttack
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out EnemyHealth enemyHealth))
		{
			TryAttack(enemyHealth);
		}
	}
}
