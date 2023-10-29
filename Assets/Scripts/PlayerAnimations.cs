using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	[SerializeField] private string _isRunningString = "IsRunning";

	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");

		if (horizontalInput != 0)
		{
			_animator.SetBool(_isRunningString, true);
		}
		else
		{
			_animator.SetBool(_isRunningString, false);
		}
	}
}
