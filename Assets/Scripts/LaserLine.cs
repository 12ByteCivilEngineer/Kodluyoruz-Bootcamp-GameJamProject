using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLine : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform firePoint;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = true;
        lr.useWorldSpace = false;
    }
    
    void Update()
    {
        lr.SetPosition(0,Vector3.zero);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0f,0f,hit.distance) /5f);
            }
        }
        else lr.SetPosition(1, Vector3.forward *1000f);
    }
}
