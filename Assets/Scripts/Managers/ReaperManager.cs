using UnityEngine;
using System.Collections;

public class ReaperManager : MonoBehaviour {

	private float deltaTime = 0f;
	private bool isActive;

	private Animator animator;

	// Use this for initialization
	void Start () {
		isActive = true;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void onAppear()
	{
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		transform.position = new Vector3 (playerPosition.x - 1,playerPosition.y,playerPosition.z - 1);
		AudioMgr.Instance.PlaySFX ("Reaper_Spawn");

	}

	public void onTalk()
	{
		if (isActive) {
			Debug.Log("REAPER DIE");
			animator.SetBool("isDead", true);
		}
	}

	public void DestroyOnAnimation(){
		Destroy (gameObject);
		AudioMgr.Instance.PlaySFX ("Reaper_Disapear");
		
	}
}
