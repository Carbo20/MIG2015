using UnityEngine;

public class EnemyTowerController : MonoBehaviour
{
	#region Fields

	[SerializeField] private Light _spotLight;

	#endregion

	#region Methods

	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			RaycastHit hit;

			if (Physics.Linecast(transform.position, collider.transform.position, out hit))
			{
				if (hit.collider.gameObject.tag != "Player") return;

				if (_spotLight)
				{
					_spotLight.color = Color.red;
				}
			}

			collider.gameObject.GetComponent<PlayerController>().AddDamage(1);
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
