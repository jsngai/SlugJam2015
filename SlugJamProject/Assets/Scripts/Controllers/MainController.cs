using UnityEngine;
using System.Collections;

public class MainController : Controller, InputManager.InputListener
{
	public TypeWriter Writer;

	public string[] Phrases = new string[]
	{
		"Theonewhoknocks"
	};

	private Coroutine mainCoroutine;

	protected override void Awake()
	{
		base.Awake ();

		InputManager.Instance.SetInputListener (this);
	}

	private void Start()
	{
		mainCoroutine = StartCoroutine (IntroCoroutine ());
	}

	public void OnSpace()
	{
		Writer.AddSpace ();
	}

	public void OnEnter()
	{
		//Debug.Log ("hey");
	}

	private IEnumerator IntroCoroutine()
	{
		yield return new WaitForSeconds (1f);

		Writer.SetPauseDuration (0.05f);

		Writer.WriteText("Hello.");

		yield return new WaitForSeconds(3f);

		Writer.WriteText ("Press SPACE to fill in the gaps");

		while (true) {
			yield return new WaitForSeconds (4f);
			Writer.WriteTextInstant ("3");
			yield return new WaitForSeconds (1f);
			Writer.WriteTextInstant ("2");
			yield return new WaitForSeconds (1f);
			Writer.WriteTextInstant ("1");
			yield return new WaitForSeconds (1f);

			Writer.SetPauseDuration (1f);

			int phraseIndex = Random.Range (0, Phrases.Length);
			string phraseMessage = Phrases [phraseIndex];
			Writer.WriteText (phraseMessage);

			while(Writer.isWriting)
			{
				yield return null;
			}

			yield return new WaitForSeconds(1.5f);

			Writer.SetPauseDuration (0.05f);

			Writer.WriteText("Great job! Ready for more?");
		}
	}
}