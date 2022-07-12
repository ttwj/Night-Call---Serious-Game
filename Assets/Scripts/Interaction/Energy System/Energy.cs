using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{
    private TextMeshProUGUI textEnergy;
    public bool isEnergyUpdated;
    public int energyLevel;
    GameObject clock;

    // Start is called before the first frame update
    void Start()
    {
        textEnergy = GetComponent<TextMeshProUGUI>();
        energyLevel = 100;
        textEnergy.text = energyLevel.ToString() + "/100";
        clock = GameObject.FindGameObjectWithTag("Clock");
        isEnergyUpdated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.GetComponent<Clock>().minusHealth) {
            energyLevel -= 1;
            textEnergy.text = energyLevel.ToString() + "/100";
            clock.GetComponent<Clock>().minusHealth = false;
        }
        if (!isEnergyUpdated)
        {
            if (energyLevel > 100)
            {
                energyLevel = 100;
            }
            textEnergy.text = energyLevel.ToString() + "/100";
            isEnergyUpdated = true;
        }
    }
}
