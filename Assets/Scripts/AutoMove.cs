using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {
    public Transform mainActor;
    Stack<Vector2Int> path = new Stack<Vector2Int>();
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void calPath()
    {
        path.Clear();
        Vector2Int selfIndex = Tools.getMapIndexByPosition(transform.position);
        Vector2Int targetIndex = Tools.getMapIndexByPosition(mainActor.position);
        int distance = 0;
        while(distance < 30 && selfIndex != targetIndex) {
            Vector2Int offset = targetIndex - selfIndex;

        }
    }
}
