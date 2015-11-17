using System.Collections;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
	#region Fields

	[SerializeField] private int _playerLifePoint = 3;
	[SerializeField] private float _playerRecoveryTime = 2f;

	private bool _playerRecovery = false;

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
	}

	public void OnTalk()
	{
	}

	public void OnTape()
	{
	}

	public void AddDamage(int damage)
	{
		if (_playerRecovery) return;

		_playerLifePoint -= damage;

		if (_playerLifePoint <= 0)
		{
			//TODO
			//GameOverFunc
		}
		else
		{
			StartCoroutine("PlayerRecoveryCoroutine");
		}
	}

	IEnumerator PlayerRecoveryCoroutine()
	{
		_playerRecovery = true;
		yield return new WaitForSeconds(_playerRecoveryTime);
		_playerRecovery = false;
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