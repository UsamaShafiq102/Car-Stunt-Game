using UnityEngine;
using System.Collections;

public class LevelManager_AdsSDK : MonoBehaviour {

	public GameObject[] Levels;
	public bool isTesting = false;
	public int TestLevel;
	GameObject temp;

	void Start () 
	{
		if (isTesting) 
		{
			Preferences_AdsSDK.Instance.Level = TestLevel;
			temp = Instantiate(Levels[TestLevel - 1]);
			temp.transform.SetParent(gameObject.transform);
		} 
		else 
		{
			for (int i = 0; i < Levels.Length; i++) 
			{
				if (i == Preferences_AdsSDK.Instance.Level - 1) {
					temp = Instantiate(Levels [i]);
                    temp.transform.SetParent(gameObject.transform);
				}
			}
		}
	}
}