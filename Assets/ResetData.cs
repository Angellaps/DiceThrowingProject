using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetData : MonoBehaviour {

    public Text totalThrows;
    public Text oneText, twoText, threeText, fourText, fiveText, sixText, errorText;


    public void Reset_Data() {
        PlayerPrefs.SetInt("Total", 0);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);
        PlayerPrefs.SetInt("4", 0);
        PlayerPrefs.SetInt("5", 0);
        PlayerPrefs.SetInt("6", 0);
        PlayerPrefs.SetInt("faulty toss", 0);
        UpdateUI();
    }

    void UpdateUI() {
        totalThrows.text = PlayerPrefs.GetInt("Total").ToString();
        oneText.text = PlayerPrefs.GetInt("1").ToString();
        twoText.text = PlayerPrefs.GetInt("2").ToString();
        threeText.text = PlayerPrefs.GetInt("3").ToString();
        fourText.text = PlayerPrefs.GetInt("4").ToString();
        fiveText.text = PlayerPrefs.GetInt("5").ToString();
        sixText.text = PlayerPrefs.GetInt("6").ToString();
        errorText.text = PlayerPrefs.GetInt("faulty toss").ToString();
    }
}