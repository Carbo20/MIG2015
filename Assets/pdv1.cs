using UnityEngine;
using System.Collections;

public class pdv1 : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	if( GameObject.Find("Player 1").GetComponent<PlayerController>().get_playerLifePoint() < 1 )
        {
            Destroy(gameObject);
        }
	}
}
