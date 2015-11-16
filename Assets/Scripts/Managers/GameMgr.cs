using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
	#region Fields
	#endregion

	#region Properties
	#endregion

	#region Methods

	public void Awake()
	{
		gameObject.name = "GameMgr";
	}

	public void LoadLevel(int sceneIndex)
	{
		Application.LoadLevel(sceneIndex);
	}

	#endregion
}