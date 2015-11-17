using UnityEngine;
using System.Collections;

public class CandleManager : MonoBehaviour {

	public float candleMaxIntensity = 2;

	private bool isBlowing;
	private float deltaTime;
	
	private bool isTrigger = false;
	private bool lightOn = false;
	// Use this for initialization
	void Start () {
		isBlowing = false;
		deltaTime  = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isBlowing) 
		{
			
			Light light = GetComponentInChildren<Light> ();
			if(deltaTime < candleMaxIntensity) {
				deltaTime += Time.deltaTime;
				Debug.Log(deltaTime);
				Debug.Log(light.intensity);
				light.intensity = deltaTime;
			}
			else{
				isBlowing = false;
				deltaTime = 0f;
				lightOn = true;
			}
		}

	}

	public void onBlow()
	{
		isBlowing = true;
	}

	
	public bool IsTrigger{
		get{return isTrigger;}
		set{ isTrigger = value;}
	}

	public bool LightOn{
		get{ return lightOn;}
		set{ lightOn = value;}
	}
}
