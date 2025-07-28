using UnityEngine;
using System.Collections;

public class Preferences_AdsSDK : MonoBehaviour 
{
	static Preferences_AdsSDK _instance;

	private int _quality = 1;
	private int _sound = 1;
	private int _music = 1;
	private int _Level = 1;
	private int _LevelUnlock = 1;
	private int _score = 0;
	private int _showads;

	public static Preferences_AdsSDK Instance
	{
		get
		{
			if(_instance == null)
				_instance = new Preferences_AdsSDK();
			return _instance;
		}
	}

	private Preferences_AdsSDK()
	{
		Load ();
	}

	void Load()
	{
		_quality = PlayerPrefs.GetInt ("_quality",0);
		_sound = PlayerPrefs.GetInt ("_sound",1);
		_music = PlayerPrefs.GetInt ("_music",1);
		_Level = PlayerPrefs.GetInt ("_Level",0);
		_LevelUnlock = PlayerPrefs.GetInt ("_LevelUnlock",0);
		_score = PlayerPrefs.GetInt ("_score",0);
		_showads = PlayerPrefs.GetInt ("_showads",0);
	}

	void Save()
	{
		PlayerPrefs.SetInt ("_quality", _quality);
		PlayerPrefs.SetInt ("_sound", _sound);
		PlayerPrefs.SetInt ("_music", _music);
		PlayerPrefs.SetInt ("_Level", _Level);
		PlayerPrefs.SetInt ("_LevelUnlock", _LevelUnlock);
		PlayerPrefs.SetInt ("_score", _score);
		PlayerPrefs.SetInt ("_showads", _showads);
	}

	public void Reset()
	{
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		Load ();
	}

	public int Quality
	{
		get{return _quality;}
		set{_quality = value; Save();}
	}

	public int Sound
	{
		get{return _sound;}
		set{_sound = value; Save();}
	}

	public int Music
	{
		get{return _music;}
		set{_music = value; Save();}
	}

	public int Level
	{
		get{return _Level;}
		set{_Level = value; Save();}
	}

	public int UnlockLevel
	{
		get{return _LevelUnlock;}
		set{_LevelUnlock = value; Save();}
	}

	public int Score
	{
		get{return _score;}
		set{_score = value; Save();}
	}

	public int ShowAds
	{
		get{return _showads;}
		set{_showads = value; Save();}
	}
}
