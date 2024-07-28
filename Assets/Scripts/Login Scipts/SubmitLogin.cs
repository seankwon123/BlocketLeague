using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitLogin : MonoBehaviour
{

    public Button btn;
    public TMP_InputField userInput;


    void Start()
    {
        btn.onClick.AddListener(GetInputOnClick);
    }

    private void GetInputOnClick()
    {
        Debug.Log("Text is: "+ userInput.text);
    }

}
