using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        inputField.onSelect.AddListener(delegate { OpenKeyboard(); });
    }

    void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}

