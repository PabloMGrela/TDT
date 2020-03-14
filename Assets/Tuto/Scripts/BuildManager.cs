using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBluePrint turretToBuild;
    void Awake(){
        if(instance != null){
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    
    }
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject buildEffect;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No moni");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject effect = Instantiate(buildEffect, node.GetAnimationPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
