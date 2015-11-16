using System.Collections.Generic;
using UnityEngine;

public class BootManager : MonoBehaviour
{
	static private bool _isLoaded = false;

	[SerializeField] private List<GameObject> _managerPrefabList;

	public void Awake()
	{
		gameObject.name = "BootMgr";
	}

	public void Start()
	{
		if (_isLoaded) return;

		foreach (GameObject managerPrefab in _managerPrefabList)
		{
			GameObject manager = Instantiate(managerPrefab);
			DontDestroyOnLoad(manager);
		}

		Application.LoadLevel(1);
	}
}
