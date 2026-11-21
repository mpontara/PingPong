using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class InputName : MonoBehaviour
{

    public bool isPlayer = true;
    public TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }

    // Update is called once per frame
    private void UpdateName(string name)
    {
        
        if(isPlayer)
            SaveController.Instance.namePlayer = name;
        else
            SaveController.Instance.nameEnemy = name;
    }
}
