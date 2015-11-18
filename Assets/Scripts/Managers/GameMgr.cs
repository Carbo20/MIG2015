using System.Collections;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
	#region Fields

	#endregion

	#region Properties

	private bool isBlowing;
	private bool isTalking;
	private bool isClaping;

	#endregion

	#region Methods

	public void Awake()
	{
		gameObject.name = "GameMgr";
		isBlowing = false;
	}

	public void LoadLevel(int sceneIndex)
	{
		Application.LoadLevel(sceneIndex);
	}

	public void OnBlow()
	{
		isBlowing = true;
		foreach (GameObject candle in GameObject.FindGameObjectsWithTag("Candle")) {
			if(candle.transform.parent.GetComponent<CandleManager>().IsTrigger && !candle.transform.parent.GetComponent<CandleManager>().LightOn) //[TODO] Put the hitbox condition with the player and the candle here !!!
			{
				candle.transform.parent.GetComponent<CandleManager>().onBlow();
			}
		}
		isBlowing = false;

		PlayerController player = FindObjectOfType<PlayerController>();

		if (player)
		{
			player.OnBlow();
		}
	}

	public void OnTalk()
	{
		isTalking = true;
		if(GameObject.FindGameObjectWithTag("Reaper") != null){
			GameObject.FindGameObjectWithTag("Reaper").GetComponent<ReaperManager>().onTalk();
		}
		if (GameObject.Find ("Intro Manager") != null) {
			GameObject.Find ("Intro Manager") .GetComponent<IntroManager> ().onTalk ();
		}
		isTalking = false;
	}

	public void OnClap()
	{
		isClaping = true;
	}

	public void GameOver()
	{
		GameObject[] gameObjects = FindObjectsOfType<GameObject>();

		foreach (GameObject go in gameObjects)
			Destroy(go);

		Application.LoadLevel(0);
	}

	#endregion

	#region Getter Setter 

	public bool IsBlowing
	{
		get{ return isBlowing;}
		set{ isBlowing = value;}
	}

	public bool IsTalking
	{
		get{ return isTalking;}
		set{ isTalking = value;}
	}

	public bool IsClaping
	{
		get{ return isTalking;}
		set{ isTalking = value;}
	}

	#endregion
}