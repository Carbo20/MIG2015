using System.Collections.Generic;
using UnityEngine;

public sealed class AudioMgr : MonoSingleton<AudioMgr>
{
	#region Fields

	private float _masterVolume = 1f;

	[SerializeField] private AudioController _musicController;

	#endregion

	#region Constructors/Destructor

	protected AudioMgr() {}

	#endregion

	#region Properties

	public float MasterVolume
	{
		get
		{
			return _masterVolume;
		}
		set
		{
			_masterVolume = value;
			UpdateMasterVolume();
		}
	}

	#endregion

	#region Methods

	public void Awake()
	{
		gameObject.name = "AudioMgr";
	}

	public void Start()
	{
	}

	public void UpdateMasterVolume()
	{
		_musicController.ChangeVolume(_masterVolume);

		List<AudioController> _audioControllerList = new List<AudioController>(FindObjectsOfType<AudioController>());

		foreach (AudioController audioController in _audioControllerList)
			audioController.ChangeVolume(_masterVolume);
	}

	#endregion
}