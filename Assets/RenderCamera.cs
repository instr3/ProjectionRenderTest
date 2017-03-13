using UnityEngine;
using System.Collections;

public class RenderCamera : MonoBehaviour {
    public RenderTexture RenderTexture;
    public static Camera Instance;
    public static int TextureWidth, TextureHeight;
	// Use this for initialization
	void Start () {
        Instance = GetComponent<Camera>();
        Instance.targetTexture = RenderTexture;
        TextureWidth = RenderTexture.width;
        TextureHeight = RenderTexture.height;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
