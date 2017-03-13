using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class Move2D : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler {
    public DebugPoint DebugPointPrefab;
    public bool IsDebugMode;
    List<DebugPoint> debugPoints = new List<DebugPoint>();
    float dragingMultiplier = 0.1f;
    float dragingClamp = 5f;
    float velocityClamp = 10f;
    float linerDrag = 0.2f;
    float wallPushMultiplier = 0.02f;
    Vector2 dragRelativePosition;
    Vector2 velocity;
    Vector2 mouseDragingPosition;
    bool draging;
    Canvas canvas;
    float radius;
    int subdividedRays = 32;
    // Use this for initialization
    void Start () {
        canvas = GetComponentInParent<Canvas>();
        radius = GetComponent<RectTransform>().rect.width / 2;
        velocity = Vector2.zero;
        draging = false;

    }
    // Update is called once per frame
    void Update ()
    {
    }
    private void FixedUpdate()
    {

        if (draging)
        {
            velocity += Vector2.ClampMagnitude(dragingMultiplier * (mouseDragingPosition + dragRelativePosition - (Vector2)transform.position), dragingClamp);
        }
        velocity = Vector2.ClampMagnitude(velocity, velocityClamp);
        transform.position += (Vector3)velocity;
        velocity *= (1 - linerDrag);
        ClearDebugPoints();
        RayTest(transform.position);
        for (int i = 0; i < subdividedRays; ++i)
        {
            float angle = 2 * Mathf.PI / subdividedRays * i;
            Vector2 position = (Vector2)transform.position + radius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if(RayTest(position))
            {
                velocity += (position - (Vector2)transform.position) * wallPushMultiplier;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        mouseDragingPosition = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRelativePosition = (Vector2)transform.position - eventData.position;
        mouseDragingPosition = eventData.position;
        draging = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        draging = false;
    }
    public void ClearDebugPoints()
    {
        foreach (DebugPoint p in debugPoints)
        {
            Destroy(p.gameObject);
        }
        debugPoints.Clear();
    }
    public bool RayTest(Vector2 source)
    {
        bool result = false;
        RaycastHit hitInfo;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(source), out hitInfo,LayerMask.GetMask("Black","White")))
        {
            if(hitInfo.transform.gameObject.layer== LayerMask.NameToLayer("Black"))
            {
                result=false;
            }
            else
            {
                result=true;
            }
        }
        if (IsDebugMode)
            DrawDebugPointAt(source, result ? Color.green : Color.red);
        return result;
    }
    public void DrawDebugPointAt(Vector2 vec)
    {
        if (IsDebugMode)
        {
            DebugPoint result = Instantiate(DebugPointPrefab, vec, Quaternion.identity, canvas.transform) as DebugPoint;
            debugPoints.Add(result);
        }
    }
    public void DrawDebugPointAt(Vector2 vec,Color color)
    {
        if (IsDebugMode)
        {
            DebugPoint result = Instantiate(DebugPointPrefab, vec, Quaternion.identity, canvas.transform) as DebugPoint;
            result.Color = color;
            debugPoints.Add(result);
        }
    }

}
