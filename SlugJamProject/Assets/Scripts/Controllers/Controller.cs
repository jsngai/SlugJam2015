using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	protected bool isActive;

	protected virtual void Awake() 
	{
		isActive = true;
	}

	public virtual void SetActive(bool flag)
	{
		isActive = flag;
	}
}