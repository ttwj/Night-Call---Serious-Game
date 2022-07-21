using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textRotation : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.rotation = player.rotation;
    }
}
