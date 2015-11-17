using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	#region Fields

	[SerializeField] private Transform _followTarget;
	[SerializeField] private float _cameraHeight = 10f;
	[SerializeField] private float _cameraDepth = 5f;
	//[SerializeField] private BoxCollider _cameraZone;

	private Camera _camera;
//	private List<MeshCollider> _planeColliderList = new List<MeshCollider>();
//	private List<Plane> _planeList;

	#endregion

	public void Awake()
	{
//		_camera = GetComponent<Camera>();
	}

	public void Start()
	{
		/*Camera cam = Camera.main;
		_planeList = new List<Plane>(GeometryUtility.CalculateFrustumPlanes(cam));
		int i = 0;

		foreach (Plane plane in _planeList)
		{
			GameObject p = GameObject.CreatePrimitive(PrimitiveType.Plane);
			p.name = "Plane " + i.ToString();
			p.GetComponent<MeshRenderer>().enabled = false;
			p.GetComponent<MeshCollider>().convex = true;
			p.GetComponent<MeshCollider>().isTrigger = true;
			p.transform.position = -plane.normal*plane.distance;
			p.transform.rotation = Quaternion.FromToRotation(Vector3.up, plane.normal);
			p.transform.SetParent(_camera.transform);
			_planeColliderList.Add(p.GetComponent<MeshCollider>());
			i++;
		}*/
	}

	public void Update()
	{

		transform.position = new Vector3(_followTarget.position.x, _cameraHeight, _followTarget.position.z - _cameraDepth);
		
		/*float xBound = _planeColliderList[1].transform.localPosition.x;
		float zBound = _planeColliderList[3].transform.localPosition.y;

		_camera.transform.position = new Vector3(_followTarget.transform.position.x, _camera.transform.position.y, _followTarget.transform.position.z);
		
		if (!_cameraZone.bounds.Intersects(_planeColliderList[0].bounds))
			_camera.transform.position = new Vector3(-1f * _cameraZone.transform.localScale.x*.5f + xBound, _camera.transform.position.y, _camera.transform.position.z);
		else if (!_cameraZone.bounds.Intersects(_planeColliderList[1].bounds))
			_camera.transform.position = new Vector3(1f * _cameraZone.transform.localScale.x * .5f - xBound, _camera.transform.position.y, _camera.transform.position.z);
		if (!_cameraZone.bounds.Intersects(_planeColliderList[2].bounds))
			_camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -1f * _cameraZone.transform.localScale.z * .5f + zBound);
		else if (!_cameraZone.bounds.Intersects(_planeColliderList[3].bounds))
			_camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 1f * _cameraZone.transform.localScale.z * .5f - zBound);*/
	}
}