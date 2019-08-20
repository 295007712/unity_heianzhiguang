using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPosition;//位置偏移
    public float distance = 0;
    public float scrollSpeed = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }
    
    void Update()
    {
        transform.position = player.position + offsetPosition;
        ScrolView();
    }
    //拉近摄像头距离
    void ScrolView()
    {
        print(Input.GetAxis("Mouse ScrollWheel"));  //向后 返回负值（拉近事业） 向前滑动 返回正直（拉远视野）
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);    //摄像头距离限制 最大最小
        offsetPosition = offsetPosition.normalized * distance; // normalized :当前向量是不改变，返回一个新的规范化的向量
    }
}
