// Created by Binh Bui on 07, 14, 2021

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public static Spawner Instance { get; private set; }
    private void Start()
    {
        Instance ??= this;

        InvokeRepeating(nameof(SpawnObject), 1f, 1f);
    }

    private void SpawnObject()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f), Quaternion.identity);
    }
}