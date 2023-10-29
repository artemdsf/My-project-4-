using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 5.0f;
	[SerializeField] private float _jumpForce = 5.0f;
	[SerializeField] private Vector3 _groundCheckerOffset;
	[SerializeField] private Vector3 _groundCheckerSize;
	[SerializeField] private LayerMask _groundMask;
	[SerializeField] private SceneReloader _sceneReloader;
	[SerializeField] private string _obstacleTag;

	private Vector3 _scale;
	private Rigidbody2D _rigidbody2D;
	private bool _isGrounded;

	private void Awake()
	{		
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_scale = transform.localScale;
	}

	private void Update()
	{
		MovePlayer();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(_obstacleTag))
		{
			_sceneReloader.ReloadScene();
		}
	}

	private void MovePlayer()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");

		_rigidbody2D.velocity = new Vector2(horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);

		if (horizontalInput < 0)
		{
			transform.localScale = new Vector3(-_scale.x, _scale.y, _scale.z);
		}
		else if (horizontalInput > 0)
		{
			transform.localScale = _scale;
		}

		_isGrounded = false;

		RaycastHit2D[] hits2D = Physics2D.BoxCastAll(transform.position + _groundCheckerOffset, _groundCheckerSize, 0, Vector2.zero, 0, _groundMask);

		if (hits2D.Length > 0)
		{
			_isGrounded = true;
		}

		if (Input.GetButtonDown("Jump") && _isGrounded)
		{
			_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireCube(transform.position + _groundCheckerOffset, _groundCheckerSize);
	}
}
