using UnityEngine;

public class enemy_truck : MonoBehaviour
{

	public float speed = 10f;
	public Transform Enemy_Transform;
	//public GameObject enemy;

	private Transform target;
	private int wavepointIndex = 0;
	


	void Start()
	{
		transform.position = transform.position + Vector3.right * spawningRandom();
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}
	float spawningRandom()
	{
		float r = Random.Range(-1.0f, 1.0f);
		return r;
	}
	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	
	void OnDestroy()
	{
		int num = 0;
		while (num < 10)
			{
			WaveSpawner.SpawnEnemytruck(Enemy_Transform
				,
				transform);

			print("Script was destroyed");
			num++;	
		}
			//Enemy.SetwavepointIndex(wavepointIndex);


	}

	
}
