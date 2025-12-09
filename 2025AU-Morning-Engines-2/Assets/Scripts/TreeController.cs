using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeController : MonoBehaviour
{
    public List<GameObject> ornaments = new List<GameObject>();
    public int totalCollectibles = 20;
    private int collectedCount = 0;

    void Start()
    {
        foreach (var ornament in ornaments)
        {
            ornament.SetActive(false);
        }
    }

    public void Collect()
    {
        collectedCount++;
        if (collectedCount <= ornaments.Count)
        {
            ornaments[collectedCount - 1].SetActive(true);
        }
    }
}
