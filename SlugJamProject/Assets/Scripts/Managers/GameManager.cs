using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Modified from GameManager.cs from Corgi Engine.
/// The game manager is a persistent singleton that handles points and time and world orientation
/// </summary>
public class GameManager : PersistentSingleton<GameManager>
{
	/// the current number of game points
	public int Points { get; private set; }
	/// the current points threshold (this requires at least one LevelGate to be present)
	public int PointsThreshold { get; private set; }
	/// true if the game is currently paused
	public bool Paused { get; set; } 
	/// true if the player is not allowed to move (in a dialogue for example)
	public bool CanMove = true;
	// the current controller
	public MainController Controller { get; set; }

	// cached
	private float _savedTimeScale;

	public override void Awake()
	{
		base.Awake ();

		GameObject controllerObject = GameObject.FindGameObjectWithTag ("MainController");
		Controller = controllerObject.GetComponent<MainController> ();
	}
	
	/// <summary>
	/// this method resets the whole game manager
	/// </summary>
	public void Reset()
	{
		Paused = false;
		CanMove = true;
		
		Points = 0;
	}
	
	/// <summary>
	/// Adds the points in parameters to the current game points.
	/// </summary>
	public void AddPoints(int pointsToAdd)
	{
		Points = Mathf.Max(0, pointsToAdd + Points);
	}
	
	/// <summary>
	/// use this to set the current points to the one you pass as a parameter
	/// </summary>
	/// <param name="points">Points.</param>
	public void SetPoints(int points)
	{
		Points = points;
	}
	
	public void SetPointsThreshold(int pointsThreshold)
	{
		PointsThreshold = pointsThreshold;
	}
	
	/// <summary>
	/// sets the timescale to the one in parameters
	/// </summary>
	/// <param name="newTimeScale">New time scale.</param>
	public void SetTimeScale(float newTimeScale)
	{
		_savedTimeScale = Time.timeScale;
		Time.timeScale = newTimeScale;
	}
	
	/// <summary>
	/// Resets the time scale to the last saved time scale.
	/// </summary>
	public void ResetTimeScale()
	{
		Time.timeScale = _savedTimeScale;
	}
	
	/// <summary>
	/// Pauses the game
	/// </summary>
	public void Pause()
	{	
		// if time is not already stopped		
		if (Time.timeScale > 0.0f)
		{
			Instance.SetTimeScale(0.0f);
			Instance.Paused = true;
			GUIManager.Instance.SetPause(true);
		}
		else
		{
			Instance.ResetTimeScale();	
			Instance.Paused = false;
			GUIManager.Instance.SetPause(false);	
		}		
	}
	
	/// <summary>
	/// Freeze.
	/// </summary>
	public void Freeze()
	{
		Instance.CanMove = false;
	}		
}
