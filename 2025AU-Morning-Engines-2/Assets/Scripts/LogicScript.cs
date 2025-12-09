using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int coinTotal;
    private int CollectibleTotal = 10;
    private int playerHealth = 3;
    public TextMeshProUGUI PlayerHP;
    public GameObject collectible1;
    public TextMeshProUGUI coinDisplay;
    public TextMeshProUGUI GameOverText;
    public GameObject GameOverScreen;
    public GameObject[] collectibleModels;
    public Material[] collectibleMaterials; 
    public static LogicScript instance;

    void Start()
    {
        SpawnFirstCollectible();
        GameOverText.enabled = false;
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
        Vector3 pos = new Vector3(Random.Range(-25, 25), 2, Random.Range(-25, 25));
        GameObject collectible = Instantiate(collectible1, pos, Quaternion.identity);
        Transform holder = collectible.transform.Find("ModelHolder");
        if (holder == null)
            {
            Debug.LogError("ModelHolder not found in collectible prefab!");
            return;
            }
        GameObject chosenModel = collectibleModels[Random.Range(0, collectibleModels.Length)];
        GameObject modelInstance = Instantiate(chosenModel, holder);
        modelInstance.transform.localPosition = Vector3.zero;
        modelInstance.transform.localRotation = Quaternion.identity;
        Material chosenMat = collectibleMaterials[Random.Range(0, collectibleMaterials.Length)];
        foreach (Renderer r in modelInstance.GetComponentsInChildren<Renderer>())
            {
            r.material = chosenMat;
            }
    }
    }


    public void CoinTotalUpdate() 
    {
        coinTotal++;
        coinDisplay.text =  "Coins: " + coinTotal.ToString();

        if (coinTotal == 10)
            {
            Debug.Log("10 collectibles! Nice work");
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
    public void HP_Decrease()
    {
        playerHealth -= 1;
        PlayerHP.text = "HP: " + playerHealth.ToString();
        HP_Zero();
    }

    public void HP_Zero()
    {
        if (playerHealth == 0)
        {
            Debug.Log("No more Health");
            GameOver();

        }
    }

    public void ResartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverText.enabled = true;
    }
}

