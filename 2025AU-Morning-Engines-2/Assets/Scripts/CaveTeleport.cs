using UnityEngine;

public class CaveTeleport : MonoBehaviour
{
    public Transform BossCave;
    public Transform StartCave;
    private float cooldownTime = 10f;  // 10-second cooldown
    private float cooldownTimer = 0f;  // Timer to track cooldown

    // Flag to lock teleportation until cooldown is over
    private bool isTeleporting = false;

    void Start()
    {
        if (BossCave == null || StartCave == null)
        {
            Debug.LogError("StartCave or BossCave not assigned in the Inspector!");
        }
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            isTeleporting = false;
        }
    }

    private void Teleport(Transform destination)
    {
        if (destination != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 teleportPosition = destination.position + destination.forward * 30f;
                Debug.Log("Teleporting player to: " + teleportPosition);
                player.transform.position = teleportPosition;
                isTeleporting = true;
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
        else
        {
            Debug.LogError("Teleport destination is null!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cooldownTimer > 0 || isTeleporting)
            {
                Debug.Log("Teleport is on cooldown or already happening. Time left: " + Mathf.Ceil(cooldownTimer) + " seconds");
                return;
            }
            Debug.Log("Player entered " + gameObject.name);
            if (gameObject.CompareTag("BossCave"))
            {
                Debug.Log("Teleporting from BossCave to StartCave");
                Teleport(StartCave);
            }
            else if (gameObject.CompareTag("StartCave"))
            {
                Debug.Log("Teleporting from StartCave to BossCave");
                Teleport(BossCave);
            }
            cooldownTimer = cooldownTime;
        }
    }
}
