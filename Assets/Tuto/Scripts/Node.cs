using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    private Color startColor;
    public Color noMoneyColor;
    private Renderer rend;
    BuildManager buildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown(){
        if (!buildManager.CanBuild)
            return;
        if(turret != null){
            Debug.Log("Hay torre'TODO");
            return;
        }
        buildManager.BuildOn(this);

    }
    void OnMouseEnter(){
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild){
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = noMoneyColor;
        }
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
