using UnityEngine;
using System.Collections;

public class pdv2 : MonoBehaviour {

    void Update()
    {
        if (GameObject.Find("Player 1").GetComponent<PlayerController>().get_playerLifePoint() < 2)
        {
            Destroy(gameObject);
        }

    }
}
