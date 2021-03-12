using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 correctionVector = new Vector3();

    //PlayerInputController inputController;
    private void Start()
    {
        //inputController = FindObjectOfType<PlayerInputController>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition + correctionVector;
    }
}
