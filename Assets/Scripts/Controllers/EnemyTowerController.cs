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
			if (_spotLight)
			{
				_spotLight.color = Color.red;
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
