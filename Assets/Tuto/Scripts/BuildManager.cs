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

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No moni");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

}
