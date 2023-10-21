using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public LevelManager levelManager;

    public Vector3 initialPosition;

    public Transform gate;

    public bool _gateTriggered = false;
    public float gateSpeed = .3f;
    public Transform endPosition;

    [Header("Lights")]
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    private bool _hasGateFinishedOpening = false;

    public float _gateOpenTime = 8f;
    private float gateOpenTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gate.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gateTriggered == true && _hasGateFinishedOpening == false)
        {
            gateOpenTimer += Time.deltaTime;
            // gate.transform.position = Vector3.MoveTowards(initialPosition, endPosition, step);
            gate.transform.position = Vector3.Lerp(initialPosition, endPosition.position, (gateOpenTimer / _gateOpenTime));

            if(gateOpenTimer >= _gateOpenTime)
            {
                _hasGateFinishedOpening = true;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (levelManager._gateTriggeredFirst == false)
            {
                levelManager._gateTriggeredFirst = true;
                EnableLights();
            }

            if(levelManager._powerTriggered == true)
            {
                _gateTriggered = true;
            }
        }
    }
    private void EnableLights()
    {
        light1.SetActive(true);
        light2.SetActive(true);
        light3.SetActive(true);
        light4.SetActive(true);
    }
}
