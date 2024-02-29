using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnRate = 2f;
    public float spawnRadius = 5f;

    private float nextSpawnTime;

    void Update()
    {
        // Проверяем, настал ли момент для генерации нового объекта
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + 1f / spawnRate; // Обновляем время следующей генерации
        }
    }

    void SpawnObject()
    {
        // Выбираем случайный объект из списка для генерации
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
        // Генерируем случайную позицию в радиусе спауна
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        // Задаем позицию по оси Z равной 0, чтобы объекты спавнились на одной плоскости
        spawnPosition.z = 0f;
        // Создаем объект
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
