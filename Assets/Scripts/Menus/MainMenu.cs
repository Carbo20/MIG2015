using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Button _playButton;
	[SerializeField] private Button _quitButton;

	[SerializeField] private int _playSceneId;

	public void Play()
	{
		Application.LoadLevel(_playSceneId);
	}
}