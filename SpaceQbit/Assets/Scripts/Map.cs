using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static float posX;
    public static float posY;
    public static float posZ;

    public float x, y, z;

    private void Start()
    {
        posX = x;
        posY = y;
        posZ = z;
    }
}
