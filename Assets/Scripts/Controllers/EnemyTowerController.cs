using UnityEngine;

public class EnemyTowerController : MonoBehaviour
{
	#region Fields

	[SerializeField] private Light _spotLight;
	[SerializeField] private GameObject _audioSourceGO;

	private AudioSource _audioSource;

	#endregion

	#region Methods

	public void Awake()
	{
		_audioSourceGO.GetComponent<AudioSource>();
	}

	public void FixedUpdate()
	{
		RaycastHit hit;

		LayerMask mask = 1 << LayerMask.NameToLayer("Ground");

		if (Physics.Raycast(_spotLight.transform.position, _spotLight.transform.forward, out hit, 100f, mask))
		{
			_audioSourceGO.transform.position = hit.point;
			_audioSourceGO.transform.Translate(Vector3.forward*2f, Space.Self);
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			RaycastHit hit;

			Debug.DrawLine(transform.position, collider.transform.position, Color.red);

			if (Physics.Linecast(transform.position, collider.transform.position, out hit))
			{
				if (hit.collider.gameObject.tag != "Player") return;

				if (_spotLight)
				{
					_spotLight.color = Color.red;
				}
				collider.gameObject.GetComponent<PlayerController>().AddDamage(1);
			}
		}
	}

	public void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			if (_spotLight)
			{
				_spotLight.color = Color.yellow;
			}
		}
	}

	#endregion
}
