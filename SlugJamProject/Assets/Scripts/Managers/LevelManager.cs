using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

/// <summary>
/// Spawns the player, and 
/// </summary>
public class LevelManager : MonoBehaviour
{
	/// Singleton
	public static LevelManager Instance { get; private set; }		
	/// the prefab you want for your player
	[Header("Prefabs")]
	public MainController MainController;
	/// the elapsed time since the start of the level
	public TimeSpan RunningTime { get { return DateTime.UtcNow - _started ;}}
	
	[Space(10)]
	[Header("Intro and Outro durations")]
	/// duration of the initial fade in
	public float IntroFadeDuration=1f;
	/// duration of the fade to black at the end of the level
	public float OutroFadeDuration=1f;
	
	
	// private stuff
	private DateTime _started;
	
	/// <summary>
	/// On awake, instantiates the player
	/// </summary>
	public void Awake()
	{
		Instance=this;
		GameManager.Instance.Controller = MainController;
	}
	
	/// <summary>
	/// Initialization
	/// </summary>
	public void Start()
	{
		// storage
		_started = DateTime.UtcNow;
		
		// fade in
		//GUIManager.Instance.FaderOn(false,IntroFadeDuration);	
	}
	
	/// <summary>
	/// Every frame we check for checkpoint reach
	/// </summary>
	public void Update()
	{
		//_started = DateTime.UtcNow;
	}
	
	/// <summary>
	/// Gets the player to the specified level
	/// </summary>
	/// <param name="levelName">Level name.</param>
	public void GotoLevel(string levelName)
	{		
		//GUIManager.Instance.FaderOn(true,OutroFadeDuration);
		StartCoroutine(GotoLevelCo(levelName));
	}
	
	/// <summary>
	/// Waits for a short time and then loads the specified level
	/// </summary>
	/// <returns>The level co.</returns>
	/// <param name="levelName">Level name.</param>
	private IEnumerator GotoLevelCo(string levelName)
	{
		MainController.SetActive (false);
		//yield return new WaitForSeconds(OutroFadeDuration);
		
		if (string.IsNullOrEmpty(levelName))
			Application.LoadLevel("Entry");
		else
			Application.LoadLevel(levelName);
		
		GameManager.Instance.Reset ();

		yield return null;
	}
	
	/// <summary>
	/// Kills the player.
	/// </summary>
	public void KillPlayer()
	{
		StartCoroutine(KillPlayerCo());
	}
	
	/// <summary>
	/// Coroutine that kills the player, stops the camera, resets the points.
	/// </summary>
	/// <returns>The player co.</returns>
	private IEnumerator KillPlayerCo()
	{
		MainController.SetActive (false);
		
		yield return new WaitForSeconds(2f);

		// do losing stuff
		
		// subtract coins
		//GameManager.Instance.AddPoints (-cachedCoins.Count);
		
		_started = DateTime.UtcNow;
	}
}