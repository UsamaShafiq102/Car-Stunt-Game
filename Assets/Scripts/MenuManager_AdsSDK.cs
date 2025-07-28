using UnityEngine;
using System.Collections;
//using UnityEngine.Purchasing;

public class MenuManager_AdsSDK : MonoBehaviour 
{
	public bool ClearPrefs;
	public GameObject MainMenuPanel, PlayerSelectionPanel, LevelSelectionPanel, SettingPanel, ExitPanel, RemoveAdsButton, PurchaseError;
	AudioSource audioSource;
	public AudioClip buttonClickSound;
	public static MenuManager_AdsSDK instance;
	void Awake()
	{
		instance = this;
	}
	public void Start()
	{
		if(ClearPrefs)
			Preferences_AdsSDK.Instance.Reset();
		audioSource = GetComponent<AudioSource>();
		Time.timeScale = 1;
		MainMenuPanel.SetActive (true);
		if (Preferences_AdsSDK.Instance.ShowAds != 0)
			RemoveAdsButton.SetActive (false);
	}

	public void OnClickPlayButton()
	{
		ButtonClickSound();
		MainMenuPanel.SetActive (false);
		PlayerSelectionPanel.SetActive (true);
	}	

	public void OnClickSelectButton()
	{
		ButtonClickSound();
		PlayerSelectionPanel.SetActive (false);
		LevelSelectionPanel.SetActive (true);
	}

	public void OnClickExitButton()
	{
		ButtonClickSound();
		MainMenuPanel.SetActive (false);
		ExitPanel.SetActive (true);			
	}

	public void OnClickBackToMainMenuButton()
	{
		ButtonClickSound();
		MainMenuPanel.SetActive (true);
		PlayerSelectionPanel.SetActive (false);
	}

	public void OnClickSettingButton(){
		ButtonClickSound();
		SettingPanel.SetActive(true);
	}
	public void OnClickBackToPlayerSelectionButton()
	{
		ButtonClickSound();
		PlayerSelectionPanel.SetActive (true);
		LevelSelectionPanel.SetActive (false);
	}

	public void OnClickRateNowButton()
	{
		ButtonClickSound();
	//	AdsSDK.instance.RateUsRUL ();
	}

	public void OnClickMoreGamesButton(){
		ButtonClickSound();
		//AdsSDK.instance.MoreGames ();
	}

	public void OnClickQuitButton()
	{
		ButtonClickSound();
		Application.Quit ();
	}

	public void OnClickCancelQuitButton()
	{
		ButtonClickSound();
		MainMenuPanel.SetActive (true);
		ExitPanel.SetActive (false);
	}

	public void ButtonClickSound()
	{
		audioSource.PlayOneShot (buttonClickSound);
	}

	//public void OnPurchaseComplete(Product product){
       //AdsSDK.instance.OnPurchaseComplete(product);
   // }

   // public void OnPurchaseFailed(Product product, PurchaseFailureReason purchaseFailureReason){
       // PurchaseError.SetActive(true);
   // }
}
