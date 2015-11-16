using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {

    public Transform target;
    public GameObject joueur;
	
	// Update is called once per frame
	void Update () {
        float radius = GetComponent<SphereCollider>().radius;
        Vector3 centre = GetComponent<SphereCollider>().center;
        Vector3 joueurc = joueur.transform.position;
        transform.position = joueurc;
        transform.LookAt(target);
        transform.localPosition = Vector3.forward * 5;
        


    }
}
