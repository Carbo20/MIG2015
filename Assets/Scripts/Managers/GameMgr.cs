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
			if(true) //[TODO] Put the hitbox condition with the player and the candle here !!!
			{
				candle.GetComponent<CandleManager>().onBlow();
			}
		}
		//isBlowing = false;
	}

	public void OnTalk()
	{
	}

	public void OnTape()
	{
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