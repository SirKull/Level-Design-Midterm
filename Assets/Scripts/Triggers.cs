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
  

    [Header("Main Power")]
    public bool _mainPowerOn = false;
    public bool _powerTriggered = false;
    public Transform powerTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gate.transform.position;
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
            }
        }
       
    }

    private void MainPower()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gateTriggered = true;
        }
    }

    
}
