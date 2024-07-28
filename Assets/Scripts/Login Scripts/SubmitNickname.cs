using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Runtime.InteropServices;

public class SubmitNickname : MonoBehaviour
{
    public Button btn;
    public TMP_InputField userInput;

    [DllImport("__Internal")]
    private static extern void CreateAccountJS(string nickname);

    void Start()
    {
        btn.onClick.AddListener(GetInputOnClick);
    }

    private void GetInputOnClick()
    {
        Debug.Log("createAccount start");
        #if UNITY_WEBGL && !UNITY_EDITOR
            CreateAccountJS(userInput.text);
        #else
            Debug.Log("CreateAccountJS is only available in WebGL builds");
        #endif
        Debug.Log("createAccount done");
    }

}
