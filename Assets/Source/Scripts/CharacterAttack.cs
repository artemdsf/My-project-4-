using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
	[SerializeField] private float _damage = 1;
	[SerializeField] private float _damageDelay = 0.5f;

	private float _currentDamageDelay = 0;

	protected void TryAttack(CharacterHealth characterHealth)
	{
		if (_currentDamageDelay > _damageDelay)
		{
			characterHealth.TakeDamage(_damage);
			_currentDamageDelay = 0;
		}
	}

	private void Awake()
	{
		_currentDamageDelay = _damageDelay;
	}

	private void Update()
	{
		_currentDamageDelay += Time.deltaTime;
	}
}
