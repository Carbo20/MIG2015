using UnityEngine;
using System.Collections;

public class pdv3 : MonoBehaviour {

    void Update()
    {
        if (GameObject.Find("Player 1").GetComponent < PlayerController > ().get_playerLifePoint() < 3)
        {
            Destroy(gameObject);
        }
    }
}
