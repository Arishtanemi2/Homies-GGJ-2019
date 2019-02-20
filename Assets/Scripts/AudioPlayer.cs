using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	public AudioSource asource;
	public AudioClip bclicksound;
	public void buttonClick(){
		asource.PlayOneShot(bclicksound);

	}
}
