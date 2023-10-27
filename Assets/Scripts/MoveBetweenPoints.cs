using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
	[SerializeField] private Transform _startPoint;
	[SerializeField] private Transform _endPoint;
	[SerializeField] private float _moveSpeed = 2.0f;

	private bool _movingTowardsEnd = true;
	private float _startTime;
	private float _journeyLength;

	private void Start()
	{
		_startTime = Time.time;
		_journeyLength = Vector3.Distance(_startPoint.position, _endPoint.position);
	}

	private void Update()
	{
		float distanceCovered = (Time.time - _startTime) * _moveSpeed;
		float fractionOfJourney = distanceCovered / _journeyLength;

		if (_movingTowardsEnd)
		{
			transform.position = Vector3.Lerp(_startPoint.position, _endPoint.position, fractionOfJourney);
		}
		else
		{
			transform.position = Vector3.Lerp(_endPoint.position, _startPoint.position, fractionOfJourney);
		}

		if (fractionOfJourney >= 1.0f)
		{
			_movingTowardsEnd = !_movingTowardsEnd;
			_startTime = Time.time;
		}
	}
}
