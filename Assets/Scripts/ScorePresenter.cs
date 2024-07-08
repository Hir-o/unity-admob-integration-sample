using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("Banner Buttons")] [SerializeField]
    private Button _showBannerButton;

    [SerializeField] private Button _destroyBannerButton;

    [Header("Interstitial Buttons")] [SerializeField]
    private Button _loadInterstitialButton;

    [SerializeField] private Button _showInterstitialButton;

    [Header("Rewarded Buttons")] [SerializeField]
    private Button _loadRewardedButton;

    [SerializeField] private Button _showRewardedButton;

    private int _score = 0;

    private void Awake()
    {
        _showBannerButton.onClick.AddListener(LoadBanner);
        _destroyBannerButton.onClick.AddListener(DestroyBanner);
        _loadInterstitialButton.onClick.AddListener(LoadInterstitialAd);
        _showInterstitialButton.onClick.AddListener(ShowInterstitialAd);
        _loadRewardedButton.onClick.AddListener(LoadRewardedAd);
        _showRewardedButton.onClick.AddListener(ShowRewardedAd);
    }

    private void OnEnable()
    {
        AdmobAdsManager.Instance.OnInterstitialAdDisplayed += UpdateScoreInterstitial;
        AdmobAdsManager.Instance.OnRewardedAdDisplayed += UpdateScoreRewarded;
    }

    private void LoadBanner() => AdmobAdsManager.Instance.LoadBannerAd();
    private void DestroyBanner() => AdmobAdsManager.Instance.DestroyBannerAd();
    private void LoadInterstitialAd() => AdmobAdsManager.Instance.LoadInterstitialAd();
    private void ShowInterstitialAd() => AdmobAdsManager.Instance.ShowInterstitialAd();
    private void LoadRewardedAd() => AdmobAdsManager.Instance.LoadRewardedAd();
    private void ShowRewardedAd() => AdmobAdsManager.Instance.ShowRewardedAd();

    private void UpdateScoreInterstitial()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
    
    private void UpdateScoreRewarded()
    {
        _score += 10;
        _scoreText.text = _score.ToString();
    }
}