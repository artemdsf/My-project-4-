using System.Collections;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
	[SerializeField] private Transform _startPoint;
	[SerializeField] private Transform _endPoint;
	[SerializeField] private float _moveSpeed = 2.0f;

	private Transform _lastTarget;
	private bool _isMoving = true;
	private bool _movingBetween = true;

	public void SetTarget(Transform target)
	{
		_movingBetween = false;
		MoveTo(target);
	}

	public void RemoveTarget()
	{
		_movingBetween = true;
	}

	private void Start()
	{
		transform.position = _startPoint.position;
	}

	private void Update()
	{
		if (_movingBetween)
		{
			if (_isMoving == false)
			{
				_isMoving = true;
				_lastTarget = MoveTo(_lastTarget);
			}
			
			if (transform.position == _startPoint.position)
			{
				_lastTarget = MoveTo(_endPoint);
			}
			else if (transform.position == _endPoint.position)
			{
				_lastTarget = MoveTo(_startPoint);
			}
		}
		else
		{
			_isMoving = false;
		}
	}

	private Transform MoveTo(Transform targetTransform)
	{
		StartCoroutine(LerpMove(targetTransform, _movingBetween));
		return targetTransform;
	}

	private IEnumerator LerpMove(Transform targetTransform, bool isMovingBetween)
	{
		while (_movingBetween == isMovingBetween)
		{
			float distanceToTarget = (targetTransform.position - transform.position).magnitude;
			Vector3 move = (targetTransform.position - transform.position).normalized * _moveSpeed * Time.deltaTime;

			if (distanceToTarget > move.magnitude)
			{
				transform.Translate(move);
			}
			else if (_movingBetween)
			{
				transform.position = targetTransform.position;
				yield break;
			}

			yield return null;
		}
	}
}
