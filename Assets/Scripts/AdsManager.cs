using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
	public static AdsManager instance;
	private int counter;
	private string googlePlayId = "1616807";
	private string placementId = "rewardedVideo";

	private BannerView bannerView;
	private InterstitialAd interstitialAd;
	private string androidAppId = "ca-app-pub-2938110038729136~1064993915"; // for inititalizing mobile ads
	private string androidBannerId = "ca-app-pub-2938110038729136/1845213806"; // for banner ads on android
	private string androidInterstitielId = "ca-app-pub-2938110038729136/5204345638"; // for interstitial ads on android

	private int numberOfRestartToShowClipAds = 22;
	private int numberOfRestartToShowInterstitialAds = 5;
	
	public void ShowAds () // game manager will use this 
	{
		counter++;
		
		if (counter % numberOfRestartToShowInterstitialAds == 0 && counter != 0)
		{
			if (interstitialAd.IsLoaded())
			{
				//Debug.Log("Show interstitialAd");
				interstitialAd.Show();
			}
		}
		else if (counter % numberOfRestartToShowClipAds == 0 && counter!=0)
		{
			//Debug.Log("Show video ad");
			ShowOptions options = new ShowOptions();
			options.resultCallback = HandleShowResult;
	
			Advertisement.Show(placementId, options);
			//admobs
			counter = 0;
		}
		else
		{
			return;
		}
	}
	
	void Start ()
	{
		if (instance)
			Destroy(gameObject);
		else
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
			if (Advertisement.isSupported) {
				// Unity ad
				Advertisement.Initialize (googlePlayId, true);
			}
			#if UNITY_ANDROID
					MobileAds.Initialize(androidAppId);
			#endif
			StartBannerAd();
			StartInterstitialAd();
			

		}

	}
	
	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished)
		{
			Debug.Log("Finished");

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}



	private void StartBannerAd()
	{
		//Debug.Log("show banner ads");
//
//		string testAdId = "ca-app-pub-3940256099942544/6300978111";
//		string testDeviceId = "2077ef9a63d2b398840261c8221a0c9b";

		//***For Testing in the Device***
//		AdRequest request = new AdRequest.Builder()
//			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
//			.AddTestDevice(testDeviceId)  // My test device.
//			.Build();
		//***For Production When Submit App***
		//AdRequest request = new AdRequest.Builder().Build();
		bannerView = new BannerView(androidBannerId, AdSize.SmartBanner, AdPosition.Bottom);
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
		bannerView.Show();
	}

	private void StartInterstitialAd()
	{
//		string testId = "ca-app-pub-3940256099942544/1033173712";
		interstitialAd = new InterstitialAd(androidInterstitielId);
		interstitialAd.OnAdClosed += HandleOnAdClosed;
		//AdRequest request = new AdRequest.Builder().Build();
		//test 
		RequestIntersitialAd();
	}

	void RequestIntersitialAd()
	{
		
//		AdRequest request = new AdRequest.Builder()
//			.AddTestDevice(AdRequest.TestDeviceSimulator)
//			.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
//			.Build();
		AdRequest request = new AdRequest.Builder().Build();
		interstitialAd.LoadAd(request);
	}
	void HandleOnAdClosed(object sender, EventArgs args)
	{
		RequestIntersitialAd();
	}
}
	

//	void RequestBanner()
//	{
//		string appId;
//		#if UNITY_ANDROID
//		appId = androidAppId;
//		#endif
//		bannerView = new BannerView(sampleAppId, AdSize.Banner, AdPosition.Bottom);
//		AdRequest request = new AdRequest.Builder().Build();
//		bannerView.LoadAd(request);
//	}

//		string testAdId = "ca-app-pub-3940256099942544/6300978111";
//		string testDeviceId = "2077ef9a63d2b398840261c8221a0c9b";

//		//***For Testing in the Device***
//		AdRequest request = new AdRequest.Builder()
//			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
//			.AddTestDevice(testDeviceId)  // My test device.
//			.Build();