/*
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
			if (_instance == null)
			{
				_instance = new T();
			}
			return _instance;
		}
		set { _instance = value; }
	}

	#endregion
}
*/
