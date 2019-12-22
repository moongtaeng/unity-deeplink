# Deep-Link handler for Unity
Unity Deep-Link handler for Android &amp; iOS, without overriding UnityPlayerActivity.

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
In AndroidManifest, the main activity section add (with your scheme and host):
```XML
<intent-filter>
  <action android:name="android.intent.action.VIEW"/>
  <category android:name="android.intent.category.DEFAULT"/>
  <category android:name="android.intent.category.BROWSABLE"/>
  <data
      android:host="myhost.com"
      android:scheme="myscheme"/>
</intent-filter>
```

--

iOS Plugin (Not Tested!) From: https://github.com/TROPHiT/UnityDeeplinks
