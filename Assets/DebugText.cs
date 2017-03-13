using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {
    private static DebugText Instance;
    Text text;
	// Use this for initialization
	void Start () {
        Instance = this;
        text = GetComponent<Text>();
    }
	public static void Log(object text)
    {
        Instance.text.text = text.ToString();
    }
}
