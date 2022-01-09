using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    //destination marker reference
    public GameObject markerGoal;
    public GameObject marker;
    public GameObject padel;
    public float yM;
    //parent position
    Vector3 parentPos;
    //navmesh component reference
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        marker = GameObject.FindGameObjectWithTag("player").GetComponent<GameObject>();
        padel = GameObject.FindGameObjectWithTag("paddle").GetComponent<GameObject>();

    }

    void MoveToTarget()
    {
        if (markerGoal.active)
        {
            parentPos = markerGoal.transform.parent.position;
            agent.SetDestination(parentPos);
        }
    }

    void RotateWithTarget()
    {
        if (markerGoal.active)
        {
            yM = marker.transform.rotation.eulerAngles.y;
            padel.transform.eulerAngles = new Vector3(
                padel.transform.eulerAngles.x,
                padel.transform.eulerAngles.y + 30,
                padel.transform.eulerAngles.z
                );
        }
    }

    float MapRange(float s, float a1, float a2, float b1, float b2)
    {
        if (s >= a2) return b2;
        if (s <= a1) return b1;
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void PitchCtrl()
    {
        transform.GetChild(0).eulerAngles = new Vector3(
            MapRange(agent.velocity.magnitude, 0f, 2f, 0f, 20f),
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
    }
    // Update is called once per frame
    void Update()
    {
        //PitchCtrl();
        MoveToTarget();
        //RotateWithTarget();
    }
}
