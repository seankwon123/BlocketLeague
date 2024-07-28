using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMnemonic : MonoBehaviour
{
    public static DisplayMnemonic Instance;

    [SerializeField] private TextMeshProUGUI text;
    

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void Start()
    {
        UpdateMnemonicDisplay();
    }

    public void ResetText()
    {
        UpdateMnemonicDisplay();
    }

    private void UpdateMnemonicDisplay()
    {
        StartCoroutine(WaitABit());
        text.text = "I Like Rocket League and Blocks";
        Debug.Log("Get something from NFT");

    }

    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(5.0f);
    }

    // public string GetMnemonic()
    // {
    //     return text.text;
    // }


}