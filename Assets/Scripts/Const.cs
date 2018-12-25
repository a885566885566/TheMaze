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
public struct Bullet
{
    public float power;
    public float speed;
    public float coolTime;
    public float recoil;
    public Vector3 size;
    public Bullet(float nPower, float nSpeed, float nCool, float nRecoil, Vector3 nSize)
    {
        power = nPower;
        size = nSize;
        coolTime = nCool;
        recoil = nRecoil;
        speed = nSpeed;
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
    public static float coordScale = 10;
    public static Vector3 mapSize = new Vector3Int(19, 0, 19);
    public static Vector3 WallSize = new Vector3Int(5, 10, 5);
    public static Vector3 mapOrigin = -1f* coordScale * mapSize / 2;
    public static int numWall = 30;
    // Item Configure
    public const int numItems = 7;
    public enum GameItemID { Empty, Wall, asdd, asd, Creeper, Slime, MainActor };
    // Main Actor Configure
    public const int attackPower = 10;  // MainActor Attack Power
    public const int maxLive = 13;
    // Enemy Configure
    public const int numEnemy = 20;
    public const float appearRadius = 15;
    // Weapon
    //                                      power, speed, cool, recoil, size, 
    public static Bullet Handgun = new Bullet(10f, 100f, 0f, 100f, new Vector3(0.1f, 0.1f, 0.1f));
    public static Bullet MachineGun = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Rifle = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Rocket = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Mine = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Bump = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Wall = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet ExamPaper = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    public static Bullet Laplace = new Bullet(10f, 10f, 1f, 0, new Vector3(1f, 1f, 1f));
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
public static class Tools
{
    public static Vector2Int getMapIndexByPosition(Vector3 p)
    {
        p = p / Const.coordScale + Const.mapSize / 2;
        return new Vector2Int(Mathf.FloorToInt(p.x), Mathf.FloorToInt(p.z));
    }
}