using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chatbox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBox;
    
    public void SetText(string text)
    {
        textBox.text = text;
    }
}
