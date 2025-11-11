using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int coinTotal;
    private int CollectibleTotal = 10;
    public GameObject collectible1;
    public TextMeshProUGUI coinDisplay;
    public TextMeshProUGUI Gate1;
    public TextMeshProUGUI GameOver;
    public static GameManager instance;

    void Start()
    {
        SpawnFirstCollectible();
        Gate1.enabled = false;
        GameOver.enabled = false;
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SpawnFirstCollectible()
    {
        for (int i = 0; i < CollectibleTotal; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-25, 25), 2, Random.Range(-25, 25));
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(collectible1, spawnPosition, spawnRotation);
        }
    }

    public void PlayerDeath()
    {
        GameOver.enabled = true;
    }
    public void CoinTotalUpdate() 
    {
        coinTotal++;
        coinDisplay.text =  "Coins: " + coinTotal.ToString();

        if (coinTotal == 10)
            {
            Debug.Log("10 collectibles! Nice work");
            Gate1.enabled = true;
            }
        if (coinTotal == 20)
            {
            Debug.Log("20 collectibles! Nice work");
            }
        if (coinTotal == 30)
            {
            // special message? not sure
            }
    }
}

