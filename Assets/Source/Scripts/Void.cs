using UnityEngine;

public class Void : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerHealth _))
		{
			SceneReloader.Instance.ReloadScene();
		}
	}
}
