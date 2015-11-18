using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	#region Fields

	static private T _instance;

	#endregion

	#region Properties

	public static T Instance
	{
		get
		{
			return FindObjectOfType<T>();
		}
	}

	#endregion
}
