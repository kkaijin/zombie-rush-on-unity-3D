using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shoot : MonoBehaviour
{
    public float damage = 100f;
    public float range = 100f;

    public ParticleSystem efffect_shoot;

    public Camera fpsCamera;

    public TextMeshProUGUI ammo_text;

    public TextMeshProUGUI mag_text;

    int bullet = 10; 
    public int magaz = 40;

    public bool diie = false;

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(bullet > 0){
            Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * 1000f, Color.red);
            if (Input.GetButtonDown("Fire1"))
            {
                
                if(transform.parent!= null)
                {
                    bullet--;
                    ammo_text.text = bullet.ToString();
                    Shoot();
                }
                else
                {
                    print("netryzh");
                }
               
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && transform.parent.name == "hand"){
                Reload(); 
                mag_text.text = magaz.ToString();
                ammo_text.text = bullet.ToString();
        }
        mag_text.text = magaz.ToString();
        ammo_text.text = bullet.ToString();
    }

    void Shoot()
    {
        efffect_shoot.Play();
        
         RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {


            zombie zombie = hit.transform.GetComponent<zombie>();
            // if (zombie != null)
            // {
            //     animator.SetBool("die", true);
            // }
            diie = true;
            
        }
    }

    void Reload()
    {
        int reason = 10 - bullet;
        if(magaz >= reason)
        {
            magaz = magaz - reason;
            bullet = 10;
            mag_text.text = magaz.ToString();
        }
        else
        {
            bullet = bullet - magaz;
            magaz = 0;
            mag_text.text = magaz.ToString();
        }
        
    }
}
