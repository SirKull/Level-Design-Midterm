using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public Vector3 initialPosition;

    [Header("Gate Trigger")]
    public Transform gate;
    public Transform gateTrigger;
    public float gateSpeed = .3f;
    public Vector3 endPosition = new Vector3(0f, 3f, 0f);
    public bool _gateTriggered = false;
    public bool _gateTriggeredFirst = false;


    [Header("Main Power")]
    public Transform mainPower;
    public bool _mainPowerOn = false;
    public bool _powerTriggered = false;
    public Transform powerTrigger;

    [Header("Lights")]
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    [Header("Doors")]
    public GameObject door1;
    public GameObject door2;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gate.transform.position;
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        light4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mainPowerOn == true)
        {
            if (_gateTriggered == true)
            {
                var step = gateSpeed * Time.deltaTime;
                gate.transform.position = Vector3.MoveTowards(initialPosition, endPosition, step);
                DestroyDoors();
            }
        }
        if (_gateTriggeredFirst == true)
        {
            EnableLights();
        }
       
    }

    private void MainPower()
    {
        
    }

    private void GateTrigger(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gateTriggeredFirst = true;
            _gateTriggered = true;
        }
    }

    private void DestroyDoors()
    {
        if (_mainPowerOn == true)
        {
            Destroy(door1);
            Destroy(door2);
        }
    }

    private void EnableLights()
    {
        if(_gateTriggeredFirst == true)
        {
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            light4.SetActive(false);
        }
    }
}
