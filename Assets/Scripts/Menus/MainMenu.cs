using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private string _musicName;

	[SerializeField] private Button _playButton;
	[SerializeField] private Button _quitButton;

	[SerializeField] private int _playSceneId;

	public void Start()
	{
		AudioMgr.Instance.PlayMusic(_musicName);
	}

	public void Play()
	{
		Application.LoadLevel(_playSceneId);
	}
}