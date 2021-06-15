using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    Text valueText;

    private void Start() {
        valueText = GetComponent<Text>();
    }

    public void valueUpdate(float value) {
        valueText.text = value.ToString();
    }
}
