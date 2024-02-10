using UnityEngine;

public abstract class CharacterHealth : MonoBehaviour
{
	[SerializeField] private float _maxHealth;

	private float _health;

	public void TakeDamage(float damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			Death();
		}

		Debug.Log(_health);
	}

	public void Heal(float health)
	{
		_health += health;

		if (_health > _maxHealth)
		{
			_health = _maxHealth;
		}

		Debug.Log(_health);
	}

	protected abstract void Death();

	private void Awake()
	{
		_health = _maxHealth;
	}
}
