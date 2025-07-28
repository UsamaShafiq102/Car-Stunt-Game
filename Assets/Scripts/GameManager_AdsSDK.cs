using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_AdsSDK : MonoBehaviour 
{

	public GameObject PausePanel, GamePlayPanel, GameOverPanel, LevelCompletePanel, WaitPanel, NextLevelButton;

	[Header("Messages")]
	public GameObject messagePanel;
	public Text LevelsMessagesText;
	public string[] Messages; 

	[Header("Timer")]
	public Text  TimerText;
	public float[]   LevelTime;

	int  Minutes = 0;
	int  Seconds = 0;
	public static bool isLevelCompleted = false;
	bool isGamePaused = false;


	public static GameManager_AdsSDK instance;

	void Awake(){
		instance = this;
	}
	void Start()
	{
		isLevelCompleted = false;
		isGamePaused = false;
		//AdsSDK.instance.HideBanner();
		GamePlayPanel.SetActive (true);
		ShowMessagePanel ();
		StartCoroutine (HideMessagePanel());		
	}

	IEnumerator HideMessagePanel()
	{
		yield return new WaitForSeconds (4f);
		messagePanel.SetActive (false);
	}

	public void ShowMessagePanel()
	{
		messagePanel.SetActive (true);
		LevelsMessagesText.text = Messages[Preferences_AdsSDK.Instance.Level - 1];
		StartCoroutine (HideMessagePanel());
	}

	public void HideMsnBriefingNow()
	{
		messagePanel.SetActive (false);
	}

	public void OnClickPauseButton()
	{
		isGamePaused = true;
		PausePanel.SetActive (true);
		GamePlayPanel.SetActive (false);
		//AdsSDK.instance.ShowAdAfterGamePlay ();
		//AdsSDK.instance.ShowBanner();
	}
	public void OnClickResumeButton()
	{
		isGamePaused = false;
		GamePlayPanel.SetActive (true);
		PausePanel.SetActive (false);
		//AdsSDK.instance.HideBanner();
	}

	public void OnClickNextLevelButton()
	{
		Preferences_AdsSDK.Instance.Level++;
		WaitPanel.SetActive(true);
		SceneManager.LoadScene ("Loading_AdsSDK");
	}

	public void OnClickMainMenuButton()
	{
		WaitPanel.SetActive(true);
		SceneManager.LoadScene ("MainMenu_AdsSDK");
	}

	public void OnClickReplayButton()
	{
		WaitPanel.SetActive(true);
		SceneManager.LoadScene ("Loading_AdsSDK");
	}

	public void GameOver()
	{
		GamePlayPanel.SetActive (false);
		GameOverPanel.SetActive (true);
		StartCoroutine (WaitToShowAd());
	}

	IEnumerator WaitToShowAd()
	{
		yield return new WaitForSeconds (1.0f);
		//AdsSDK.instance.ShowAdAfterGamePlay ();
		//AdsSDK.instance.ShowBanner();
	}

	public void LevelComplete()
	{
		GamePlayPanel.SetActive (false);
		LevelCompletePanel.SetActive (true);
		isLevelCompleted = true;
		if(Preferences_AdsSDK.Instance.UnlockLevel < GameObject.FindObjectOfType<LevelManager_AdsSDK>().Levels.Length &&
			Preferences_AdsSDK.Instance.UnlockLevel == Preferences_AdsSDK.Instance.Level - 1)
			Preferences_AdsSDK.Instance.UnlockLevel++;
		if (Preferences_AdsSDK.Instance.Level >= GameObject.FindObjectOfType<LevelManager_AdsSDK>().Levels.Length)
			NextLevelButton.SetActive (false);
		StartCoroutine (WaitToShowAd ());
	}

	private void Update()
	{
		if (LevelTime[Preferences_AdsSDK.Instance.Level - 1] > 0f && !isLevelCompleted && !isGamePaused)
		{
			LevelTime[Preferences_AdsSDK.Instance.Level - 1] -= Time.deltaTime;
			Minutes = GetLeftMinutes();
			Seconds = GetLeftSeconds();
			if (LevelTime[Preferences_AdsSDK.Instance.Level - 1] > 0f)
			{
				TimerText.text = Minutes + ":" + Seconds.ToString("00");
			}
			else
				GameOver ();
		}
	}

	private int GetLeftMinutes()
	{
		return Mathf.FloorToInt(LevelTime[Preferences_AdsSDK.Instance.Level - 1] / 60f);
	}

	private int GetLeftSeconds()
	{
		return Mathf.FloorToInt(LevelTime[Preferences_AdsSDK.Instance.Level - 1] % 60f);
	}
}