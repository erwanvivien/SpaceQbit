using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class tp_script : MonoBehaviour
{
    [SerializeField] private string sceneToTp;
    [SerializeField] private GameObject gObject;
    private GameObject _newOne;
    private float _time;
    private bool _enter;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Frame_Perso"))
        {
            Get_Hp t = _newOne.GetComponentInChildren<Get_Hp>();
            t.Set((3 - _time) / 3 * 100f);

            if (_time >= 3)
            {
                if (int.TryParse(sceneToTp, out var o))
                    SceneManager.LoadScene(o);
                else
                    SceneManager.LoadScene(sceneToTp);
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