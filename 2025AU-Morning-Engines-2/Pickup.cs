using UnityEngine;

public class Pickup : MonoBehaviour
{

    public PlayerController p_con;
    public GameObject pickup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p_con = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p_con.Can_Attack();
            Destroy(pickup);
        }
    }
}
