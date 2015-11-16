using UnityEngine;

public class PauseHUD : MonoBehaviour
{
	#region Fields

	private AudioMgr _audioMgr;

	#endregion

	#region Methods

	public void Awake()
	{
		_audioMgr = AudioMgr.Instance;
	}

	public void ChangeMasterVolume(float volume)
	{
		if (!_audioMgr) return;

		_audioMgr.MasterVolume = volume;
	}

	#endregion
}