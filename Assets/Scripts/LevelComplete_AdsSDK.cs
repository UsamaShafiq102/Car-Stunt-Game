using UnityEngine;
using System.Collections;

public class LevelComplete_AdsSDK : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.tag == "Player" && !GameManager_AdsSDK.isLevelCompleted) {

			GameManager_AdsSDK.instance.LevelComplete ();
		}
	}
}
