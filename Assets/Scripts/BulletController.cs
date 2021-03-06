﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { Handgun, MachineGun, Rifle, Rocket, Mine, Bump, Wall, ExamPaper, Laplace }
public class BulletController : MonoBehaviour {
    public Transform BulletProto;
    //public List<Transform> Bullets = new List<Transform>();
    public BulletType selectedBullet = BulletType.Handgun;
    public Transform mainActor;
    public int numWeapon = 9;

    float lastShootTime;
    // Use this for initialization
    void Start () {
        lastShootTime = 0;
    }
    Bullet getObjectById(BulletType type)
    {
        if (type == BulletType.Handgun)
            return Const.Handgun;
        if (type == BulletType.MachineGun)
            return Const.MachineGun;
        if (type == BulletType.Rifle)
            return Const.Rifle;
        if (type == BulletType.Rocket)
            return Const.Rocket;
        if (type == BulletType.Mine)
            return Const.Mine;
        if (type == BulletType.Bump)
            return Const.Bump;
        if (type == BulletType.Wall)
            return Const.Wall;
        if (type == BulletType.ExamPaper)
            return Const.ExamPaper;
        if (type == BulletType.Laplace)
            return Const.Laplace;
        return Const.Handgun;
    }
    // Update is called once per frame
    void Update ()
    {
        #region MouseClick
        if (Input.GetMouseButton(0)) {
            if(Time.time - lastShootTime > getObjectById(selectedBullet).coolTime) {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                Transform bullet = Instantiate(BulletProto);
                bullet.position = mainActor.position + mainActor.forward;
                bullet.GetComponent<Rigidbody>().velocity = ray.direction.normalized * getObjectById(selectedBullet).speed;
                bullet.tag = "Bullet";
                bullet.name = selectedBullet.ToString();
                bullet.localScale = getObjectById(selectedBullet).size;
                lastShootTime = Time.time;
                //Debug.Log(Tools.getMapIndexByPosition(mainActor.transform.position));
                //mainActor.GetComponent<Rigidbody>().AddForce(-1 * mainActor.transform.forward * getObjectById(selectedBullet).recoil);
                //Bullets.Add(bullet);
            }
        }
        if (Input.GetMouseButton(1)) {
            /*
            if (toolbox.isSelected() && Time.time - lastClickTime > 0.5) {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit rch;
                if (Physics.Raycast(ray, out rch)) {
                    Vector3 target = rch.point + rch.normal / 2;
                    target.x = Mathf.Round(target.x);
                    target.y = Mathf.Round(target.y);
                    target.z = Mathf.Round(target.z);
                    ground.instantiateItem(toolbox.deleteSeletedItem(), target);
                }
                lastClickTime = Time.time;
            }*/
        }
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0f) {
            selectedBullet -= (int)Input.mouseScrollDelta.y;
            selectedBullet  = (BulletType)((int)selectedBullet % numWeapon);
            if (selectedBullet < 0) selectedBullet += numWeapon;
            GameMsgControllor.showMsg(selectedBullet.ToString());
            StartCoroutine("timer_2s");
        }

        #endregion
    }
    IEnumerator timer_2s()
    {
        yield return new WaitForSeconds(2);
        GameMsgControllor.clearMsg();
    }
}
