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

    [DllImport("create-account")]
    private static extern void createAccount(string nickname);

    void Start()
    {
        btn.onClick.AddListener(GetInputOnClick);
    }

    private void GetInputOnClick()
    {
        // Debug.Log("Nickname is: "+ userInput.text);
        Debug.Log("createAccount start");
        createAccount(userInput.text);
        Debug.Log("createAccount done");
    }

}
