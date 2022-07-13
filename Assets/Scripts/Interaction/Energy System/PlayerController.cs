using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject energy;
    GameObject prompt;
    public int initialSpeed;
    public int speed;
    Vector3 Vec;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.FindGameObjectWithTag("EnergyLevel");
        prompt = GameObject.FindGameObjectWithTag("Prompt");
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
            prompt.GetComponent<Prompt>().promptText = "Press E to eat food";
            prompt.GetComponent<Prompt>().isPromptUpdated = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.tag == "Food")
        {
            prompt.GetComponent<Prompt>().promptText = "Food eaten! Gain 10 Energy!";
            prompt.GetComponent<Prompt>().isPromptUpdated = false;
            energy.GetComponent<Energy>().energyLevel += 10;
            energy.GetComponent<Energy>().isEnergyUpdated = false;
            Destroy(other.gameObject);
        }
    }
}
