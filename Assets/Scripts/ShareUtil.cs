using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShareUtil  {

    private const string TWITTER_URL = "http://twitter.com/intent/tweet";

	
    private const string TWEET_LANGUAGE = "en";
    private static string caption = "OMG! This game is so impossible.";
    private const string description = " I got ";
    private static string gamePlayStoreLink = "https://play.google.com/store/apps/details?id=com.mrbunkyman.toughball";
    private const string androidHashtag = "#Android";
    private const string gameNameHastag = "#roughball";
    private const string unityHashTag = "#unity3d";
    private const string mrbunymanHashTag = "#mrbunyman";

    private const string FACEBOOK_APP_ID = "1997419540505523";
    private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed?";
    private const string APP_ID = "app_id=";
    private const string LINK = "&link=";
    private const string LINK_NAME = "&linkName=";
    private const string CAPTION = "&caption=";
    private const string DESCRIPTION = "&description=";

    public static void ShareOnTwitter(int score)
    {
        caption += " I scored " + score.ToString() + "!!!, Can you beat me? ";
        Application.OpenURL(TWITTER_URL + "?text=" + WWW.EscapeURL(caption+ "\nDOWNLOAD AT: "+ gamePlayStoreLink));
    }

    public static void ShareOnFacebook(int score)
    {

        string content = FACEBOOK_URL + APP_ID + FACEBOOK_APP_ID + LINK + gamePlayStoreLink + LINK_NAME + "Rough Ball" + CAPTION+ caption;
                        
        Application.OpenURL(content);
        Debug.Log(content);
    }
    
    

}
