using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllor : MonoBehaviour
{
    public Transform mainActor;
    public Transform zombieProto;
    List<Transform> Enemies = new List<Transform>();

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        InvokeRepeating("ZombieGenerator", 1, 2);
    }
    void ZombieGenerator()
    {
        if (Enemies.Count < Const.numEnemy)
            instantiateItem();
    }
    public void instantiateItem()
    {
        //Material m1 = (Material)Resources.Load(ItemMap.getTextureName(id));
        Transform g = Instantiate(zombieProto);
        g.transform.parent = transform;
        g.transform.position = new Vector3(Random.Range(-10, 10)+50, 2, Random.Range(-10, 10)+50);
        Enemies.Add(g);
        //g.GetComponent<Renderer>().material = m1;
    }
}
