using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentInteraction : MonoBehaviour
{
    //Array of images to cater for different patient conditions, i.e. healthy / abnormal readings
    public Image[] PatientMonitorScreen;
    public Image[] ECG;
    public Button closeButtonX;
    private Image activeImage;

    void Start()
    {
        foreach (Image i in PatientMonitorScreen)
        {
            i.enabled = false;
        }

        activeImage = null;
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

                //if player clicks on a patient monitor, show the corresponding image and a close button
                //display image according to the patient's health, wait till later implementation
                if (hit.transform.gameObject.CompareTag("PatientMonitor"))
                {
                    PatientMonitorScreen[0].enabled = true;
                    activeImage = PatientMonitorScreen[0];
                    closeButtonX.gameObject.SetActive(true);
                }
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }

    void closeImage()
    {   
        closeButtonX.gameObject.SetActive(false);
        activeImage.enabled = false;
        activeImage = null;
    }
}
