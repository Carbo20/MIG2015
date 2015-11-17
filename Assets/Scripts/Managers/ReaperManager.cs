using UnityEngine;
using System.Collections;

public class ReaperManager : MonoBehaviour {

	private float deltaTime = 0f;
	private bool isActive;

	private Animator animator;

	// Use this for initialization
	void Start () {
		isActive = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (deltaTime >= 5) {
			onAppear();
			deltaTime = 0;
		}
	}

	public void onAppear()
	{
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		transform.position = new Vector3 (playerPosition.x - 1,playerPosition.y,playerPosition.z - 1);

	}

	public void onTalk()
	{
		if (isActive) {
			animator.SetBool("isDead", true);
		}
	}

	public void DestroyOnAnimation(){
		Destroy (gameObject);
	}
}
