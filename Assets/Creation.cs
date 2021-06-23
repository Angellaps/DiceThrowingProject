using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creation : MonoBehaviour {
    public Dropdown modeSelection;
    string modeSelected;
    public Text boardAmountText, diceAmountText;
    int boardAmount, diceAmount;

    public GameObject VB1D, VB2D, VB3D, VB4D, VB5D, VB6D;
    public GameObject HB1D, HB2D, HB3D, HB4D, HB5D, HB6D;
    GameObject PrefabSelected;

    public GameObject MainMenu;
    public GameObject ResultsCanvas;




    public void Create() {

        boardAmount = int.Parse(boardAmountText.text);
        diceAmount = int.Parse(diceAmountText.text);
        modeSelected = modeSelection.options[modeSelection.value].text;

        switch (modeSelected) {
            case "Vertical Throw":
                switch (diceAmount) {
                    case 1:
                        PrefabSelected = VB1D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 2:
                        PrefabSelected = VB2D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 3:
                        PrefabSelected = VB3D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 4:
                        PrefabSelected = VB4D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 5:
                        PrefabSelected = VB5D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 6:
                        PrefabSelected = VB6D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    default:
                        Debug.Log("ERROR");
                        break;
                }
                break;
            case "Horizontal Throw":
                switch (diceAmount) {
                    case 1:
                        PrefabSelected = HB1D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 2:
                        PrefabSelected = HB2D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 3:
                        PrefabSelected = HB3D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 4:
                        PrefabSelected = HB4D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 5:
                        PrefabSelected = HB5D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    case 6:
                        PrefabSelected = HB6D;
                        Debug.Log(modeSelected + " " + boardAmount + " " + diceAmount);
                        break;
                    default:
                        Debug.Log("ERROR");
                        break;
                }
                break;
            default:
                Debug.Log("Selection ERROR");
                break;
        }
                MainMenu.SetActive(false);
                ResultsCanvas.SetActive(true);
                CreatePrefabs(PrefabSelected, boardAmount);
        }

        public void CreatePrefabs(GameObject GO, int amount) {
            for (int i = 0; i < amount; i++) {
                Instantiate(GO, new Vector3(0, 0, i*30), Quaternion.identity);
            }

        }
    }
