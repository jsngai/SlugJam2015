using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Modified from InputManager.cs from Corgi Engine.
/// This persistent singleton handles the inputs and sends commands to the player
/// </summary>
public class InputManager : PersistentSingleton<InputManager>
{
	private static MainController _controller;
	
	/// <summary>
	/// We get the player from its tag.
	/// </summary>
	void Start()
	{
		if (GameManager.Instance.Controller != null)
		{
			_controller = GameManager.Instance.Controller;
		}
	}
	
	/// <summary>
	/// At update, we check the various commands and send them to the player.
	/// </summary>
	void Update()
	{
		
		// if we can't get the player, we do nothing
		if (_controller == null) 
		{
			return;
		}
		
		if ( CrossPlatformInputManager.GetButtonDown("Cancel") )
			GameManager.Instance.Pause();
		
		if (GameManager.Instance.Paused)
			return;	
		
		// if the player can't move for some reason, we do nothing else
		if (!GameManager.Instance.CanMove)
			return;
		
		if (CrossPlatformInputManager.GetButtonDown ("Space")) 
		{
			_controller.OnSpace();
		}
		
		if (CrossPlatformInputManager.GetButtonDown ("Submit")) 
		{
			_controller.OnEnter();
		}
	}	
}
