using UnityEngine;
using System.Collections;

public class DetectionPlayer : MonoBehaviour {
    public float acceleration;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Enemy>().speed *= acceleration;
            transform.parent.GetComponent<Enemy>().etat = transform.parent.GetComponent<Enemy>().type + 1;
        }
    }

}
