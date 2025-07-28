using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Loading_AdsSDK : MonoBehaviour
{
    public string sceneToLoad = "GamePlay_AdsSDK";
    public Image fillImage;
	public Text percentage;
    public bool ShowAds;
    AsyncOperation async;

    void Start()
    {
		if(ShowAds)
        //   AdsSDK.instance.ShowAdBeforeGamePlay();
        async = SceneManager.LoadSceneAsync(sceneToLoad);
        async.allowSceneActivation = false;
        Load();
    }

    public void Load()
    {
		if (async.progress >= 0.9f)
        {
            fillImage.DOFillAmount(1, 1.0f).OnComplete(() =>
                {
                    async.allowSceneActivation = true;
                }).WaitForCompletion();
        }
        else
        {
            fillImage.DOFillAmount(async.progress, 1.0f).OnComplete(() =>
                {
					Invoke("Load", 0.5f);
                }).WaitForCompletion();
        }
		percentage.text = (int.Parse((async.progress * 100).ToString()))+"%";
	}

}
