using UnityEngine;
using System.Collections;

public class Level2Controller : MonoBehaviour {

	[SerializeField] private string _musicName;
	
	public void Start()
	{
		AudioMgr.Instance.PlayMusic (_musicName);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController player = FindObjectOfType<PlayerController> ();
		
		CapsuleCollider pCollider = player.GetComponent<CapsuleCollider> ();
		BoxCollider collider = GameObject.Find("WinAreaCondition").GetComponent<BoxCollider>();
		
		if (collider.bounds.Intersects (pCollider.bounds)) 
		{
			GameMgr.Instance.LoadLevel(3);
		}
	}
}
