using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupammo : MonoBehaviour
{
    public GameObject camera;
    public float distance = 5f;
    GameObject currentWeapon;
    bool canPickUp;
    public GameObject text;
    
    public Shoot shoot;

    
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {

        text.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E)) PickUp();

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            
            if (hit.transform.tag == "Ammo")
            {
                text.SetActive(true);
            }
        }
    }

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            
            if (hit.transform.tag == "Ammo")
            {
                shoot.magaz += 20;
                shoot.mag_text.text = shoot.magaz.ToString();
                hit.transform.gameObject.SetActive(false);
            }
        }


    }
}
