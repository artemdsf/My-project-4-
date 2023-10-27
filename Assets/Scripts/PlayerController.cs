using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 5.0f;
	[SerializeField] private string _isRunningString = "IsRunning";
	[SerializeField] private float _jumpForce = 5.0f;
	[SerializeField] private Vector3 _groundCheckerOffset;
	[SerializeField] private Vector3 _groundCheckerSize;
	[SerializeField] private LayerMask _groundMask;
	[SerializeField] private SceneReloader _sceneReloader;
	[SerializeField] private string _obstacleTag;
	[SerializeField] private string _coinTag;
	[SerializeField] private string _coinText = "Монеты: ";
	[SerializeField] private TMP_Text _coinsCountText;

	private Animator _animator;
	private Vector3 _scale;
	private Rigidbody2D _rigidbody2D;
	private bool _isGrounded;
	private int _coinsCount;

	private void Awake()
	{		
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_scale = transform.localScale;
		_coinsCount = 0;
	}

	private void Start()
	{
		DisplayCoinsCount();
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

		if (collision.CompareTag(_coinTag))
		{
			collision.gameObject.SetActive(false);

			_coinsCount++;

			DisplayCoinsCount();
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

		if (horizontalInput != 0)
		{
			_animator.SetBool(_isRunningString, true);
		}
		else
		{
			_animator.SetBool(_isRunningString, false);
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

	private void DisplayCoinsCount()
	{
		_coinsCountText.text = _coinText + _coinsCount;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireCube(transform.position + _groundCheckerOffset, _groundCheckerSize);
	}
}
