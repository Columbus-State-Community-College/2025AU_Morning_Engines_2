using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public LogicScript logic;
    private int EnemyHP = 3;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        logic.HP_Decrease();
        Enemy_Damage();
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
