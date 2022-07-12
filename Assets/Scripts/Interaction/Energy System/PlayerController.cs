using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject energy;
    public int speed;
    Vector3 Vec;


    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.FindGameObjectWithTag("EnergyLevel");
    }

    // Update is called once per frame
    void Update()
    {
        Vec = transform.localPosition;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.localPosition = Vec;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            energy.GetComponent<Energy>().energyLevel += 10;
            energy.GetComponent<Energy>().isEnergyUpdated = false;
        }
    }
}
