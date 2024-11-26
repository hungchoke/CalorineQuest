using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public GameObject[] foodSpecial;
    public GameObject Target;
    public float spawnInterval = 2.0f;
    public float spawnSpecial = 5.0f;
    private float nextSpawnTime;
    private float nextSpawnSpecialTime;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Time.time + spawnInterval;
        nextSpawnSpecialTime = Time.time + spawnSpecial;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnFoodNormal();
            nextSpawnTime = Time.time + spawnInterval;
        }
        if (Time.time >= nextSpawnSpecialTime)
        {
            Debug.Log("Shoot!");
            SpawnFoodSpecial(Target.transform.position);
            nextSpawnSpecialTime = Time.time + spawnSpecial;
        }
    }

    private void SpawnFoodNormal()
    {
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        int randomIndex = Random.Range(0, foodPrefabs.Length);
        GameObject food = foodPrefabs[randomIndex];
        Vector3 spawnPosition;
        Quaternion fixedRotation;
        switch (Random.Range(0, 4))
        {
            case 0:
                spawnPosition = new Vector3(Random.Range(-width, width),height + 1.0f,transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 180);
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(-width, width),-height - 1.0f,transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                spawnPosition = new Vector3(-width - 1.0f,Random.Range(-height, height),transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 270);
                break;
            case 3:
                spawnPosition = new Vector3(width + 1.0f,Random.Range(-height, height),transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                spawnPosition = Vector3.zero;
                fixedRotation = Quaternion.identity;
                break;
        }

        Instantiate(food, spawnPosition, fixedRotation);
    }
    private void SpawnFoodSpecial(Vector3 targetPosition)
    {
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        int randomIndex = Random.Range(0, foodPrefabs.Length);
        GameObject food = foodPrefabs[randomIndex];
        Vector3 spawnPosition;
        Quaternion fixedRotation;
        switch (Random.Range(0, 4))
        {
            case 0:
                spawnPosition = new Vector3(targetPosition.x, height + 1.0f, transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 180);
                break;
            case 1:
                spawnPosition = new Vector3(targetPosition.x, -height - 1.0f, transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                spawnPosition = new Vector3(-width - 1.0f, targetPosition.y, transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 270);
                break;
            case 3:
                spawnPosition = new Vector3(width + 1.0f, targetPosition.y, transform.position.z);
                fixedRotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                spawnPosition = Vector3.zero;
                fixedRotation = Quaternion.identity;
                break;
        }
        /*spawnPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);*/
        Instantiate(food, spawnPosition, fixedRotation);
    }    
}
