using UnityEngine;

public class MenuButton : MonoBehaviour
{
	public void Select()
	{
		transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
	}

	public void UnSelect()
	{
		transform.localScale = new Vector3(1f, 1f, 1f);
	}
}