using UnityEngine;
using System.Collections;

public class PlayerAutomatique : MonoBehaviour {
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private Transform _spriteTransform;
	
	[SerializeField] private int _playerLifePoint = 3;
	[SerializeField] private float _playerRecoveryTime = 2f;
	private bool _playerRecovery = false;
	public Transform destination;

	void Update () {
		
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = destination.position;
		if (_spriteTransform)
		{
			_spriteTransform.rotation = Quaternion.identity;
		}
	}

	public void AddDamage(int damage)
	{
		Debug.Log(_playerRecovery);
		if (_playerRecovery) return;
		
		_playerLifePoint -= damage;
		
		if (_playerLifePoint <= 0)
		{
			//TODO
			//GameOverFunc
			GameMgr.Instance.GameOver();
		}
		else
		{
			_playerRecovery = true;
			StartCoroutine("PlayerRecoveryCoroutine");
		}
	}
	
	IEnumerator PlayerRecoveryCoroutine()
	{
		yield return new WaitForSeconds(2f);
		_playerRecovery = false;
	}
}
