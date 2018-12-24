using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallType { Empty, Center, Right, Left };
public class MazeGenerator : MonoBehaviour {

    public GameObject mazeProto;
    public GameObject mazeRightProto;
    public GameObject mazeLeftProto;
    static Vector2Int mazeSize = new Vector2Int((int)Const.mapSize.x, (int)Const.mapSize.z);
    public static Transform[,] wallObj = new Transform[mazeSize.x, mazeSize.y];
    public static WallType[,] maze = new WallType[mazeSize.x, mazeSize.y];
    int numRightWall = 35;
    int numLeftWall = 35;
    // Use this for initialization
    void Start () {
		for(int i=0; i<mazeSize.x; i++)
            for(int j=0; j<mazeSize.y; j++) {
                if(i%2 == 0 && j%2 == 0)
                    maze[i, j] = WallType.Center;
                else
                    maze[i, j] = WallType.Empty;
            }
        for(int i = 0; i < numRightWall;) {
            int x = 2 * Mathf.CeilToInt(Random.Range(0, mazeSize.x / 2));
            int z = 2 * Mathf.CeilToInt(Random.Range(0, mazeSize.y / 2))+1;
            if (maze[x, z] == WallType.Empty) {
                maze[x, z] = WallType.Right;
                i++;
            }
        }
        for (int i = 0; i < numLeftWall;) {
            int x = 2 * Mathf.CeilToInt(Random.Range(0, mazeSize.x / 2 ))+1;
            int z = 2 * Mathf.CeilToInt(Random.Range(0, mazeSize.y / 2 ));
            if (maze[x, z] == WallType.Empty) {
                maze[x, z] = WallType.Left;
                i++;
            }
        }
        for (int i = 0; i < mazeSize.x; i++)
            for (int j = 0; j < mazeSize.y; j++) {
                if(maze[i, j] != WallType.Empty)
                    instantiateItem(Const.GameItemID.Wall, maze[i, j], new Vector3(i, 0, j));
            }
    }
    public void instantiateItem(Const.GameItemID id, WallType type, Vector3 position)
    {
        //Material m1 = (Material)Resources.Load(ItemMap.getTextureName(id));
        GameObject g;
        if(type == WallType.Center)
            g = Instantiate(mazeProto);
        else if(type == WallType.Right)
            g = Instantiate(mazeRightProto);
        else 
            g = Instantiate(mazeLeftProto);
        g.transform.parent = transform;
        position = position * Const.coordScale + Const.mapOrigin;
        position.y = Const.WallSize.y / 2;
        g.transform.localPosition = position;
        g.name = id.ToString();
        //g.GetComponent<Renderer>().material = m1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
