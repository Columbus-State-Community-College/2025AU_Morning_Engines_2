using UnityEngine;



public class CollectibleScript : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        float YBob = startPos.y + Mathf.Sin(Time.time * 2) * 0.5f;
        transform.position = new Vector3(transform.position.x, YBob, transform.position.z);
        transform.Rotate(new Vector3(0,45,0) * Time.deltaTime);
    }


    void OnTriggerEnter (Collider other) 
   {
       if (other.gameObject.CompareTag("Player")) 
       {
           GameManager.instance.CoinTotalUpdate();
           gameObject.SetActive(false);
       }
   }
}
