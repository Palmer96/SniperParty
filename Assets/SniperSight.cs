using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSight : MonoBehaviour
{
    Camera cam;
    public GameObject scope;

    public GameObject marker;
    // Use this for initialization
    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = 40;
            scope.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    GameObject Mark = Instantiate(marker, hit.point, transform.rotation);
                    Mark.transform.SetParent(hit.transform);
                        Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("Body"))
                    {
                        hit.transform.GetComponent<BodyPart>().Hit();
                    }
                }
            }

        }
        else
        {
            cam.fieldOfView = 70;
            scope.SetActive(false);
        }


    }


}
