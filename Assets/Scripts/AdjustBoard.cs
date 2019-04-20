using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustBoard : MonoBehaviour
{
    // Start is called before the first frame update
    bool didPress;
    public int DistanceToCamera;

    private void Start()
    {
        didPress = false;
    }

    public void AdjustBoardMain(){
        GameObject board = GameObject.Find("BasicBoard");
        if (didPress == false)
        {
            MakeBoardChildOfCamera(board);
        }
        else
        {
            DeparentBoard(board);
        }
        didPress = !didPress;
    }

    void MakeBoardChildOfCamera(GameObject board)
    {
        GameObject mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        board.transform.parent = mainCameraObj.transform;
        
        Vector3 p = mainCameraObj.transform.forward * DistanceToCamera + mainCameraObj.transform.position;
        board.transform.position = p;
        var fwd = Camera.main.transform.forward;
        board.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.up, -Camera.main.transform.forward);
        GameObject.Find("AdjustBoardButton").GetComponentInChildren<Text>().text = "Place Board";
    }

    void DeparentBoard(GameObject board)
    {   
        board.transform.parent = null;
        GameObject.Find("AdjustBoardButton").GetComponentInChildren<Text>().text = "Adjust Board";
    }
}
