using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;
    void Awake(){
        if(instance != null){
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    
    }
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    void Start(){
        
    }
    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
