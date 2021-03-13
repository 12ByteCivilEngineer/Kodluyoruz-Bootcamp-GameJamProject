using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        GameManager.isGameRunning = false;
        if (other.gameObject.tag == "Player")
        {
            //FindObjectOfType<GameManager>().GameWon();
            FindObjectOfType<BridgeCreater>().CreateBridge();
        }
    }
}
