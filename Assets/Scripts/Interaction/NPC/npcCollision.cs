using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCollision : MonoBehaviour
{
    public GameObject canvas;
    private Dictionary<string, string> textDatabase = new Dictionary<string, string>();
    private Dictionary<string, string> textHBPDatabase = new Dictionary<string, string>();
    private Dictionary<int, string> helpHBP = new Dictionary<int, string>();
    private bool keyOptionOne;
    private bool keyOptionTwo;
    private bool keyOptionThree;
    private bool keyOptionFour;
    private bool keyHelp;
    private int helpCount = 2;
    private string patientStatus = "HBP";

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        // canvas.transform.GetChild(0).gameObject.SetActive(true);
        // canvas.transform.GetChild(1).gameObject.SetActive(false);
        textDatabase.Add("start", "Hello. How would you like to treat the patient?");
        
        textDatabase.Add("history", "Checking patient history...");
        textDatabase.Add("drugChoice", "What drug would you like to administer?");
        textHBPDatabase.Add("drugNifedipine60mg", "Administering Nifedipine 60mg");
        textHBPDatabase.Add("condition", "Patient has breathlessness and cold sweat");
        
        helpHBP.Add(0, "No hints left!");
        helpHBP.Add(2, "Hint 1: Patient may need a drug for high blood pressure");
        helpHBP.Add(1, "Hint 2: Administer Nifedipine 60mg");
    }

    // Update is called once per frame
    void Update()
    {   
        keyOptionOne = Input.GetKeyDown(KeyCode.Alpha1);
        if (keyOptionOne)
            {
                canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["history"];
            }
        keyOptionTwo = Input.GetKeyDown(KeyCode.Alpha2);
        if (keyOptionTwo)
            {
                canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textDatabase["drugChoice"];
            }
        
        if (patientStatus == "HBP") {
            keyOptionThree = Input.GetKeyDown(KeyCode.Alpha3);
            if (keyOptionThree)
                {
                    canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["drugNifedipine60mg"];
                }
            keyOptionFour = Input.GetKeyDown(KeyCode.Alpha4);
            if (keyOptionFour)
                {
                    canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = textHBPDatabase["condition"];
                }

            keyHelp = Input.GetKeyDown(KeyCode.H);
            if (keyHelp)
                {
                    canvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = helpHBP[helpCount];
                    if (helpCount > 0) {
                        helpCount -= 1;
                    }
                }

        }
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
}
