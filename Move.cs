using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    bool isPressingMouse0 = false;
    bool isGetMouse0Up = false;
    public float timer;
    public float endTime;
    Vector3 endPosition;
    Vector3 nowPosition;
    Vector3 beginCubePos;
    GameObject cube;
    Transform cubesParent;

    private void Start()
    {
        beginCubePos = new Vector3(0, 0, 0);
        endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cube = Resources.Load<GameObject>("Prefabs/Cube");
        cubesParent = GameObject.Find("Cubes").transform;
    }

    void Update()
    {
        nowPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPressingMouse0 = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isPressingMouse0 = false;
        }

        if (isPressingMouse0 == true)
        {
            RecordTime(); //开始计时
            isGetMouse0Up = true;
        }
        if (isPressingMouse0 == false && isGetMouse0Up == true)
        {
            timer = 0;
            MovePiece();  //移动棋子
            CreateCube();  //创建新台子
        }
    }

    //鼠标左键按下 开始计时
    public void RecordTime()
    {
        timer += Time.deltaTime;
        endTime = timer;
        endPosition = new Vector3(nowPosition.x + endTime * 5, nowPosition.y, nowPosition.z);
    }

    //鼠标左键抬起 移动棋子 
    public void MovePiece()
    {
        this.transform.position = Vector3.Lerp(transform.position, endPosition, 0.5f);
    }

    //鼠标左键抬起 创建新台子
    public void CreateCube()
    {
        GameObject newCubeX;
        GameObject newCubeY;
        float a = 0;
        a = Random.value;
        Debug.Log(a);

        if (a <= 0.5f)
        {
            Vector3 endCubePosX = new Vector3(beginCubePos.x + Random.Range(1.2f, 3.5f), beginCubePos.y, beginCubePos.z);
            newCubeX = Instantiate(cube, endCubePosX, new Quaternion(0, 0, 0, 0), cubesParent);
            beginCubePos = endCubePosX;
        }
        else
        {
            Vector3 endCubePosY = new Vector3(beginCubePos.x, beginCubePos.y, beginCubePos.z + Random.Range(1.2f, 3.5f));
            newCubeY = Instantiate(cube, endCubePosY, new Quaternion(0, 0, 0, 0), cubesParent);
            beginCubePos = endCubePosY;
        }
        isGetMouse0Up = false;
    }

}
