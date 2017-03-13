using UnityEngine;
using System.Collections;

public class MovingCube : MonoBehaviour {
    bool moveDirection;
    Vector3 velocity;
    public Vector3 TargetDelta;
    public float SmoothTime;
    Vector3 target, start;
    float timer;
	// Use this for initialization
	void Start () {
        target = transform.position + TargetDelta;
        start = transform.position;
        timer = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        if(Time.time-timer> SmoothTime*2)
        {
            timer = Time.time;
            moveDirection = !moveDirection;
            Vector3 temp = target;target = start;start = temp;
        }
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, SmoothTime, float.PositiveInfinity, Time.deltaTime);
	}
}
