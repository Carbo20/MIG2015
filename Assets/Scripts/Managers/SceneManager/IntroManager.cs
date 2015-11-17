using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (door1.GetComponent<BoxCollider> ().enabled) {
			checkDoorUnclock1 ();
		}
		if (door2.GetComponent<BoxCollider> ().enabled) {
			checkDoorUnclock2 ();
		}
		if (door3.GetComponent<BoxCollider> ().enabled) {
			checkDoorUnclock3 ();
		}

	}

	private void checkDoorUnclock1(){
		if (GameObject.FindGameObjectWithTag ("Candle").transform.parent.GetComponent<CandleManager> ().LightOn) {
			door1.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void checkDoorUnclock2(){
		if (GameObject.FindGameObjectWithTag ("Candle").transform.parent.GetComponent<CandleManager> ().LightOn) {
			door1.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void checkDoorUnclock3(){
		if (GameObject.FindGameObjectWithTag ("Candle").transform.parent.GetComponent<CandleManager> ().LightOn) {
			door1.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
