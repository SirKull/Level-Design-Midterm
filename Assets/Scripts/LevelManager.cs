using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Gate Trigger")]
    public bool _gateTriggeredFirst = false;


    [Header("Main Power")]
    public bool _powerTriggered = false;

    [Header("Doors")]
    public GameObject door1;
    public GameObject door2;

    [Header("Lake Zombies")]
    public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ActivateMainPower()
    {
        _powerTriggered = true;
        DestroyDoors();
        Zombie1.SetActive(true);
        Zombie2.SetActive(true);
        Zombie3.SetActive(true);
    }



    private void DestroyDoors()
    { 
        Destroy(door1);
        Destroy(door2);
    }

}