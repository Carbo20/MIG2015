using UnityEngine;
using System.Collections;

public class TransitionController : MonoBehaviour {

	[SerializeField] private int _sceneID;

	void Update () {

			if (Input.anyKeyDown) {
			GameMgr.Instance.LoadLevel(_sceneID);
			}
	}
}
