using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntConeTrigger : MonoBehaviour
{
    GruntController gruntController;

    private void Awake()
    {
        gruntController = GameObject.FindGameObjectWithTag("GruntTag").GetComponent<GruntController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gruntController.chasingPlayer = true;
        print("yes");
    }
}
