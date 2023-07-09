using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static SceneMaster;
public class CubicleHamdler : MonoBehaviour
{

    public float timeLimit = 1.5f;
    public float speed = 15;
    public float timer = 0f;
    private enum State {LoadingScene, FadeIn, Waiting, OpenComputer, Read, OpenHeroImage,HeroImage, FadeOut};
    private State state;

    float blackscreenOpacity = 1f;
    float heroOpacity = 0f;
    Vector3 initialPCPosition;
    Vector3 finalPCPosition;

    public SpriteRenderer blackscreen;
    public TextMeshProUGUI day;
    public TextMeshProUGUI email;
    public GameObject pc;
    public GameObject teams;
    public SpriteRenderer heroImage;
    public AudioSource teamsSound;

    // Start is called before the first frame update
    void Start()
    {

        state = State.LoadingScene;
        initialPCPosition = new Vector3(0, -10f, 0);
        finalPCPosition = new Vector3(0, -0.732f, 0);
        pc.transform.position = initialPCPosition;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);

        switch (state)
        {
            case State.LoadingScene:
                //Shows a black screen and the number of the day
                timer += Time.deltaTime * speed; 
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
                    blackscreenOpacity = blackscreen.color[3] - 0.001f * speed;
                    blackscreen.color = new Color(0f,0f,0f,blackscreenOpacity);
                    day.color = new Color(1f, 1f, 1f, blackscreenOpacity);
                }
                else
                {
                    state = State.Waiting;
                }
                break;
            case State.Waiting:
                timer += Time.deltaTime * speed;
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
                if (pc.transform.position[1] < finalPCPosition[1]-0.2f)
                {
                    pc.transform.position += 0.002f * (finalPCPosition - pc.transform.position) * speed;
                }
                else
                {
                    state = State.Read;
                    SceneMaster.initiateEmailText = true;
                }
              
                break;
            case State.Read:
                if (SceneMaster.textDone&&SceneMaster.firstCubicleScene) { state = State.OpenHeroImage; }
                else if (SceneMaster.textDone) { state = State.FadeOut; }
                break;
            case State.OpenHeroImage:

                if (heroOpacity < 1)
                {
                    heroOpacity = heroImage.color[3] + 0.001f * speed;
                    heroImage.color = new Color(1f, 1f, 1f, heroOpacity);
                }
                else
                {
                    state = State.HeroImage;
                }
                break;

            case State.HeroImage:
                if (Input.GetMouseButtonDown(0))
                {
                    state = State.FadeOut;
                }
                break;

            case State.FadeOut:
                if (blackscreen.color[3] < 1)
                {
                    blackscreenOpacity = blackscreen.color[3] + 0.001f * speed;
                    blackscreen.color = new Color(0f, 0f, 0f, blackscreenOpacity);
                }
                else
                {
                    SceneMaster.firstCubicleScene = false;
                    SceneMaster.loadNextLevel();

                }
                break;
            default:
                // code block
                break;
        }

}
}
