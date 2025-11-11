using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackscript : MonoBehaviour
{

    public GameObject player;
     private Vector3 offset;

    public float knockback = 15f;
    public EnemyBehavior EB;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        EB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehavior>();
  
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        EB.Enemy_Damage();
        
    }

}
