using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDeepLinkHandler : IDeepLinkHandler
{
    const string ACTION_VIEW = "android.intent.action.VIEW";
    DeepLink receiver;

    public void Init(DeepLink receiver)
    {
        this.receiver = receiver;
        Refresh();
    }

    public void Refresh()
    {
#if !UNITY_EDITOR
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
        string intentAction = intent.Call<string>("getAction");
        if (intentAction == ACTION_VIEW)
        {
            var link = intent.Call<string>("getDataString");
            if (link != null)
            {
                intent.Call("setData", null);
                receiver.HandleDeeplink(link);
            }
        }
#endif
    }
}
