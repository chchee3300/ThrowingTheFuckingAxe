using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject Axe;
    public Transform Startpoint;
    public bool Started;
    public float AxeThrowingPower = 500f;
    public bool TimerStarted;
    public double Timer = 1.5;
    public double DestroyTimer = 5;
    public bool DestoryAxe;
    public GameObject AxeSpawn;
    
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer > 0)
        {
            TimerStarted = true;
        }
        else
        {
            TimerStarted = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !TimerStarted)
        {
            Started = true;
            Timer = 1.5;
        }
    }

    public void FixedUpdate()
    {
        DestroyTimer -= Time.deltaTime;
        if (Started)
        {
            throwing();
        }
    }
    private void throwing()
    {
        AxeSpawn = Instantiate(Axe, Startpoint.position, Axe.transform.rotation);
        Rigidbody AxeRb = AxeSpawn.GetComponent<Rigidbody>();
        AxeRb.AddForce (transform.forward * AxeThrowingPower);
        Started = false;
    }
}
