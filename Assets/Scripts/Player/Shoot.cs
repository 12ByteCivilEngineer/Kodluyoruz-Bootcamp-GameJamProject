using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1f;

   

    private float timer;
    private float bartimer = 0.1f;


    [SerializeField]
    private Transform firePoint;

    [SerializeField]

    private GameObject bullet;
    public Slider shootSlider;




    void Update()
    {
        if (shootSlider.value < 10)
        {
            shootSlider.value = bartimer;

            if (bartimer < 10)
            {
                bartimer = bartimer + 0.1f;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("Ateş ETTİM");
                    shootSlider.value = 0f;
                    bartimer = 0.1f;
                    timer = 0f;
                    FireGun();
                }
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
