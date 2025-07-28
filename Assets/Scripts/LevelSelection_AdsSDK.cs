using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection_AdsSDK : MonoBehaviour 
{
	public GameObject unlockallLevelsButton;
	public Button[] Levels;

	public void Start()
	{
		int i;
		for (i = 0; i < Levels.Length; i++) {
			if (i <= Preferences_AdsSDK.Instance.UnlockLevel)  {
				Levels [i].transform.Find ("lock").gameObject.SetActive (false);
				Levels [i].transform.Find ("Stars").gameObject.SetActive (false);
				Levels [i].transform.Find ("Stars").gameObject.SetActive (true);
				Levels [i].interactable = true;
			} 
			else {
				Levels [i].transform.Find ("lock").gameObject.SetActive (true);
				Levels [i].transform.Find ("Stars").gameObject.SetActive (false);
				Levels [i].interactable = false;
			}
		}
		//Levels [Preferences_AdsSDK.Instance.UnlockLevel - 1].transform.Find ("Stars").gameObject.SetActive (false);

		if(Preferences_AdsSDK.Instance.UnlockLevel >= Levels.Length-1){
			unlockallLevelsButton.SetActive(false);
		}

	}
	public void OnSelectLevel(int levelNo)
	{
		MenuManager_AdsSDK.instance.ButtonClickSound();
		Preferences_AdsSDK.Instance.Level = levelNo;
		SceneManager.LoadScene ("Loading_AdsSDK");
	}

	public void OnClickGetCoins(){
		MenuManager_AdsSDK.instance.ButtonClickSound();
		//AdsSDK.instance.ShowRewardedVideoAd ();
	}
}
