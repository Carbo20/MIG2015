using UnityEngine;
using System.Collections;

public class ReaperManager : MonoBehaviour {

	private float deltaTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (deltaTime >= 5) {
			onAppear();
		}

	}

	public void onAppear()
	{
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		transform.position = new Vector3 (playerPosition.x - 1,playerPosition.y,playerPosition.z - 1);

	}

}
