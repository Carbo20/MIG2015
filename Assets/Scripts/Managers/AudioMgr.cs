using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public sealed class AudioMgr : MonoSingleton<AudioMgr>
{
	#region Fields

	private float _masterVolume = 1f;

	[SerializeField] private GameObject _sfxPlayerPrefab;
	[SerializeField] private AudioController _musicController;

	#endregion

	#region Constructors/Destructor

	protected AudioMgr()
	{
	}

	#endregion

	#region Properties

	public float MasterVolume
	{
		get { return _masterVolume; }
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

	public void UpdateMasterVolume()
	{
		_musicController.ChangeVolume(_masterVolume);

		List<AudioController> _audioControllerList = new List<AudioController>(FindObjectsOfType<AudioController>());

		foreach (AudioController audioController in _audioControllerList)
			audioController.ChangeVolume(_masterVolume);
	}

	public void PlayMusic(string musicName)
	{
		AudioClip clip = Resources.Load("Audios/Musics/" + musicName) as AudioClip;

		if (!clip) return;

		AudioSource source = _musicController.GetComponent<AudioSource>();

		if (!source) return;

		source.Stop();
		source.clip = clip;
		source.Play();
	}

	public void PlaySFX(string sfxName)
	{
		AudioClip sfx = Resources.Load("Audios/SFXs/" + sfxName) as AudioClip;

		if (!sfx) return;

		GameObject sfxPlayer = Instantiate(_sfxPlayerPrefab);

		AudioSource audioSource = sfxPlayer.GetComponent<AudioSource>();

		if (!audioSource) return;

		audioSource.clip = sfx;
		audioSource.Play();

		StartCoroutine("SFXCoroutine", audioSource);
	}

	IEnumerator SFXCoroutine(AudioSource source)
	{
		yield return new WaitForSeconds(source.clip.length);

		Destroy(source.gameObject);
	} 

	#endregion
}