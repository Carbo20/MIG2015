using UnityEngine;
using System.Collections;

public class CandleManager : MonoBehaviour {

	public float candleMaxIntensity = 2;

	private bool isBlowing;
	private float deltaTime;
	
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
			}
		}

	}

	public void onBlow()
	{
		isBlowing = true;
	}

}
