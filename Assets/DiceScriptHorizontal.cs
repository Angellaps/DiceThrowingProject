using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceScriptHorizontal : MonoBehaviour {

    public Vector3 standardForce = new Vector3(0.0f, 5f, 0.0f);
    public Rigidbody rb;
    public static Vector3 velocity;
    public Vector3 initialPos;
    public Text totalThrows;
    public Text oneText, twoText, threeText, fourText, fiveText, sixText, errorText;
    public GameObject floor;
    public GameObject testOverUI;
    public bool testOverFlag = false;
    Transform[] children;

    void Start() {
        testOverUI = GameObject.Find("Test Over");
        children = testOverUI.GetComponentsInChildren<Transform>(true);
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        //Still using PlayerPrefs cause the whole program was initially made so you can change
        //some of its parameters in editor mode. If there's time will rewrite and edit all the
        //prefabs to not use PlayerPrefs anymore since we don't need this anymore.

        ClearDB();

        oneText = GameObject.Find("1Counter").GetComponent<Text>();
        twoText = GameObject.Find("2Counter").GetComponent<Text>();
        threeText = GameObject.Find("3Counter").GetComponent<Text>();
        fourText = GameObject.Find("4Counter").GetComponent<Text>();
        fiveText = GameObject.Find("5Counter").GetComponent<Text>();
        sixText = GameObject.Find("6Counter").GetComponent<Text>();
        errorText = GameObject.Find("ErrorCounter").GetComponent<Text>();
        totalThrows = GameObject.Find("TotalThrowsText").GetComponent<Text>();
        UpdateUI();
        NewThrow();
    }

    void Update() {
        velocity = rb.velocity;
        //When the die has stopped moving, find the empty object attached to each side with the lowest y.
        //That side is the one touching the ground.
        //Calling GetResult of that attachment to get the side opposite to the one touching the ground
        //AKA the Result
        if (velocity == Vector3.zero) {

            foreach (Transform child in transform) {
                if (child.transform.position.y < floor.transform.position.y) {
                    UpdateDatabase(GetResult(child));
                    UpdateUI();
                }
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            NewThrow();
        }

        if (rb.position.y > 1000.0f || rb.position.y < -1000.0f) {
            UpdateDatabase(0);
            NewThrow();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (testOverFlag == true) {
                ClearDB();
                Time.timeScale = 1.0f;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    //Variables for the dice tossing.
    void NewThrow() {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = initialPos + new Vector3(0, Random.Range(-0.0f, 4.0f), 0);
        transform.rotation = Quaternion.identity;
        Vector3 forceVariance = new Vector3(Random.Range(-200.0f, -50.0f), Random.Range(0.5f, 5.0f), Random.Range(-8.0f, 8.0f));
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

    //Update the Database. Using PlayerPrefs to not lose data.
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
        if (PlayerPrefs.GetInt("Total") >= GameObject.Find("EnvironmentCreator").GetComponent<Creation>().totalThrowGoal) {
            UpdateUI();

            foreach (Transform child in children) {
                child.gameObject.SetActive(true);
            }

            //Save on Excel Database

            testOverFlag = true;
            if (Time.timeScale != 0.0f) {
                Time.timeScale = 0.0f;
            }
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
        errorText.text = PlayerPrefs.GetInt("faulty toss").ToString();
    }

    void ClearDB() {
        PlayerPrefs.SetInt("Total", 0);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);
        PlayerPrefs.SetInt("4", 0);
        PlayerPrefs.SetInt("5", 0);
        PlayerPrefs.SetInt("6", 0);
        PlayerPrefs.SetInt("faulty toss", 0);
    }
}