using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicleHamdler : MonoBehaviour
{

    public float hordeTimer = 3f;
    private enum State {LoadingScene, Waiting, OpenComputer, OpenMail, Read};
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource source1 = GameObject.GetComponent<AudioSource>();
        state = State.Waiting;
    }

    void MoveScreen()
    {
        
    }

    void OpenMail()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
    switch (state)
    {
            case State.LoadingScene:
                break; 
        case State.Waiting:

            break;
        case State.OpenComputer:
            // code block
            break;
        default:
            // code block
            break;
    }

}
}
