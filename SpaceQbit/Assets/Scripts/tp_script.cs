using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class tp_script : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    
    [SerializeField] private GameObject gObject;
    private GameObject _newOne;
    private float _time;
    private bool _enter;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Frame_Perso"))
        {
            var t = _newOne.GetComponentInChildren<Get_HP_TP>();
            t.Set((3 - _time) / 3 * 100f);

            if (_time >= 3)
            {
                GameObject.FindWithTag("Frame_Perso").transform.position = new Vector3(x, y, z);
                GameObject.FindWithTag("CameraFrameFUUUCK").transform.position = new Vector3(x, y, z) + Cam_Follow._offset;
            }
        }

        _time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frame_Perso"))
        {
            _time = 0;

            if (_newOne == null)
                _newOne = Instantiate(gObject);
            _newOne.transform.position = transform.position + Vector3.up * 2;

            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Frame_Perso"))
        {

            _time = 0;
            if (_newOne != null)
            {
                Destroy(_newOne);
            }

            _newOne = null;
        }
    }
}