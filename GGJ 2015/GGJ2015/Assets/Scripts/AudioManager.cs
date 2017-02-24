using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip homelessDeath;
	public AudioClip homelessThrow;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void playSound(AudioClip chosen)
	{
		this.audio.clip = chosen;
		this.audio.Play ();
	}
}
