using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMsgControllor : MonoBehaviour {

    public static GameObject msgObj;
	// Use this for initialization
	void Start () {
        msgObj = GameObject.Find("Msg");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void showMsg(string msg)
    {
        msgObj.SetActive(true);
        msgObj.GetComponent<Text>().text = msg;
    }
    public static void clearMsg()
    {
        msgObj.SetActive(false);
    }
}
