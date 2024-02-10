public class EnemyHealth : CharacterHealth
{
	protected override void Death()
	{
		Destroy(gameObject);
	}
}
