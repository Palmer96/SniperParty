using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{

    public float hitValue;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        transform.GetComponentInParent<NPC>().health -= hitValue;
        transform.GetComponentInParent<NPC>().HealthCheck(gameObject);
    }
}
