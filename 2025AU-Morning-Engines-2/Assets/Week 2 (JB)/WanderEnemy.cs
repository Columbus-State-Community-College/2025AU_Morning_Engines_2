using UnityEngine;
using System.Collections;

public class WanderingEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int EnemyHP = 3;
    private float sineSpeed = 0.5f;
    private float sineAmp = 5f;
    private float lastSineValue = 0f;
    private bool goingUp = true;
    private Vector3 EnemyPos;
    public GameObject Enemy;
    public GameManager manager;

    void Start()
    {
        EnemyPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    float sineValue = Mathf.Sin(Time.time * sineSpeed);
    float zOffset = sineValue * sineAmp;
    transform.position = new Vector3(EnemyPos.x, EnemyPos.y, EnemyPos.z + zOffset);
    if (goingUp && sineValue < lastSineValue)
        {
         TurnAround();
         goingUp = false;
        }
    else if (!goingUp && sineValue > lastSineValue)
        {
         TurnAround();
         goingUp = true;
        }
     lastSineValue = sineValue;
    }

  void TurnAround()
   {
     transform.Rotate(0f, 180f, 0f);
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
