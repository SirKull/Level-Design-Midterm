using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTrigger : MonoBehaviour
{
    public LevelManager levelManager;

    private bool hasActivatedPower = false;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            if(hasActivatedPower == false) 
            {
                levelManager.ActivateMainPower();
                hasActivatedPower = true;
            }
        }
    }
}
