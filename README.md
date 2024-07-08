# unity-admob-integration-sample
A unity project with AdMob mediation integration.

This repository contains a sample project implementing the AdMob SDK for displaying interstitial, rewarded, and banner ads.


https://github.com/Hir-o/unity-admob-integration-sample/assets/136099316/4ecd9536-11fe-4a63-902a-53fdfc7b0b57


Instructions:

1. Get the AdMob Unity Plugin from the official repository: https://github.com/googleads/googleads-mobile-unity/releases
2. Import the AdMob package inside your unity project (Ensure that you have the IOS and Android modules installed in your unity editor)
3. Download my AdMob integration package: https://github.com/Hir-o/unity-admob-integration-sample/releases
4. Import the AdMob integration package inside Unity
5. Locate the @AdsManager prefab in the AdMobIntegration/Prefabs directory and drag and drop the @AdsManager prefab into your scene.
6. Select the @AdsManager prefab and add your App Id, Banner Id, Inter Id, and Rewarded Id. You can get these Id's from your Google AdMob account dashboard. Alternatively you can use the below testing ID's.

      appID: ca-app-pub-3940256099942544~3347511713

      Android:

      bannerId: ca-app-pub-3940256099942544/6300978111

      interid: ca-app-pub-3940256099942544/1033173712

      rewardedId: ca-app-pub-3940256099942544/5224354917

      nativeId: ca-app-pub-3940256099942544/2247696110

      IOS:

      bannerId: ca-app-pub-3940256099942544/2934735716

      interid: ca-app-pub-3940256099942544/4411468910

      rewardedId: ca-app-pub-3940256099942544/1712485313

      nativeId: ca-app-pub-3940256099942544/3986624511

7. Open the google mobile ads settings and add the app id.

![image](https://github.com/Hir-o/unity-admob-integration-sample/assets/136099316/4b3b7e3f-240f-4e1c-ad19-7dfe65919794)

8. Force resolve libraries

![image](https://github.com/Hir-o/unity-admob-integration-sample/assets/136099316/6a3fec2a-bf70-48b3-98b9-cdde2db1f5ce)

9. Go to player > publishing settings and add a keystore and apply these settings:

![image](https://github.com/Hir-o/unity-admob-integration-sample/assets/136099316/3ebf1343-faae-4671-a608-ebf1e7fadad9)

10. Rejoice!

# Admob sample

The sample projects uses the editor versioin: 2022.3.21f1
The provided sample project includes a scene with the @AdsManager prefab and an example demonstrating how to load and show ads. The AdsManager.cs script is a singleton, making it easy to reference from other scripts, such as ScorePresenter.cs, which is attached to the Canvas. This script shows how ads are initialized and how events are used to increase the score after watching an ad.

By following these steps, you should be able to integrate AdMob ads into your Unity project successfully.

