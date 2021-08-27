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


		if (turretToBuild == BuildManager.SelectedTurret && PlayerStats.Money >= BuildManager.cost)
        {
			turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
			PlayerStats.Money = PlayerStats.Money - BuildManager.cost;
		}
        else
        {
			Debug.Log("u poor");
        }
       
			
			
			
			
	}



}
