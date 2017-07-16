using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class GruntController : MonoBehaviour
{
    LoseCondition loseCondition;

    public GameObject startingPosition;
    public GameObject targetDestination;
    public bool finishedCycle;
    public bool chasingPlayer;

    [Header("Juice")]
    public Animator gruntAnimController;
    public AnimationCurve movementJuice;
    public float smoothValue;
    public float switchValue = 3f;
    private Transform playerPosition;

    private void Awake()
    {
        loseCondition = GameObject.FindGameObjectWithTag("GameManagerTag").GetComponent<LoseCondition>();
    }

    private void FixedUpdate()
    {
        if (chasingPlayer == false)
        {
            if (finishedCycle == false)
            {
                transform.position = Vector3.Lerp(transform.position, targetDestination.transform.position, movementJuice.Evaluate(Time.deltaTime * smoothValue));

                Vector3 direction = startingPosition.transform.position - transform.position;
                Quaternion lookat = Quaternion.LookRotation(direction);
                transform.rotation = lookat;

                StartCoroutine("BackToOrigin");
            }
            if (finishedCycle == true)
            {
                transform.position = Vector3.Lerp(transform.position, startingPosition.transform.position, movementJuice.Evaluate(Time.deltaTime * smoothValue));

                Vector3 direction = targetDestination.transform.position - transform.position;
                Quaternion lookat = Quaternion.LookRotation(direction);
                transform.rotation = lookat;

                StartCoroutine("ToTarget");
            }
        }
        else
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            Vector3 direction = playerPosition.transform.position - transform.position;
            Quaternion lookat = Quaternion.LookRotation(-direction);
            transform.rotation = lookat;

            transform.position = Vector3.Lerp(transform.position, playerPosition.transform.position, Time.deltaTime / smoothValue);      
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            loseCondition.isFound = true;
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator ToTarget()
    {
        yield return new WaitForSeconds(switchValue);
        if (finishedCycle == true) { finishedCycle = false;}
    }

    IEnumerator BackToOrigin()
    {
        yield return new WaitForSeconds(switchValue);
        if (finishedCycle == false) { finishedCycle = true;}
    }
}
