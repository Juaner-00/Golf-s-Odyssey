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


}
