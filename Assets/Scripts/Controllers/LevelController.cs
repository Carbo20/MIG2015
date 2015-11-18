using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {


	[SerializeField] private List<CandleManager> _candleList;
	[SerializeField] private string _musicName;
	
	public void Start()
	{
		AudioMgr.Instance.PlayMusic (_musicName);
	}

	void Update () {

			foreach (CandleManager candle in _candleList) {
				if (!candle.LightOn)
					return;
			}

		//Victory Func

		GameMgr.Instance.LoadLevel(3);
	}
}
