using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    private GameObject[] PatrolPoints;
    public float Speed;
    int RandomPoint;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PatrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        RandomPoint = Random.Range(0, PatrolPoints.Length);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, PatrolPoints[RandomPoint].transform.position,Speed * Time.deltaTime );
        if (Vector2.Distance(animator.transform.position, PatrolPoints[RandomPoint].transform.position)< 0.1f)
        {
            RandomPoint = Random.Range(0, PatrolPoints.Length);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}
