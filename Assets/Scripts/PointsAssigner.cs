using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAssigner : MonoBehaviour
{
    public int pointsValue;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dart")){

            this.gameObject.GetComponentInParent<BoardController>().UpdateScore(pointsValue);

           

        }
    }


}
