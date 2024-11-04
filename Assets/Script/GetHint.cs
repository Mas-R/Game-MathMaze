using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;
public class GetHint : MonoBehaviour, IUnityAdsListener
{
    string _androidAdUnitId = "Interstitial_Android";
    string _iOsAdUnitId = "Interstitial_iOS";
    public TextMeshProUGUI text;
    public GameObject btnOK;
    public GameObject canvas;
    string _adUnitId;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }
    private void OnEnable()
    {
        Debug.Log("LoadAd");
        Advertisement.Load(_adUnitId);
        Advertisement.AddListener(this);
    }
    public void BtnOka()
    {
        FindObjectOfType<AudioManager>().ButtonClck();
        Advertisement.Show(_adUnitId);
    }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("OnUnityAdsReady");
        text.text = "Wacth Ads For Hint";
        btnOK.SetActive(true);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError");
        text.text = "Gagal Memuat Iklan";
        btnOK.SetActive(false);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("OnUnityAdsDidFinish");
        canvas.GetComponent<Hint>().BtnOk();
    }
    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    /*public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded");
        text.text = "Wacth Ads For Hint";
        btnOK.SetActive(true);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("OnUnityAdsFailedToLoad");
        text.text = "Gagal Memuat Iklan";
        btnOK.SetActive(false);
    }*/
}
