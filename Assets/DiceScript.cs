using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour {

    public Vector3 standardForce = new Vector3(0.0f, 5f, 0.0f);
    public Rigidbody rb;
    public static Vector3 velocity;
    public Vector3 initialPos;
    public Text totalThrows;
    public Text oneText, twoText, threeText, fourText, fiveText, sixText, errorText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        UpdateUI();
        //Uncomment to clear database cause PlayerPrefs is scuffed like this
        //
        //PlayerPrefs.SetInt("Total", 0);
        //PlayerPrefs.SetInt("1", 0);
        //PlayerPrefs.SetInt("2", 0);
        //PlayerPrefs.SetInt("3", 0);
        //PlayerPrefs.SetInt("4", 0);
        //PlayerPrefs.SetInt("5", 0);
        //PlayerPrefs.SetInt("6", 0);
        //PlayerPrefs.SetInt("faulty toss", 0);
        NewThrow();       
    }

    void Update() {
        velocity = rb.velocity;

        if (velocity == Vector3.zero) {

            foreach (Transform child in transform) {
                if (child.transform.position.y < 0) {                    
                    UpdateDatabase(GetResult(child));
                    UpdateUI();
                }
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            NewThrow();
        }

    }

    void NewThrow() {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = initialPos + new Vector3(0, Random.Range(-2.5f, 1.5f), 0);
        transform.rotation = Quaternion.identity;
        Vector3 forceVariance = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(25.0f, 70.0f), Random.Range(-5.0f, 5.0f));
        rb.AddForce(forceVariance);
        rb.AddTorque(dirX, dirY, dirZ);
    }

    //Get the opposite side of the one touching the ground aka the actual result
    int GetResult(Transform child) {
        switch (child.name) {
            case "Side1":
                return 6;
            case "Side2":
                return 5;
            case "Side3":
                return 4;
            case "Side4":
                return 3;
            case "Side5":
                return 2;
            case "Side6":
                return 1;
            default:
                return 0;
        }
    }

    void UpdateDatabase(int result) {
        switch (result) {
            case 1:
                PlayerPrefs.SetInt("1", PlayerPrefs.GetInt("1") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '1' in the database.");
                break;
            case 2:
                PlayerPrefs.SetInt("2", PlayerPrefs.GetInt("2") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '2' in the database.");
                break;
            case 3:
                PlayerPrefs.SetInt("3", PlayerPrefs.GetInt("3") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '3' in the database.");
                break;
            case 4:
                PlayerPrefs.SetInt("4", PlayerPrefs.GetInt("4") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '4' in the database.");
                break;
            case 5:
                PlayerPrefs.SetInt("5", PlayerPrefs.GetInt("5") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '5' in the database.");

                break;
            case 6:
                PlayerPrefs.SetInt("6", PlayerPrefs.GetInt("6") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                Debug.Log("Added result '6' in the database.");
                break;
            case 0:
                PlayerPrefs.SetInt("faulty toss", PlayerPrefs.GetInt("faulty toss") + 1);
                PlayerPrefs.SetInt("Total", PlayerPrefs.GetInt("Total") + 1);
                break;
        }        
    }

    void UpdateUI() {
        totalThrows.text = PlayerPrefs.GetInt("Total").ToString();
        oneText.text = PlayerPrefs.GetInt("1").ToString();
        twoText.text = PlayerPrefs.GetInt("2").ToString();
        threeText.text = PlayerPrefs.GetInt("3").ToString();
        fourText.text = PlayerPrefs.GetInt("4").ToString();
        fiveText.text = PlayerPrefs.GetInt("5").ToString();
        sixText.text = PlayerPrefs.GetInt("6").ToString();
    }
}
