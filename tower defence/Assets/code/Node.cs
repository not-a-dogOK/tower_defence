using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Node : MonoBehaviour
{


    public Vector3 positionOffset;

    private GameObject turret;
    public GameObject NoBuild;
    public GameObject NoMoney;
    //public Text NoBuildText;

    void Start()
    {
        NoBuild.SetActive(false);
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            NoBuild.SetActive(true);
            bool Active = true;
            if (Active)
            {
                Invoke("HideNoBuild", 2f);
            }




            //Debug.Log("Can't build there! - TODO: Display on screen.");
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
            NoMoney.SetActive(true);
            bool Active1 = true;
            if (Active1)
            {
                Invoke("HideNoMoney", 2f);
            }
            //Debug.Log("u poor");
        }





    }
    void HideNoBuild()
    {
        NoBuild.SetActive(false);
    }
    void HideNoMoney()
    {
        NoMoney.SetActive(false);
    }



}
