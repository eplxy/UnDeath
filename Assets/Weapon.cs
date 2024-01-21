using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Cooldown cooldown;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private Camera mainCam;
    private Vector3 mousePos;

    void Start(){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - firePoint.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        firePoint.transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(cooldown.IsCoolingDown) return;
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
            
        }

       void Shoot ()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            cooldown.StartCooldown();
        }


    }
}