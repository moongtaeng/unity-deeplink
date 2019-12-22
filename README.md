# unity-deeplink
Unity Deep-Link handler for Android &amp; iOS

Example Usage:
```
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
