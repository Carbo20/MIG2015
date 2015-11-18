using UnityEngine;

public class HubController : MonoBehaviour
{
	#region Fields

	[SerializeField] private string _musicName;
	[SerializeField] private Transform _spawnPoint;

	[SerializeField] private GameObject[] _openGates;
	[SerializeField] private GameObject[] _closeGates;

	#endregion

	#region Methods

	public void Start()
	{
		AudioMgr.Instance.PlayMusic(_musicName);

		if (_spawnPoint)
			FindObjectOfType<PlayerController>().gameObject.transform.position = _spawnPoint.position;
	}

	public void Update()
	{
		
	}

	#endregion
}
