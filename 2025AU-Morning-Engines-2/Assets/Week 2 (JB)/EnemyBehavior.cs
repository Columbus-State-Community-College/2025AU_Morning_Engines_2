using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
 public Transform player;
 public GameObject Enemy;
 private int EnemyHP = 3;
 public GameManager manager;
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
            manager.HP_Decrease();
            Enemy_Damage();
       }
   }
  public void Enemy_Damage()
   {
        EnemyHP -= 1;
        Delete_Enemy();
   }
    
  private void Delete_Enemy()
   {
        if (EnemyHP == 0)
        {
            Destroy(Enemy);
        }
   }
}