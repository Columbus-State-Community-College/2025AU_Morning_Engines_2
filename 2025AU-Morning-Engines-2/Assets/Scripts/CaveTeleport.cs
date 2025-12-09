using UnityEngine;

public class CaveTeleport : MonoBehaviour
{
    public Transform BossCave;
    public Transform StartCave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Teleport(Transform destination)
    {
        // Move the player to the target cave location
        if (destination != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = destination.position;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject == BossCave)
            {
                Teleport(StartCave);
            }
            if (gameObject == StartCave)
            {
                Teleport(BossCave);
            }
        }
    }
}
