using UnityEngine;

public class Node : MonoBehaviour {

	
	public Vector3 positionOffset;

	private GameObject turret;

	

	void Start ()
	{
		
    }

	void OnMouseDown ()
	{
		if (turret != null)
		{
			Debug.Log("Can't build there! - TODO: Display on screen.");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}



}
