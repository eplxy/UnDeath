using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    int holdCounter = 0;
    [SerializeField] private Cooldown cooldown;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject chargedSwingPrefab;
    public GameObject swingPrefab;

    public Player player;

    private Camera mainCam;
    private Vector3 mousePos;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }


    void ChargeSwing(){
        if (holdCounter < 222){
            holdCounter++;
        } else {
            Instantiate(chargedSwingPrefab, player.transform.position, firePoint.rotation);
            holdCounter = 0;
        }
    }

    void updateCooldown(){
        if (player.phase == "Scythe"){
            cooldown.cooldownTime = 1f;
        } else {
            cooldown.cooldownTime = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - firePoint.transform.position;
        player.flip(rotation);
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        firePoint.transform.rotation = Quaternion.Euler(0, 0, rotZ);

        updateCooldown();
        if (cooldown.IsCoolingDown) return;
        if (!player.alive) return;
        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();

        }
        if (Input.GetKey(KeyCode.Mouse0) && player.phase == "Scythe"){
            ChargeSwing();
        }

        void Shoot()
        {
            if (player.phase == "Gun")
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            }
            else
            {
                Instantiate(swingPrefab, firePoint.position, firePoint.rotation);

            }
            cooldown.StartCooldown();
        }


    }
}