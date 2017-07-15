using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntConeTrigger : MonoBehaviour
{
    GruntController gruntController;
    InputManager3D inputManager3D;

    private void Awake()
    {
        gruntController = GameObject.FindGameObjectWithTag("GruntTag").GetComponent<GruntController>();
        inputManager3D = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager3D>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (inputManager3D.isHiding == false)
        {
            gruntController.chasingPlayer = true;
        }
    }
}
