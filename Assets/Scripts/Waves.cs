using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    private float countdown = 3f;

    public float breakTime = 7f;

    private int waveCount = 1;

    public TMP_Text waveText;

    

    

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = breakTime;
        }

        countdown -= Time.deltaTime;
        waveText.text = Mathf.Floor(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveCount; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.1f);

        }
        waveCount++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
