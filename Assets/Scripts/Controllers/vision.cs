using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {


    }

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Candle") {
			col.gameObject.transform.parent.GetComponent<CandleManager>().IsTrigger = true;
		}
	}


	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Candle") {
			col.gameObject.transform.parent.GetComponent<CandleManager>().IsTrigger = false;
		}
	}

}
