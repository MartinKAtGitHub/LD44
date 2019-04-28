using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int HPPerWave;
    public int WaveCount;
    public GameObject Player;
    public bool AreAllEnemiesDead;

    [SerializeField]
    private GameObject electroBallPrefab;
    [SerializeField]
    private GameObject turretPrefab;

    [SerializeField]
    List<GameObject> spawnedEnemeies = new List<GameObject>();
    [SerializeField]
    List<Transform> spawnPoints; // this can be an array

    private int electroBallsCount;

    private int electroBallSpawnPerWave = 3;
    private int turretPerWave = 1;
    private bool isSpawning;
    private PlayerHealth playerHealth;


    private void Awake()
    {
        playerHealth = Player.GetComponent<PlayerHealth>();
        playerHealth.activeEnemeis = spawnedEnemeies;
       // WaveCount = 0;
    }

    private void Update()
    {
        if (spawnedEnemeies.Count == 0 && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        WaveCount++;
        //Debug.Log("SPAWNING WAVE = " + WaveCount);
        // Pause for like 1 sec to show wave count
        

        if (WaveCount <= 8)
        {
            yield return StartCoroutine(BeginnerWaves()); // wait for htis to end
        }
        else
        {
            yield return StartCoroutine(HardWaves());
        }

        //spawnedEnemeies more shitt
        isSpawning = false;
        yield return null;
    }


    private IEnumerator BeginnerWaves()
    {
        //PlayerExtraLife();
        yield return new WaitForSeconds(2);

        if (WaveCount == 1)
        {
            //Debug.Log("WAVE 1");
            // Do some intro shit pause 5 sec or wait fo rReady press
            spawnElectroballs();
            spawnTurrets();
        }
        else
        {

            // Pasuse for like 3 sec Spawn HP BUFF
            // Wave count UI
            PlayerExtraLife();

            spawnElectroballs();
            spawnTurrets();
        }
        yield return null;
    }


    private IEnumerator HardWaves()
    {
        yield return new WaitForSeconds(2);
        PlayerExtraLife();

        spawnElectroballs();
        spawnTurretsHard();

        yield return null;
    }




    private void spawnElectroballs()
    {
        for (int i = 0; i < electroBallSpawnPerWave * WaveCount; i++)
        {
            var ran = Random.Range(0, spawnPoints.Count - 1);
            var randomSpawnLocation = new Vector3(spawnPoints[ran].position.x, spawnPoints[ran].position.y, 0); // I have to make this cuz Z is not setting itself correctly is ido this inline LUL

            var clone = Instantiate(electroBallPrefab, randomSpawnLocation, Quaternion.identity);
            clone.GetComponent<AIBehaviourSeek>().target = Player.transform;
            spawnedEnemeies.Add(clone);
            clone.GetComponent<EnemyHealth>().activeEnemies = spawnedEnemeies;
            // play some spawn anim maybe?

        }
    }

    private void spawnTurrets()
    {

        for (int i = 0; i < turretPerWave * WaveCount - 1; i++)
        {
            var ran = Random.Range(0, spawnPoints.Count - 1);
            //var randomSpawnLocation = new Vector3(spawnPoints[ran].position.x, spawnPoints[ran].position.y, 0);
            var pos = new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, 0);
            var clone = Instantiate(turretPrefab, pos, Quaternion.identity);
            clone.GetComponent<Turret>().primaryTarget = Player;
            spawnedEnemeies.Add(clone);
            clone.GetComponent<EnemyHealth>().activeEnemies = spawnedEnemeies;

            // play some spawn anim maybe?

        }
    }


    private void spawnTurretsHard()
    {

        for (int i = 0; i < turretPerWave * WaveCount - 1; i++)
        {
            var ran = Random.Range(0, spawnPoints.Count - 1);
            var randomSpawnLocation = new Vector3(spawnPoints[ran].position.x + Random.Range(-1, 1), spawnPoints[ran].position.y + Random.Range(-1, 1), 0);

            var clone = Instantiate(turretPrefab, randomSpawnLocation, Quaternion.identity);
            clone.GetComponent<Turret>().primaryTarget = Player;
            spawnedEnemeies.Add(clone);
            clone.GetComponent<EnemyHealth>().activeEnemies = spawnedEnemeies;
        }
    }

    private void PlayerExtraLife()
    {
        playerHealth.MaxHealth += HPPerWave;
        playerHealth.ResetHP();
        //play Anim for extra life
    }
}
