using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

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
	
	public int nextWave = 1;
	public int NextWave
	{
		get { return nextWave + 1; }
	}


	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;


	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}



	void Start()
	{	
		waveCountdown = timeBetweenWaves;
		InvokeRepeating("Chose",1f,10f);
	}

	void Update()
	{
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

		if (waveCountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown = waveCountdown - Time.deltaTime;
		}


	}

		void Chose()
	{
		


		//RNG
		int i = Random.Range(0, 100);
		if ( 75 <= i )
		{

			StartCoroutine(SpawnWave(waves[0]));
		}
		
	}

void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{

			//to do load next level here
			nextWave = 1;
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

	IEnumerator SpawnWave(Wave _wave)
	{
		

		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds( 1f/_wave.rate );
		}
		
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
		Debug.Log("Spawning Enemy: " + _enemy.name);

		//Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];

		Transform _sp = spawnPoint;
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
