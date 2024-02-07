using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class zombieBoss : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    GameObject cube_object;

    Transform cube_transform;

    bool zombieSpeed = false;

    float distance = 0;

    private Animator animator;

    public bool die = false;
    public int hp = 50;
    // Start is called before the first frame update
    void Start()
    {
        cube_object = GameObject.Find("Cube");
        cube_transform = cube_object.GetComponent<Transform>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(cube_transform.position, transform.position);
        if (distance <= 25f ) {
            agent.SetDestination(cube_transform.position);
            
            zombieSpeed = true;
        }
        else{
            zombieSpeed = false;
        }

        if(zombieSpeed == false){
            //idle
            animator.SetBool("zombie", false);
        }
        else if(zombieSpeed == true)
        {
            //run
            animator.SetBool("zombie", true);
            
        }
        if(die == true)
        {
            animator.SetBool("die", true);
            gameObject.GetComponent<Collider>().enabled = false;
            agent.isStopped = true;
            agent.ResetPath();
        }
    }
}
