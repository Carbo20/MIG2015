using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LetterImage : MonoBehaviour
{
	#region Fields

	[SerializeField] private Sprite _closeSprite;
	[SerializeField] private Sprite _openSprite;

	private Image _image;

	#endregion

	#region Methods

	public void Awake()
	{
		_image = GetComponent<Image>();
	}

	public void Open()
	{
		_image.sprite = _openSprite;
	}

	public void Close()
	{
		_image.sprite = _closeSprite;
	}

	#endregion
}
