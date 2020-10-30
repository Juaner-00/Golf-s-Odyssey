using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReproduceAudioOnClick : MonoBehaviour
{
	
	public void Play(string source)
	{
		AudioManager.instance.Play(source);
	}


	public void AccessCiclope()
	{
		if (LockManager.accederCiclope)
		{
			AudioManager.instance.Play("SelectForward");
			FadeIn("Ciclopes");
			FadeOut("Odisea Principal");

		}
			
		else
		{
			AudioManager.instance.Play("SelectBack");
		}
	}

	public void AccessSirenas()
	{
		if (LockManager.accederSirenas)
		{
			AudioManager.instance.Play("SelectForward");
			FadeIn("Sirenas");
			FadeOut("Odisea Principal");
		}
			
		else
		{
			AudioManager.instance.Play("SelectBack");
		}
	}

	public void AccessItaca()
	{
		if (LockManager.accederItaca)
		{
			AudioManager.instance.Play("SelectForward");
			FadeIn("Itaca");
			FadeOut("Odisea Principal");
		}
			

		else
		{
			AudioManager.instance.Play("SelectBack");
		}
	}

	public void FadeIn(string audio)
	{
		AudioManager.instance.FadeIn(audio);
	}

	public void ContinuePlaying(string audio)
	{
		AudioManager.instance.ContinuePlaying(audio);

	}

	public void FadeOut(string audio)
	{
		AudioManager.instance.FadeOut(audio);
	}

	public void Stop()
	{
		AudioManager.instance.Stop();
	}
}
