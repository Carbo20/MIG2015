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

			
			if(GetComponentInChildren<ParticleSystem>().isStopped)
			{
				GetComponentInChildren<ParticleSystem>().Play();
				AudioMgr.Instance.PlaySFX("Torch_Fire_On");
			}
			Light light = GetComponentInChildren<Light> ();
			if(deltaTime < candleMaxIntensity) {
				deltaTime += Time.deltaTime;
				light.intensity = deltaTime;
			}
			else{
				isBlowing = false;
				deltaTime = 0f;
				lightOn = true;
				gameObject.GetComponent<AudioSource>().Play();
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
