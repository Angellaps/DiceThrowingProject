using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    //info to save
    int ones, twos, threes, fours, fives, sixes, errors;
    string mode;
    public GameObject creator;
    int surfaces, diceAmount;
    int totalThrows;


    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/Database/Database.csv";
    }

    // Update is called once per frame
    public void WriteCSV() {
        totalThrows = PlayerPrefs.GetInt("Total");
        ones = PlayerPrefs.GetInt("1");
        twos = PlayerPrefs.GetInt("2");
        threes = PlayerPrefs.GetInt("3");
        fours = PlayerPrefs.GetInt("4");
        fives = PlayerPrefs.GetInt("5");
        sixes = PlayerPrefs.GetInt("6");
        errors = PlayerPrefs.GetInt("faulty toss");
        mode = creator.GetComponent<Creation>().modeSelected;
        if (mode == "Vertical Throw") {
            mode = "Vertical";
        }
        else if(mode == "Horizontal Throw") {
            mode = "Horizontal";
        }
        surfaces = creator.GetComponent<Creation>().boardAmount;
        diceAmount = creator.GetComponent<Creation>().diceAmount;

        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(mode + "," + surfaces + "," + diceAmount + "," + totalThrows + "," + ones + ",," + twos + ",," + threes + ",," + fours + ",," + fives + ",," + sixes + ",," + errors);
        tw.Close();

    }

    public void DisableButton() {
        GetComponent<Button>().interactable = false;
        Text text = GetComponentInChildren<Text>();
        text.text = "<b>DATA SAVED</b>";
    }
}
