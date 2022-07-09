using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EquipmentInteraction : MonoBehaviour
{
    //Array of images to cater for different patient conditions, i.e. healthy / abnormal readings
    public Image[] PatientMonitorScreen;
    public GameObject[] medicationVials;
    public Button closeButtonX;
    public Text instructions;
    public Animator anim;
    private Image activeImage;
    private Vector3 cameraPos;
    private GameObject target;
    private string selectedObj;
    public string ongoingTask;

    //list of tasks:
    //  [IVbagInjection, FinishedSelectingVial]


    void Start()
    {
        foreach (Image i in PatientMonitorScreen)
        {
            i.enabled = false;
        }

        activeImage = null;

        instructions.enabled = false;

        anim = GameObject.Find("Syringe").GetComponent<Animator>();

        closeButtonX.gameObject.SetActive(false);
        closeButtonX.onClick.AddListener(closeImage);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("PatientMonitor")) { showPatientMonitorReadings(); }

                if (hit.transform.gameObject.CompareTag("IV Stand"))
                {
                    IVbagInjection();
                }

                if (hit.transform.gameObject.CompareTag("Medication Vial") && ongoingTask == "IVbagInjection")
                {
                    selectedObj = hit.transform.gameObject.name;
                    IVbagInjectionCont(selectedObj);
                }

                if (hit.transform.gameObject.name == "Syringe" && ongoingTask == "FinishedSelectingVial")
                {
                    anim.Play("SyringeAnim");
                }

                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }

    void showPatientMonitorReadings()
    {
        PatientMonitorScreen[0].enabled = true;
        activeImage = PatientMonitorScreen[0];
        closeButtonX.gameObject.SetActive(true);
    }

    void closeImage()
    {
        closeButtonX.gameObject.SetActive(false);
        activeImage.enabled = false;
        activeImage = null;
    }

    void IVbagInjection()
    {
        cameraPos = Camera.main.transform.position;
        target = GameObject.Find("MedicationVials");
        changeCamPos(target);

        instructions.text = "Choose the medication to inject into the IV drip bag.";
        instructions.enabled = true;

        ongoingTask = "IVbagInjection";
    }

    void IVbagInjectionCont(string selectedObj)
    {
        GameObject currentVial;

        //remove all vials that were not selected, shift selected vial to center of table

        if (selectedObj == "Medication Vial 1")
        {
            currentVial = medicationVials[0];

            foreach (GameObject v in medicationVials[1..])
            {
                v.SetActive(false);
            }
            StartCoroutine(MoveFunction(currentVial));
        }

        if (selectedObj == "Medication Vial 2")
        {
            currentVial = medicationVials[1];

            medicationVials[0].SetActive(false);
            medicationVials[2].SetActive(false);
            medicationVials[3].SetActive(false);
            StartCoroutine(MoveFunction(currentVial));
        }

        if (selectedObj == "Medication Vial 3")
        {
            currentVial = medicationVials[2];

            medicationVials[0].SetActive(false);
            medicationVials[1].SetActive(false);
            medicationVials[3].SetActive(false);
            StartCoroutine(MoveFunction(currentVial));
        }

        if (selectedObj == "Medication Vial 4")
        {
            currentVial = medicationVials[3];

            foreach (GameObject v in medicationVials[..3])
            {
                v.SetActive(false);
            }
            StartCoroutine(MoveFunction(currentVial));
        }

        ongoingTask = "FinishedSelectingVial";
    }

    IEnumerator MoveFunction(GameObject currentVial)
    {
        while (true)
        {
            Vector3 startPos = currentVial.transform.position;
            Vector3 newPos = target.transform.position + new Vector3(0, -0.042f, 0.05f);

            currentVial.transform.position = Vector3.Lerp(startPos, newPos, 2 * Time.deltaTime);
            Debug.Log("I am enumerating");
            Debug.Log("Current pos: " + currentVial.transform.position + ", New pos: " + newPos);

            // If the object has arrived, stop the coroutine
            if (currentVial.transform.position == newPos)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    //to "switch scene"
    void changeCamPos(GameObject target)
    {
        Camera.main.transform.position = target.transform.position + new Vector3(0.8f, 0.3f, 0);
        Camera.main.transform.LookAt(target.transform);
    }
}