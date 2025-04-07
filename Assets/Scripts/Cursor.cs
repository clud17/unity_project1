using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    void Update()
    {
        // 마우스의 position 가져오기
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 커서의 x좌표를 제한
        float realX = Mathf.Clamp(mousePosition.x, -3f, 3f);
        // x좌표를 제한시키고 커서의 위치를 설정
        transform.position = new Vector3(realX, transform.position.y, transform.position.z);
    }
}
