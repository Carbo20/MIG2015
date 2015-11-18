using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

	[SerializeField] private int _sceneID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.transform.parent.gameObject.tag == "Player")
			GameMgr.Instance.LoadLevel(_sceneID);
	}
}
