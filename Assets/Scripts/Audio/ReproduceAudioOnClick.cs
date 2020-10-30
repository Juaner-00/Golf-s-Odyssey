using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReproduceAudioOnClick : MonoBehaviour
{
	[SerializeField]
	float finalValuePlay;
	[SerializeField]
	float durationPlay;

	[SerializeField]
	float finalValueDown;
	[SerializeField]
	float durationDown;


	public void Play(string source)
	{
		AudioManager.instance.Play(source);
	}

	public void PlayAndFade(AudioSource source)
	{
		source.Play();
		source.DOFade(finalValuePlay, durationPlay);
	}

	public void ContinuePlaying(AudioSource source)
	{
		source.DOFade(finalValuePlay, durationPlay);
	}

	public void DownAndFade(AudioSource source)
	{
		source.DOFade(finalValueDown, durationDown);
	}


}
