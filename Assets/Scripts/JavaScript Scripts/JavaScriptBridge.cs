using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaScriptBridge : MonoBehaviour
{
    // Start is called before the first frame update
    public void CallJavaScriptFunction(string message)
    {
        Application.ExternalCall("receiveMessageFromUnity", message);
    }
}
