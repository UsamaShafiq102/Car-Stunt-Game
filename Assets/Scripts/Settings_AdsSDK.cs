using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using I2.Loc;

public class Settings_AdsSDK : MonoBehaviour {

	public string PrivacyPolicyURL = "https://sites.google.com/view/blitzmobilestudio/home";
	public Dropdown qualityDropdown;
	public Toggle soundToggle,musicToggle;
	// Use this for initialization
	void Start () {
		qualityDropdown.value = Preferences_AdsSDK.Instance.Quality;
		if(Preferences_AdsSDK.Instance.Sound == 1){
			soundToggle.isOn = false;
		// 	soundToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "Off" );
		}else{
			soundToggle.isOn = true;
		// 	soundToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "On" );
		}
		if(Preferences_AdsSDK.Instance.Music == 1){
			musicToggle.isOn = false;
		// 	musicToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "Off" );
		}else{
			musicToggle.isOn = true;
		// 	musicToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "On" );
		}
	}
	
	void Update(){
		CheckMusic();
		CheckSound();
	}

	public void OnChangeQuality(){
		Preferences_AdsSDK.Instance.Quality = qualityDropdown.value + 1;
		QualitySettings.SetQualityLevel(Preferences_AdsSDK.Instance.Quality,true);
	}

	public void OnChangeSound(){
		Preferences_AdsSDK.Instance.Sound = Preferences_AdsSDK.Instance.Sound == 0 ? 1:0;
	}

	public void OnChangeMusic(){
		Preferences_AdsSDK.Instance.Music = Preferences_AdsSDK.Instance.Music == 0 ? 1:0;
	}

	public void OnClickPrivacyPolicy(){
		Application.OpenURL(PrivacyPolicyURL);
	}

	public void CheckSound(){
		// if(soundToggle.isOn)
		// 	soundToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "On");

		// else
		// 	soundToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "Off");
	}

	public void CheckMusic(){
		// if(musicToggle.isOn)
		// 	musicToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "On" );
		// else
		// 	musicToggle.transform.GetChild(0).GetComponent<Text>().text = LocalizationManager.GetTermTranslation( "Off" );
	}
}
