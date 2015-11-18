using UnityEngine;
using System.Collections.Generic;

public class TrailLevelController : MonoBehaviour
{
	[SerializeField] private string _musicName;


	public void Start()
	{

		AudioMgr.Instance.PlayMusic (_musicName);
		FindObjectOfType<PlayerController>().GetComponent<NavMeshAgent>().enabled=true;
	}
	 
	public void Update(){
		if (FindObjectsOfType<Enemy>().Length == 0) {
			//victoire
			GameMgr.Instance.LoadLevel(3);
		}
	}
}

