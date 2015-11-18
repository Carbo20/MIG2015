using System.Collections;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
	#region Fields

	#endregion

	#region Properties

	private bool isBlowing;

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
			Debug.Log(candle.transform.parent.GetComponent<CandleManager>().IsTrigger);
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
	}

	public void OnTape()
	{
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

	#endregion
}