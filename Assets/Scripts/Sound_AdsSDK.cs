using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_AdsSDK : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		if(FindObjectsOfType(GetType()).Length>1){
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<AudioSource> ().volume = Preferences_AdsSDK.Instance.Music;
	}
}
