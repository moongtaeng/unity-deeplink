using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IosDeeplinkHandler : IDeepLinkHandler
{
    public void Init(DeepLink receiver)
    {
#if !UNITY_EDITOR && UNITY_IOS
        UnityDeeplinks_init(receiver.gameObject.name, "HandleDeeplink");
#endif
    }

    public void Refresh()
    { }

#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern void UnityDeeplinks_init(string gameObject = null, string deeplinkMethod = null);
#endif
}
