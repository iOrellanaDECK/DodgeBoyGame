using UnityEngine;
using System.Collections;

public class DebrisSpawner : MonoBehaviour
{
    public GameObject[] debrisVariants;
    public float spawnInterval = 1.5f;
    public float spawnRangeX = 8f;
    public float spawnHeight = 6f;

    public GameObject fireEffectPrefab;
    public GameObject smokeEffectPrefab;
    [Range(0f, 1f)] public float fireChance = 0.3f;
    [Range(0f, 1f)] public float smokeChance = 0.3f;

    public float effectScale = 2.9f;
    public Vector3 effectOffset = new Vector3(0f, 0.5f, 0f);

    
    public float intervalReduction = 0.2f;
    public float minInterval = 0.5f;
    public float difficultyIncreaseTime = 30f;

    private Coroutine spawnRoutine;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
        StartCoroutine(IncreaseDifficulty());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnDebris();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficultyIncreaseTime);

            if (spawnInterval > minInterval)
            {
                spawnInterval -= intervalReduction;
                Debug.Log("Aumentando dificultad, nuevo intervalo: " + spawnInterval.ToString("F2"));
            }
        }
    }

    void SpawnDebris()
    {
        if (debrisVariants.Length == 0) return;

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPos = new Vector2(randomX, spawnHeight);

        GameObject selectedPrefab = debrisVariants[Random.Range(0, debrisVariants.Length)];
        GameObject debris = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        // efecto visual aleatorio
        float roll = Random.value;

        if (roll < fireChance && fireEffectPrefab != null)
        {
            GameObject fire = Instantiate(fireEffectPrefab, debris.transform.position + effectOffset, Quaternion.identity);
            fire.transform.localScale = Vector3.one * effectScale;
            fire.transform.SetParent(debris.transform);
        }
        else if (roll < fireChance + smokeChance && smokeEffectPrefab != null)
        {
            GameObject smoke = Instantiate(smokeEffectPrefab, debris.transform.position + effectOffset, Quaternion.identity);
            smoke.transform.localScale = Vector3.one * effectScale;
            smoke.transform.SetParent(debris.transform);
        }
    }
}
