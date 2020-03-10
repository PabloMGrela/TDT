﻿
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileTurret()
    {
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
