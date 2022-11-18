using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banner : MonoBehaviour
{
    public string bannerID;

    private BannerView Banner_;

    void Start()
    {


        Banner_ = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest reklamistek = new AdRequest.Builder().Build();

        Banner_.LoadAd(reklamistek);

        Banner_.Show();

    }

   
}
