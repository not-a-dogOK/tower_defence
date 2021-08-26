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
	public GameObject standardTurretPrefab;
	private GameObject doulGunprefab;

	void Start ()
	{
		doulGunprefab = standardTurretPrefab;
		turretToBuild = standardTurretPrefab;
	}

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild ()
	{
		return turretToBuild;
	}
	public void selectSniper()
    {
		standardTurretPrefab = sniperprefab;
		turretToBuild = standardTurretPrefab;
	}

	public void selectDual()
	{
		standardTurretPrefab = doulGunprefab;
		turretToBuild = standardTurretPrefab;
	}


}
