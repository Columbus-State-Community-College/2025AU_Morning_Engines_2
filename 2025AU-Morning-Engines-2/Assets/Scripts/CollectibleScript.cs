using UnityEngine;



public class CollectibleScript : MonoBehaviour
{
    private Vector3 startPos;
    private TreeController treeController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeController = FindFirstObjectByType<TreeController>();
        if (treeController == null)
        {
            Debug.LogError("TreeController not found in the scene. Please ensure there is a TreeController in the scene.");
        }
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
       if (treeController != null)
       {
           treeController.Collect();
       }
       if (other.gameObject.CompareTag("Player")) 
       {
           LogicScript.instance.CoinTotalUpdate();
           gameObject.SetActive(false);
       }
   }
}
