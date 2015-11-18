using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject door4;

	private bool door1Check;
	private bool door2Check;
	private bool door3Check;
	private bool door4Check;

	// Use this for initialization
	void Start () {
		door1Check = false;
		door2Check = false;
		door3Check = false;
		door4Check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (door1.GetComponent<BoxCollider> ().enabled) {
			checkDoorUnclock1 ();
		}
		if (door2.GetComponent<BoxCollider> ().enabled && door1Check == true) {
			checkDoorUnclock2 ();
		}
		if (door3Check == true) {
			checkDoorUnclock3 ();
		}
		if (door4Check == true) {
			checkDoorUnclock4 ();
		}
	}

	private void checkDoorUnclock1(){
		if (GameObject.FindGameObjectWithTag ("Candle").transform.parent.GetComponent<CandleManager> ().LightOn) {
			door1.transform.rotation = Quaternion.Euler(0,180,0);
			door1Check = true;
		}
	}

	private void checkDoorUnclock2(){
		if (door2Check == true) {
			door2.transform.rotation = Quaternion.Euler(0,180,0);
		}
	}

	private void checkDoorUnclock3(){
		if (door3Check == true) {
			door3.transform.rotation = Quaternion.Euler(0,180,0);
		}
	}

	private void checkDoorUnclock4(){
		if (door4Check == true) {
			door4.transform.rotation = Quaternion.Euler(0,180,0);
		}
	}

	public void onTalk()
	{
		PlayerController player = FindObjectOfType<PlayerController> ();

		CapsuleCollider pCollider = player.GetComponent<CapsuleCollider> ();
		BoxCollider collider = GameObject.Find("TalkArea").GetComponent<BoxCollider>();

		if (collider.bounds.Intersects (pCollider.bounds)) 
		{
			door2Check = true;
		}
	}

	public void onClap()
	{
		if(GameObject.Find("OrangeGhost") == null){
			Debug.Log("ALLOO");
			door3Check = true;
		}
	}

	public void onBlow()
	{
		if(GameObject.Find("RedGhost") == null){
			door4Check = true;
		}
	}
}
