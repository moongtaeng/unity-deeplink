# unity-deeplink
Unity Deep-Link handler for Android &amp; iOS

Example Usage:
```C#
void Start()
{
  DeepLink.Init();
  DeepLink.OnReceived += OnReceived;
}

void OnReceived(string link)
{
  Debug.Log("DeepLink received: " + link);
}
```
--

iOS Plugin (Not Tested!) From: https://github.com/TROPHiT/UnityDeeplinks
