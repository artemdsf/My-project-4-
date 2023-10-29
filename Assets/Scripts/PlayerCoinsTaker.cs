using TMPro;
using UnityEngine;

public class PlayerCoinsTaker : MonoBehaviour
{
	[SerializeField] private string _coinTag;
	[SerializeField] private string _coinText = "Монеты: ";
	[SerializeField] private TMP_Text _coinsCountText;

	private int _coinsCount;

	private void Start()
	{
		_coinsCount = 0;
		DisplayCoinsCount();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(_coinTag))
		{
			collision.gameObject.SetActive(false);

			_coinsCount++;

			DisplayCoinsCount();
		}
	}

	private void DisplayCoinsCount()
	{
		_coinsCountText.text = _coinText + _coinsCount;
	}
}
