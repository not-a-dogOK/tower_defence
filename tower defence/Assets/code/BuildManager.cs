using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}
	public GameObject sniperprefab;
	public GameObject dualGunprefab;
	public GameObject MGprefab;
	public static GameObject SelectedTurret;
	public static int cost;
	public int sniperCost = 300;
	public int dualCost = 200;
	public int MGcost = 700;

	void Start ()
	{
		turretToBuild = null;
	}

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild ()
	{
		return turretToBuild;
	}
	public void selectSniper()
    {
		SelectedTurret = sniperprefab;
		turretToBuild = sniperprefab;
		cost = sniperCost;
	
	}

	public void selectDual()
	{
		SelectedTurret = dualGunprefab;
		turretToBuild = dualGunprefab;
			cost = dualCost;
		
	}

	public void selectMg()
	{
		SelectedTurret = MGprefab;
		turretToBuild = MGprefab;
		cost = MGcost;

	}


}
