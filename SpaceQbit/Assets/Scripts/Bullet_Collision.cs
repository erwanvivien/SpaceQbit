using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Collision : MonoBehaviour
{
    public GameObject tmp;

    private int _damage;
    
    private bool _collision;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
    
    public bool GetCollision()
    {
        return _collision;
    }

    private void Start()
    {
        if (tmp == null)
            tmp = GameObject.FindWithTag("Perso");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf == false)
        {
            return;
        }
        string tags = other.gameObject.tag;
        _collision = true;

        switch (tags)
        {
            case "Mur":
                gameObject.SetActive(false);
                return;
            case "Objet":
                gameObject.SetActive(false);
                return;

            case "Killable":
                other.gameObject.GetComponent<Killable>().Attack(_damage);

                foreach (var q in GameObject.FindGameObjectsWithTag("Killable"))
                {
                    Vector3 transformPosition = q.transform.position;
                    Vector3 me = transform.position;

                    float distanceSquared = (transformPosition.x - me.x) * (transformPosition.x - me.x) + 
                                            (transformPosition.z - me.z) * (transformPosition.z - me.z);

                    if (distanceSquared <= 10)
                    {
                        q.GetComponent<Follow_Target>().SetTarget(tmp);
                    }
                } // SETS FOR EVERY NEARBY ENEMY THE TARGET
                
                gameObject.SetActive(false);
                return;
            
            default:
                _collision = false;
                return;
        }
    }
}