using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    void Update()
    {
        // ���콺�� position ��������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Ŀ���� x��ǥ�� ����
        float realX = Mathf.Clamp(mousePosition.x, -3f, 3f);
        // x��ǥ�� ���ѽ�Ű�� Ŀ���� ��ġ�� ����
        transform.position = new Vector3(realX, transform.position.y, transform.position.z);
    }
}
