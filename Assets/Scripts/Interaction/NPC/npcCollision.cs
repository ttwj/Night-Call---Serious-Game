using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCollision : MonoBehaviour
{
    public GameObject canvas;
    private Dictionary<string, string> textDatabase = new Dictionary<string, string>();
    private Dictionary<string, string> textHBPDatabase = new Dictionary<string, string>();
    private Dictionary<string, string> textPneumoniaDatabase = new Dictionary<string, string>();
    private Dictionary<int, string> helpHBP = new Dictionary<int, string>();
    private Dictionary<int, string> helpPneumonia = new Dictionary<int, string>();
    private bool keyOptionOne; // history
    private bool keyOptionTwo; // condition
    private bool keyOptionThree; // treatment choice
    private bool keyOptionFour; // treatment 1
    private bool keyOptionFive; // treatment 2
    private bool keyHelp; // help
    private bool keySwitch; // switch status
    private int helpCount = 2;
    private string patientStatus = "High Blood Pressure";

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        // canvas.transform.GetChild(0).gameObject.SetActive(true);
        // canvas.transform.GetChild(1).gameObject.SetActive(false);

        // Set up general text database
        textDatabase.Add("start", "Hello. How would you like to treat the patient?");
        textDatabase.Add("history", "Checking patient history...");
        textDatabase.Add("treatmentChoice", "What treatment would you like to administer?");
        
        // Set up High Blood Pressure text database
        textHBPDatabase.Add("drugNifedipine60mg", "Administering Nifedipine 60mg");
        textHBPDatabase.Add("condition", "Patient has cold sweat");
        helpHBP.Add(0, "No hints left!");
        helpHBP.Add(2, "Hint 1: Patient may have high blood pressure");
        helpHBP.Add(1, "Hint 2: Administer Nifedipine 60mg");

        // Set up Pneumonia text database
        textPneumoniaDatabase.Add("oxygen3l", "Administering oxygen 3 litres");
        textPneumoniaDatabase.Add("fluid250ml", "Administering fluid 250ml");
        textPneumoniaDatabase.Add("condition", "Patient has breathlessness");
        helpPneumonia.Add(0, "No hints left!");
        helpPneumonia.Add(2, "Hint 1: Patient may have pneumonia");
        helpPneumonia.Add(1, "Hint 2: Administer Oxygen 3 litres and fluid 250ml");
    }

    // Update is called once per frame
    void Update()
    {   
        // Set up input keys
        keyOptionOne = Input.GetKeyDown(KeyCode.Alpha1); // history
        keyOptionTwo = Input.GetKeyDown(KeyCode.Alpha2); // condition
        keyOptionThree = Input.GetKeyDown(KeyCode.Alpha3); // treatment choice
        keyOptionFour = Input.GetKeyDown(KeyCode.Alpha4); // treatment 1
        keyOptionFive = Input.GetKeyDown(KeyCode.Alpha5); // treatment 2
        keyHelp = Input.GetKeyDown(KeyCode.H); // help
        keySwitch = Input.GetKeyDown(KeyCode.C); // switch status
        
        // // Cases for text to appear
        // if (keyOptionOne)
        //     {
        //         canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["history"];
        //     }
        // if (keyOptionThree)
        //     {
        //         canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["treatmentChoice"];
        //     }
        // if (keySwitch)
        //     {
        //         helpCount = 2;
        //         if (patientStatus == "High Blood Pressure") {
        //             patientStatus = "Pneumonia";
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Switched to pneumonia case";
        //         }
        //         else if (patientStatus == "Pneumonia") {
        //             patientStatus = "High Blood Pressure";
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Switched to high blood pressure case";
        //         }
        //     }

        // if (patientStatus == "High Blood Pressure") {
        //     if (keyOptionTwo)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["condition"];
        //         }
        //     if (keyOptionFour)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["drugNifedipine60mg"];
        //         }
        //     if (keyHelp)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = helpHBP[helpCount];
        //             if (helpCount > 0) {
        //                 helpCount -= 1;
        //             }
        //         }
        // }

        // if (patientStatus == "Pneumonia") {
        //     if (keyOptionTwo)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["condition"];
        //         }
        //     if (keyOptionFour)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["oxygen3l"];
        //         }
        //     if (keyOptionFive)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["fluid250ml"];
        //         }
        //     if (keyHelp)
        //         {
        //             canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = helpPneumonia[helpCount];
        //             if (helpCount > 0) {
        //                 helpCount -= 1;
        //             }
        //         }
        // }
    }

    private void OnTriggerEnter(Collider other) {
            Debug.Log("Trigger Entered");
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["start"];
            // if (other.CompareTag("Doctor")) {
            //     Debug.Log("Open chat");
            //     canvas.gameObject.SetActive(true);
            // }
        }

    private void OnTriggerExit(Collider other) {
            Debug.Log("Trigger Exit");
            canvas.gameObject.SetActive(false);
            // if (other.CompareTag("Doctor")) {
            //     canvas.gameObject.SetActive(false);
            //     // canvas.transform.GetChild(0).gameObject.SetActive(true);
            //     // canvas.transform.GetChild(1).gameObject.SetActive(false);
            // }
        }
    
    private void ShowTextOption(keyOptionOne, keyOptionTwo, keyOptionThree, keyOptionFour, keyOptionFive, keyHelp, keySwitch) {
            // Cases for text to appear
            if (keyOptionOne)
                {
                    canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["history"];
                }
            if (keyOptionThree)
                {
                    canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["treatmentChoice"];
                }
            if (keySwitch)
                {
                    helpCount = 2;
                    if (patientStatus == "High Blood Pressure") {
                        patientStatus = "Pneumonia";
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Switched to pneumonia case";
                    }
                    else if (patientStatus == "Pneumonia") {
                        patientStatus = "High Blood Pressure";
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Switched to high blood pressure case";
                    }
                }

            if (patientStatus == "High Blood Pressure") {
                if (keyOptionTwo)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["condition"];
                    }
                if (keyOptionFour)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["drugNifedipine60mg"];
                    }
                if (keyHelp)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = helpHBP[helpCount];
                        if (helpCount > 0) {
                            helpCount -= 1;
                        }
                    }
            }

            if (patientStatus == "Pneumonia") {
                if (keyOptionTwo)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["condition"];
                    }
                if (keyOptionFour)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["oxygen3l"];
                    }
                if (keyOptionFive)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textPneumoniaDatabase["fluid250ml"];
                    }
                if (keyHelp)
                    {
                        canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = helpPneumonia[helpCount];
                        if (helpCount > 0) {
                            helpCount -= 1;
                        }
                    }
            }
    }
}
