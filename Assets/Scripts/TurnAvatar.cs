using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAvatar : MonoBehaviour
{
    [SerializeField] private bool right;
    [SerializeField] private float duration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (right)
            {
                other.transform.DORotate(new Vector3(0,other.transform.eulerAngles.y+90,0),duration);
            }
            else
            {
                other.transform.DORotate(new Vector3(0, other.transform.eulerAngles.y - 90, 0), duration);
            }
            
        }
    }
}
