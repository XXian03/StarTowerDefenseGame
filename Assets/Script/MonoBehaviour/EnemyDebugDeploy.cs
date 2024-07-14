using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDebugDeploy : MonoBehaviour
{

    [SerializeField] UiHandler uiHandler; // Refrence this ui handler for easy access
    [SerializeField] DeploymentManager deploymentManager;
    


    void Start()
    {
        
    }

    void Update()
    {
        if (Game.Instance.GameState == GameStateEnum.EnemyDebugDeploy)
        {
            uiHandler.EnemyDebugDeployLayer.SetActive(true);

            deploymentManager.brush.SelectionState = 2;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                deploymentManager.DeployEnemy();
            }
        }
        else
        {
            uiHandler.EnemyDebugDeployLayer.SetActive(false);
        }


        

 
    

    }
}
