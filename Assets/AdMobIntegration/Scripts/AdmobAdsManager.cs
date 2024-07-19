using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class AdmobAdsManager : MonoBehaviour
{
    private static AdmobAdsManager _instance;
    public static AdmobAdsManager Instance => _instance;

    #region Id declaration

    [SerializeField] private string _appId = "";

#if UNITY_ANDROID
    [SerializeField] private string _bannerId = "";
    [SerializeField] private string _interId = "";
    [SerializeField] private string _rewardedId = "";
#elif UNITY_IPHONE
    [SerializeField] private string _bannerId = "";
    [SerializeField] private string _interId = "";
    [SerializeField] private string _rewardedId = "";
#endif

    public string AppId => _appId;
    public string BannerId => _bannerId;
    public string InterId => _interId;
    public string RewardedId => _rewardedId;

    #endregion

    #region Events

    public event Action OnInterstitialAdDisplayed;
    public event Action OnRewardedAdDisplayed;
    
    #endregion

    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;
    private RewardedAd _rewardedAd;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => { });
    }

    #region Banner

    public void LoadBannerAd()
    {
        CreateBannerView();
        ListenToBannerEvents();

        if (_bannerView == null)
            CreateBannerView();

        var adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }

    private void CreateBannerView()
    {
        if (_bannerView != null) DestroyBannerAd();

        // You can specify the size and the position of the banner ad.
        // For more banner options and sizes: https://developers.google.com/admob/unity/banner
        _bannerView = new BannerView(_bannerId, AdSize.Banner, AdPosition.Top);
    }

    private void ListenToBannerEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () => { };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) => { };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) => { };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () => { };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () => { };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () => { };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () => { };
    }

    public void DestroyBannerAd()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    #endregion

    #region Interstitial

    public void LoadInterstitialAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        var adRequest = new AdRequest();
        InterstitialAd.Load(_interId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    return;
                }

                _interstitialAd = ad;
                InterstitialEvent(_interstitialAd);
            });
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();
            OnInterstitialAdDisplayed?.Invoke();
        }
    }

    private void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) => { };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () => { };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) => { };
    }

    #endregion

    #region Rewarded

    public void LoadRewardedAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        var adRequest = new AdRequest();
        RewardedAd.Load(_rewardedId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                    return;

                _rewardedAd = ad;
                RewardedEvent(_rewardedAd);
            });
    }

    public void ShowRewardedAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                OnRewardedAdDisplayed?.Invoke();
            });
        }
    }

    private void RewardedEvent(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) => { };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () => { };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) => { };
    }

    #endregion
}