using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeepLinkHandler
{
    void Init(DeepLink receiver);
    void Refresh();
}
