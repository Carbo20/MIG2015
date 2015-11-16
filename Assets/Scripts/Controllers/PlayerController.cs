using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;

	public void Update()
	{
		if (_characterController)
		{
			_characterController.Move(new Vector3(Input.GetAxis("Horizontal"), 0f, -Input.GetAxis("Vertical")));
		}
	}
}