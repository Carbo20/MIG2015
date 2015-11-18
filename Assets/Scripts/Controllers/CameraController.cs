using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	#region Fields

	[SerializeField] private Transform _followTarget;
	[SerializeField] private float _cameraHeight = 10f;
	[SerializeField] private float _cameraDepth = 5f;

	private Camera _camera;

	#endregion

	public void Update()
	{
		if (_followTarget)
			transform.position = new Vector3(_followTarget.position.x, _cameraHeight, _followTarget.position.z - _cameraDepth);

		transform.LookAt(_followTarget);
	}
}