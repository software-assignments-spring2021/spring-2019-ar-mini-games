using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToThrow : MonoBehaviour

{

    private Vector3 touchPosition;

    float touchPositionY;
    float touchPositionX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MainSwipeFunctionality();
       
        
    }


    private void MainSwipeFunctionality(){

        if (Input.GetMouseButton(0))
        {
            float xPos = Input.mousePosition.x;
            float yPos = Input.mousePosition.y;
            Vector3 pos = Input.mousePosition;

           // Debug.Log("touched");
           // if (pos.z > 0.2 && pos.z < 1){
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos.z += yPos;
                this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(pos);


           // }

           


        }
    }
}
