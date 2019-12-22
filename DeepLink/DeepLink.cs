using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLink : MonoBehaviour
{
    public static Action<string> OnReceived;
    static DeepLink instance;

    IDeepLinkHandler handler;

    public static void Init()
    {
        if (instance != null)
            return;
        instance = new GameObject("_DeepLinkReceiver").AddComponent<DeepLink>();
        DontDestroyOnLoad(instance.gameObject);

#if UNITY_ANDROID
        instance.handler = new AndroidDeepLinkHandler();
#elif UNITY_IOS
        instance.handler = new IosDeeplinkHandler();        
#else
        instance.handler = new DummyDeepLinkHandler();
#endif

        instance.handler.Init(instance);
    }

    public void HandleDeeplink(string link)
    {
        OnReceived?.Invoke(link);
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
            handler.Refresh();
    }

    private void OnApplicationFocus(bool focus)
    {
        OnApplicationPause(!focus);
    }
}

public class DummyDeepLinkHandler : IDeepLinkHandler
{
    public void Init(DeepLink receiver) { }
    public void Refresh() { }
}