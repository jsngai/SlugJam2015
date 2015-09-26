using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Handles all GUI effects and changes
/// </summary>
public class GUIManager : MonoBehaviour
{
	/// the pause screen game object
	public GameObject PauseScreen;	
	/// the time splash gameobject
	public GameObject TimeSplash;
	/// The mobile buttons
	public GameObject Buttons;
	/// the screen used for all fades
	public Image Fader;
	
	private static GUIManager _instance;
	
	// Singleton pattern
	public static GUIManager Instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<GUIManager>();
			return _instance;
		}
	}
	
	/// <summary>
	/// Initialization
	/// </summary>
	public void Start()
	{
	}
	
	/// <summary>
	/// Sets the pause.
	/// </summary>
	/// <param name="state">If set to <c>true</c>, sets the pause.</param>
	public void SetPause(bool state)
	{
		PauseScreen.SetActive(state);
	}
	
	/// <summary>
	/// Sets the time splash.
	/// </summary>
	/// <param name="state">If set to <c>true</c>, turns the timesplash on.</param>
	public void SetTimeSplash(bool state)
	{
		TimeSplash.SetActive(state);
	}

	/*
	//public ResetNav()
	//{
	//for(int i = 0; i < this.GetC
	//}
	
	/// <summary>
	/// Fades the fader in or out depending on the state
	/// </summary>
	/// <param name="state">If set to <c>true</c> fades the fader in, otherwise out if <c>false</c>.</param>
	public void FaderOn(bool state,float duration)
	{
		Fader.gameObject.SetActive(true);
		if (state)
			StartCoroutine(CorgiTools.FadeImage(Fader,duration, new Color(0,0,0,1f)));
		else
			StartCoroutine(CorgiTools.FadeImage(Fader,duration,new Color(0,0,0,0f)));
	}
	*/
}
