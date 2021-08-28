using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public int killmoney = 20;
	private static int health;
	public int Starthealth = 2;

	private Transform target;
	private int wavepointIndex = 0;

	public GameObject impactEffect;

	

	/*
	public static void SetwavepointIndex(int wavepointIndexIN)
    {
		wavepointIndex = wavepointIndexIN;

	}
	*/


	void Start ()
	{
		health = Starthealth;

		transform.position = transform.position + Vector3.right * spawningRandom();
		target = Waypoints.points[0];


		
	}

	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

	}
	/*
	public static void BeenHit()
	{
		health--;
		
	}
	*/
    float spawningRandom()
	{
		float r = Random.Range(-1.0f, 1.0f);
		return r;
	}
	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			PlayerStats.Lives--;
			
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	

	void OnDestroy()
    {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 2f);
		

		PlayerStats.Money = PlayerStats.Money + killmoney;

	}



}
