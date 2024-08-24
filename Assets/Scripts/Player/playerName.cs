using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerName : MonoBehaviour
{
    public string nameOfPlayer;
    public string saveName;

    public Text loadedName;
    public InputField inputText;

    void Start()
    {
            
    }

    void Update()
    {
        nameOfPlayer = PlayerPrefs.GetString("name", "none");
        loadedName.text = nameOfPlayer;
    }

    public void SetName() 
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }
}
