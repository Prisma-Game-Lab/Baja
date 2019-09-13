using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	//public AudioManager manager;

	public void SetVolume (float volume) {
		audioMixer.SetFloat("Volume", volume);

		//manager.Awake();
	}

	public void SetSFXVolume(float volume){
		AudioManager.instance.carSound.volume = volume;
	}
}
