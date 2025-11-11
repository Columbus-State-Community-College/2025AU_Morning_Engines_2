using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
 public Transform player;
 private NavMeshAgent navMeshAgent;

 void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdatePath());
    }

 IEnumerator UpdatePath()
    {
    while (true)
    {
        if (player != null)
            {    
            navMeshAgent.SetDestination(player.position);
            }
        yield return new WaitForSeconds(0.25f);
        }   
    }
  void OnTriggerEnter (Collider other) 
   {
       if (other.gameObject.CompareTag("Player")) 
       {
           other.gameObject.SetActive(false);
           GameManager.instance.PlayerDeath();
       }
   }
}