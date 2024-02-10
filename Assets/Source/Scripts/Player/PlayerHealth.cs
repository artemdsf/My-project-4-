public class PlayerHealth : CharacterHealth
{
	protected override void Death()
	{
		SceneReloader.Instance.ReloadScene();
	}
}
