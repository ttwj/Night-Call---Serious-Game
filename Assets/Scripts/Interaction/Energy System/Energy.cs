using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{
    private TextMeshProUGUI textEnergy;
    public int energyLevel;
    GameObject clock;

    // Start is called before the first frame update
    void Start()
    {
        textEnergy = GetComponent<TextMeshProUGUI>();
        energyLevel = 100;
        textEnergy.text = energyLevel.ToString();
        clock = GameObject.FindGameObjectWithTag("Clock");
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.GetComponent<Clock>().minusHealth) {
            energyLevel -= 1;
            textEnergy.text = energyLevel.ToString();
            clock.GetComponent<Clock>().minusHealth = false;
        }
    }
}
