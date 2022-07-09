using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentInteraction : MonoBehaviour
{
    //Array of images to cater for different patient conditions, i.e. healthy / abnormal readings
    public Image[] PatientMonitorScreen;
    public Image[] ECG;

    // Start is called before the first frame update
    void Start()
    {
        //Do not display any images on screen at the start of the game
        foreach (Image i in PatientMonitorScreen)
        {
            i.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
     {
         Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
         RaycastHit hit;
         
         if( Physics.Raycast( ray, out hit, 100 ) )
         {
             if (hit.transform.gameObject.CompareTag("PatientMonitor"))
             {
                 PatientMonitorScreen[0].enabled = true;
             }
             Debug.Log( hit.transform.gameObject.name );
         }
     }
    }
}
