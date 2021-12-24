using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }



    public Wave[] waves;

    public int nextWave = 2;
    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public int nextWaveDesplay = 1;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    public float WaveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    public GameObject backTomenu;
    public AudioSource DoneSound;
    public AudioSource chaosSound;
    public Text WaveText;


    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get { return state; }
    }


    // set the function chose to run every 10 sec
    void Start()
    {
        waveCountdown = timeBetweenWaves;
        InvokeRepeating("Chose", 1f, 10f);
        backTomenu.SetActive(false);
        nextWaveDesplay = 1;
    }

    void Update()
    {

        WaveText.text = "wave: " + nextWaveDesplay + "/12";

        //checks if enemy is alive if not runs wave complte 
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        // when the countdown ends spawn next wave

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown = waveCountdown - Time.deltaTime;
        }


    }

    // makes the chose wave spwan randomly
    void Chose()
    {
        if (nextWave >= 5)
        {
            //RNG
            int i = Random.Range(0, 100);
            if (75 <= i)
            {
                chaosSound.Play();
                StartCoroutine(SpawnWave(waves[0]));
            }

        }
    }

    void vromVrom()
    {
        StartCoroutine(SpawnWave(waves[1]));
    }



    //add 1 to next wave 
    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        nextWaveDesplay++;

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {

            backTomenu.SetActive(true);
            DoneSound.Play();
            nextWave = 2;
            Debug.Log("ALL WAVES COMPLETE! Looping...");

        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    // spwan wave using the wave list 
    IEnumerator SpawnWave(Wave _wave)
    {


        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        //some dead code
        /*
		if(_wave.name = chose)
        {

        }
		*/


        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy: " + _enemy.name);

        //Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
        Transform _sp = spawnPoint;
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    public static void SpawnEnemytruck(Transform _enemy, Transform truck)
    {
        //Debug.Log("Spawning Enemy from truck: " + _enemy.name);

        //Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
        Transform _sp = truck;
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    // dead code :(

    /*
	 * void spawningRandom(float num)
    {
		float r = Random.Range(0.0f, 1.0f);
		num = num + r;

	}
	*/

}
