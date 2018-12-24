using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public GameObject mazeProto;
    static Vector2Int mazeSize = new Vector2Int((int)Const.mapSize.x, (int)Const.mapSize.z);
    public static Transform[,] wallObj = new Transform[mazeSize.x, mazeSize.y];
    public static bool[,] maze = new bool[mazeSize.x, mazeSize.y];
    // Use this for initialization
    void Start () {
		for(int i=0; i<mazeSize.x; i++)
            for(int j=0; j<mazeSize.y; j++) {
                if(i%2 == 0 && j%2 == 0)
                    maze[i, j] = true;
                else
                    maze[i, j] = false;
            }
        for (int i = 0; i < mazeSize.x; i++)
            for (int j = 0; j < mazeSize.y; j++) {
                if(maze[i, j])
                    instantiateItem(Const.GameItemID.Wall, new Vector3(i, 0, j));
            }
    }
    public void instantiateItem(Const.GameItemID id, Vector3 position)
    {
        //Material m1 = (Material)Resources.Load(ItemMap.getTextureName(id));
        GameObject g = Instantiate(mazeProto);
        g.transform.parent = transform;
        position = position * Const.coordScale + Const.mapOrigin;
        position.y = Const.WallSize.y / 2;
        g.transform.position = position;
        g.name = id.ToString();
        //g.GetComponent<Renderer>().material = m1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
