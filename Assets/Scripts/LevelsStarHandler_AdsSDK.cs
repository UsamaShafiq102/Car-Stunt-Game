using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsStarHandler_AdsSDK : MonoBehaviour {

	void OnEnable(){
		switch(PlayerPrefs.GetInt("StarsOfLevel"+transform.parent.name,0)){
			case 0:
				transform.GetChild(0).gameObject.SetActive(false);
				transform.GetChild(1).gameObject.SetActive(false);
				transform.GetChild(2).gameObject.SetActive(false);
				break;
			case 1:
				transform.GetChild(1).gameObject.SetActive(false);
				transform.GetChild(2).gameObject.SetActive(false);
				break;
			case 2:
				transform.GetChild(2).gameObject.SetActive(false);
				break;
		}
	}
}
