using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    float distance = 0;
    float break_time = 3f;
    bool friend = false;
    UnityEngine.AI.NavMeshAgent agent;
    Transform player_transform;
    private Animator animator;
    GameObject player_object;
    public ParticleSystem effect_shoot;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        player_object = GameObject.Find("Cube");
        player_transform = player_object.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            break_time = break_time - Time.deltaTime;
            distance = Vector3.Distance(player_transform.position, transform.position);
            if (distance <= 25f) {
                transform.LookAt(player_transform);
                agent.SetDestination(player_transform.position);
                agent.stoppingDistance = 7f;
                friend = true;
                flag = true;
            }
            else{
                friend = false;
            }

            RaycastHit hit;
            if(break_time <= 0f){
                if(Physics.Raycast(transform.position, transform.forward, out hit, 10f)){
                    if(hit.transform.name == "zombie"){
                        print("Стреляю в зомби");
                        effect_shoot.Play();
                        break_time = 3f;
                        zombie zombie_script = hit.transform.GetComponent<zombie>();
                        zombie_script.die = true;
                    }
                }
            }   
        if(friend == false){
            animator.SetBool("Bool", false);
        }
        else{
            animator.SetBool("Bool", true);
        }

    }
}
