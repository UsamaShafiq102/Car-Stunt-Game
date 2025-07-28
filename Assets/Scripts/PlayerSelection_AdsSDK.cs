using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection_AdsSDK : MonoBehaviour {

	public Transform carsParent;
	public GameObject unlock, play,price,notenoughcoins;
	public int[] CarPrice;
	public Text Coins;
	public static int currentCar;
	
	void Start(){
		carsParent.gameObject.SetActive(true);
		PlayerPrefs.SetInt ("Car0", 1);
		OnClickChangeCar (0);
	}

	void Update(){
		Coins.text = Preferences_AdsSDK.Instance.Score.ToString ();
	}

	public void OnClickChangeCar(int no){
		MenuManager_AdsSDK.instance.ButtonClickSound ();
		currentCar += no;

		if (currentCar >= carsParent.childCount)
			currentCar = 0;
		if (currentCar < 0)
			currentCar = carsParent.childCount - 1;

		for (int x = 0; x < carsParent.childCount; x++)
			if (x == currentCar)
				carsParent.GetChild (currentCar).gameObject.SetActive (true);
			else
				carsParent.GetChild (x).gameObject.SetActive (false);

		if (PlayerPrefs.GetInt ("Car" + currentCar, 0) == 0) {
			unlock.SetActive (true);
			price.transform.GetChild (0).GetComponent<Text> ().text = CarPrice [currentCar].ToString ();
			price.SetActive (true);
			play.SetActive (false);
		} else {
			unlock.SetActive (false);
			price.SetActive (false);
			play.SetActive (true);
		}
	}

	public void OnClickBuyCar(){
		if (Preferences_AdsSDK.Instance.Score - CarPrice[currentCar]>= 0) {
			PlayerPrefs.SetInt ("Car" + currentCar, 1);
			Preferences_AdsSDK.Instance.Score -= CarPrice [currentCar];
				unlock.SetActive (false);
				price.SetActive (false);
				play.SetActive (true);
		} else {
			notenoughcoins.SetActive (true);
		}
		MenuManager_AdsSDK.instance.ButtonClickSound ();
	}
}
