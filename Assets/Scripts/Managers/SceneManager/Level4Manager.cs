using UnityEngine;
using System.Collections;

public class Level4Manager : MonoBehaviour {

	private float timeBeforeReaper;
	private float deltaTime;

	// Use this for initialization
	void Start () {
		deltaTime = 0f;
		timeBeforeReaper = Random.Range (5, 10);
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (deltaTime >= timeBeforeReaper) {
			if(GameObject.Find("Reaper") == null){
				GameObject reaper = Resources.Load("Prefabs/Character/Reaper")as GameObject;
				Instantiate(reaper);
				reaper.GetComponent<ReaperManager>().onAppear();
			}
			deltaTime = 0;
			timeBeforeReaper = Random.Range (5,10);
		}
	}
}
