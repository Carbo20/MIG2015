﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
    public float invertx;
    public float inverty;
    public float vitesse;
    private float ratiovitesse;
    private Vector3 moveDirection = Vector3.zero;

    public void Update()
	{
        ratiovitesse = (float)(vitesse / 100);

        if (_characterController)
		{
            moveDirection = new Vector3((invertx) * Input.GetAxis("Horizontal"), 0f,(inverty) * Input.GetAxis("Vertical"));
            moveDirection *= ratiovitesse;
			_characterController.Move(moveDirection);
            
		}
	}
}