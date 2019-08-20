using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect_click_prefab;
    public Vector3 targetPosition = Vector3.zero;
    private bool isMoving = false;  //鼠标是否按下
    private PlayerMove playerMove;

    void Start()
    {
        targetPosition = transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isColider = Physics.Raycast(ray, out hitInfo);
            if(isColider && hitInfo.collider.tag == Tags.ground)
            {
                isMoving = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        if (playerMove.isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isColider = Physics.Raycast(ray, out hitInfo);
            if (isColider && hitInfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitInfo.point);
            }
        }
        else
        {
            LookAtTarget(targetPosition);
        }
    }
    //生成点击效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //修改朝向
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.transform.LookAt(targetPosition);  //朝向的改变
    }
}
