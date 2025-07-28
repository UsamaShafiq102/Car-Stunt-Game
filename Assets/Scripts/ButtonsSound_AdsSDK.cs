using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSound_AdsSDK : MonoBehaviour {

	void Update () {
		GetComponent<AudioSource> ().volume = Preferences_AdsSDK.Instance.Sound;
	}
}
