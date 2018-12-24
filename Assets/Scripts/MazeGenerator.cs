using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject mazeProto;
    public static bool[,] maze = new bool[(int)Const.mapSize.x, (int)Const.mapSize.z];
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
