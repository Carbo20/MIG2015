using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
	#region Fields

	private List<AudioSource> _audioSource;
	private Dictionary<AudioSource, float> _originalVolumes = new Dictionary<AudioSource, float>();

	#endregion

	#region Properties

	public List<AudioSource> AudioSource
	{
		get { return _audioSource; }
	}

	#endregion

	#region Methods

	public void Awake()
	{
		_audioSource = new List<AudioSource>(gameObject.GetComponents<AudioSource>());

		foreach (AudioSource audioSource in _audioSource)
			_originalVolumes.Add(audioSource, audioSource.volume);
	}

	public virtual void ChangeVolume(float volume)
	{
		foreach (AudioSource audioSource in _audioSource)
		{
			audioSource.volume = _originalVolumes[audioSource]*volume;
		}
	}

	#endregion
}