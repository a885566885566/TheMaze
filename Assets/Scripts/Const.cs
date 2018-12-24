using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Creature{
    public float maxLive;
    public float attackPower;
    public float trackDistance;
    public float attackDistance;
    public float audioDistance;
    public Creature(float live, float power, float track, float attack, float audio)
    {
        maxLive = live;
        attackPower = power;
        trackDistance = track;
        attackDistance = attack;
        audioDistance = audio;
    }
}
public class Const{
    // Input Configure
    public const float rotateSpeed = 0.3f;
    public const float updownSpeed = 0.3f;
    public const float moveSpeed = 5f;
    // Time Configure
    public const int dayRoutine = 60;
    public const float attackTimeInterval = 0.5f;
    // Map Configure
    public static float coordScale = 5;
    public static Vector3 mapSize = new Vector3Int(19, 0, 19);
    public static Vector3 WallSize = new Vector3Int(5, 10, 5);
    public static Vector3 mapOrigin = -1f* coordScale * mapSize / 2;
    public static int numWall = 30;
    // Item Configure
    public const int numItems = 7;
    public enum GameItemID { Empty, Wall, DirtGrass, Stone, Creeper, Slime, MainActor };
    // Main Actor Configure
    public const int attackPower = 10;  // MainActor Attack Power
    public const int maxLive = 13;
    // Enemy Configure
    public const int numEnemy = 20;
    public const float appearRadius = 15;
    // Creeper
    public static Creature Creeper = new Creature(20, 1, 30, 5, 10);
    public static Creature Slime = new Creature(20, 1, 30, 5, 10);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
