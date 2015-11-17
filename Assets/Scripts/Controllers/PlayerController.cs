using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private Transform _spriteTransform;

	[SerializeField] private int _playerLifePoint = 3;
	[SerializeField] private float _playerRecoveryTime = 2f;

	private bool _playerRecovery = false;

    public float invertx;
    public float inverty;
    public float vitesse;
    private float ratiovitesse;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lookDirection = Vector3.zero;
    public GameObject vision;

    public void Update()
	{
        ratiovitesse = (float)(vitesse / 100);

        if (_characterController)
		{
            moveDirection = new Vector3((invertx) * Input.GetAxis("Horizontal"), 0f,(inverty) * Input.GetAxis("Vertical"));
            moveDirection *= ratiovitesse;
			_characterController.Move(moveDirection);

            lookDirection = new Vector3(-1*Input.GetAxis("Horizontal2"), 0f, Input.GetAxis("Vertical2"));
            // transform.LookAt(lookDirection);
            if (lookDirection.x > 0 && lookDirection.z == 0) {transform.rotation= Quaternion.Euler(0f, 0f, 0f); }
            if (lookDirection.x > 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 45, 0f); }
            if (lookDirection.x == 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 90, 0f); }
            if (lookDirection.x < 0 && lookDirection.z > 0) { transform.rotation = Quaternion.Euler(0f, 135, 0f); }
            if (lookDirection.x < 0 && lookDirection.z == 0) { transform.rotation = Quaternion.Euler(0f, 180, 0f); }
            if (lookDirection.x < 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 225, 0f); }
            if (lookDirection.x == 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 270, 0f); }
            if (lookDirection.x > 0 && lookDirection.z < 0) { transform.rotation = Quaternion.Euler(0f, 315, 0f); }


			if (_spriteTransform)
			{
				_spriteTransform.rotation = Quaternion.identity;
			}
        }

        
	}

	public void AddDamage(int damage)
	{
		if (_playerRecovery) return;

		_playerLifePoint -= damage;

		if (_playerLifePoint <= 0)
		{
			//TODO
			//GameOverFunc
		}
		else
		{
			StartCoroutine("PlayerRecoveryCoroutine");
		}
	}

	IEnumerable<WaitForSeconds> PlayerRecoveryCoroutine()
	{
		_playerRecovery = true;
		yield return new WaitForSeconds(_playerRecoveryTime);
		_playerRecovery = false;
	}

}