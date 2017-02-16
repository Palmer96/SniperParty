using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float health;
    UnityEngine.AI.NavMeshAgent nav;
    bool alive;
    Vector3[] pos;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        pos = new Vector3[4];
        pos[0] = new Vector3(-8, 0, -8);
        pos[1] = new Vector3(8, 0, -8);
        pos[2] = new Vector3(-8, 0, 8);
        pos[3] = new Vector3(8, 0, 8);

        GetTarget();
        alive = true;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, nav.destination) < 2)
        {
            GetTarget();
        }

    }
    void GetTarget()
    {
        nav.destination = pos[Random.Range(0, 3)];
    }

    public void HealthCheck(GameObject hitPos)
    {
        if (alive)
        {
            if (health <= 0)
            {
                alive = false;
               // GetComponent<CapsuleCollider>().enabled = true;
                nav.enabled = false;

                Debug.Log("Hit: " + hitPos.transform.parent.name);
                Debug.Log("Child: " + transform.name);

                if (hitPos == transform.GetChild(0).gameObject)
                {
                    Debug.Log("HeadShot");
                    transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    Debug.Log((transform.GetChild(0).position - transform.position));
                    transform.GetChild(0).GetComponent<Rigidbody>().AddForce((transform.GetChild(0).position - transform.position));
                    transform.GetChild(0).transform.parent = null;
                }
                else
                    transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;

                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce((hitPos.transform.position - transform.position) * 10);

            }

        }
    }
}
