using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject obj;
    public Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 InitPointOnScreen()
    {
        Vector3 posMouse = Input.mousePosition;
        
        //posMouse.y -= 400;
        //posMouse.x -= 967;

        Ray ray = mainCam.ScreenPointToRay(posMouse);
            
        return new Vector3(ray.direction.x, 0, ray.direction.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 tmp = InitPointOnScreen();

            Instantiate(obj);
        }

    }
}
