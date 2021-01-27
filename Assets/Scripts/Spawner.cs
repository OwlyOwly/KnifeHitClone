using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnedKnifePrefab;
    [SerializeField] private GameObject bonusFruit;
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private BonusData bonusData;

    private int spawnChance;

    private void Awake()
    {
        spawnChance = bonusData.Chance;
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child);
        }
    }

    private void Start()
    {
        int knivesAmount = Random.Range(1, 4);

        for (int i = 0; i < knivesAmount; i++)
        {
            int positionNumber = Random.Range(0, spawnPositions.Count);
            Instantiate(spawnedKnifePrefab, spawnPositions[positionNumber].position, spawnPositions[positionNumber].rotation, transform);
            spawnPositions.RemoveAt(positionNumber);
        }

        int fruitSpawnRandom = Random.Range(0, 101);
        if (fruitSpawnRandom < spawnChance)
        {
            Instantiate(bonusFruit, spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity, transform);
            Debug.Log("Bonus spawned!");
        }
    }
}
