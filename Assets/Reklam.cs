using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklam : MonoBehaviour {

    InterstitialAd interstitial;
    static Reklam reklamKontrol;

    void Start () {

        if (reklamKontrol==null)
        {

            DontDestroyOnLoad(gameObject);//sahneler arası objeler silinmiyor.
            reklamKontrol = this;
            //1.aşama----------
#if UNITY_ANDROID
            string appId = "ca-app-pub-5961913907607762~1742359067";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);
            //2.aşama----------
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

            // Initialize an InterstitialAd.
            interstitial = new InterstitialAd(adUnitId);

            //3.aşama----------
            AdRequest request = new AdRequest.Builder()
              .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
              .Build();
            interstitial.LoadAd(request);
            //4.aşama-------


        }
        else
        {
            Destroy(gameObject);

        }



    }
	
	
	public void reklamıgöster () {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }

    }
}
