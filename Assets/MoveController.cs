using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public float MoveSpeed;
    Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update () {
        //rigidBody.AddForce(MoveSpeed*new Vector3(0, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));
        
        //DebugText.Log(PositionToPixel(transform.position));

    }
    //Vector2 PositionToPixel(Vector3 position)
    //{
        //Vector3 relativePosition = RenderCamera.Instance.WorldToViewportPoint(position);
        //return new Vector2(relativePosition.x * RenderCamera.TextureWidth, relativePosition.y * RenderCamera.TextureHeight);

    //}
}
