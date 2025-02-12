using System;
using System.Net;
using UnityEngine;

public static class CursorPosition
{
    public static RaycastHit RayHit()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayOrigin, out RaycastHit hitInfo, Mathf.Infinity);
        return hitInfo;
    }
    public static Vector3 SidePosition()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayOrigin, out RaycastHit hitInfo, Mathf.Infinity, 1 << 8);
        return hitInfo.point;
    }

    public static Vector3 RayPosition() => RayHit().point;
    public static GameObject RayObject() => RayHit().transform.gameObject;


    public static Vector3 RayEnd()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        return rayOrigin.GetPoint(-Camera.main.transform.position.z);
    }
}
