using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubicleHamdler : MonoBehaviour
{

    public float timeLimit = 3f;
    public float timer = 0f;
    private enum State {LoadingScene, FadeIn, Waiting, OpenComputer, OpenMail, Read, FadeOut};
    private State state;

    float blackscreenOpacity = 1f;
    Vector3 initialPCPosition;
    Vector3 finalPCPosition;

    public SpriteRenderer blackscreen;
    public TextMeshProUGUI day;
    public GameObject pc;
    public GameObject teams;
    public GameObject heroImage;
    public AudioSource teamsSound;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource source1 = GameObject.GetComponent<AudioSource>();
        state = State.LoadingScene;
        initialPCPosition = new Vector3(0, -10f, 0);
        finalPCPosition = new Vector3(0, -0.732f, 0);
        pc.transform.position = initialPCPosition;

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
        Debug.Log(timer);

        switch (state)
        {
            case State.LoadingScene:
                //Shows a black screen and the number of the day
                timer += Time.deltaTime; 
                if (timer >= timeLimit)
                {
                    state = State.FadeIn;
                    timeLimit = 4f;
                    timer = 0;
                }
                break;

            case State.FadeIn:
                //fades out the black screen into the cubicle scene
                if (blackscreen.color[3] > 0)
                {
                    blackscreenOpacity = blackscreen.color[3] - 0.001f;
                    blackscreen.color = new Color(0f,0f,0f,blackscreenOpacity);
                    day.color = new Color(1f, 1f, 1f, blackscreenOpacity);
                }
                else
                {
                    state = State.Waiting;
                }
                break;
            case State.Waiting:
                timer += Time.deltaTime;
                if (timer >= timeLimit)
                {
                    state = State.OpenComputer;
                    teamsSound.Play();
                }
                else
                {

                }
                break;
            case State.OpenComputer:
                if (pc.transform.position[1] < finalPCPosition[1])
                {
                    pc.transform.position += 0.002f * (finalPCPosition - pc.transform.position);
                }
              
                break;
            default:
                // code block
                break;
        }

    void FixedUpdate()
    {

    }

}
}
