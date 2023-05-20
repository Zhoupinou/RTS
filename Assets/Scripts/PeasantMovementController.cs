using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantMovementController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
            agent.destination = target;
        
        
    }
}
