using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1f;

   

    private float timer;


    [SerializeField]
    private Transform firePoint;

    [SerializeField]

    private GameObject bullet;
    

   

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                
            
                FireGun();

            }
        }
    }

    private void FireGun()
    {
        /*Debug.DrawRay(firePoint.position, firePoint.forward * 10, Color.white, .2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 50))
        {

            var health = hitInfo.collider.GetComponent<EnemyHealth>();

            if(health != null)
            {
                health.TakeDamage(damage);
            }
            
        }*/

        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }
}
