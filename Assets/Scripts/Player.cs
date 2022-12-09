using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public bool gameplay = false;
    bool isRun=false;
    public float speed=1.5f;

    public float jumpForce = 20;
    public float gravity = -9.81f;
    float velocity;
    bool isDye = false;

    public int score;
    public Text ScoreText;
    public Text FinishText;

    private GameObject finishScreen;

    private bool onFloor = true;

    private void Start()
    {
        finishScreen = GameObject.Find("FinishScreen");
        finishScreen.SetActive(false);
        FinishText.text = "";
    }
    void Update()
    {

        if (gameplay)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if(!isRun)
            {
                YBotAnimController.Instance.Run();
                isRun = true;
            }

            if (Input.GetMouseButtonDown(0) && onFloor && gameplay)
            {
                YBotAnimController.Instance.Jump();
                velocity = jumpForce;
                onFloor = false;
            }
            
        }

        /*if (transform.position.z >= 203)
        {
            //Time.timeScale = 0;
            //Vector3 vec2 = transform.localPosition;
            //vec2.y = 90;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            //YBotAnimController.Instance.TurnRight();
        }*/

        if (isDye)
        {
            transform.DOMoveY(0, 0.25f);
            gravity = 0;
            YBotAnimController.Instance.Dye();
            isDye = false;
        }

        if(!onFloor)
        {
            velocity += gravity * Time.deltaTime;
            //Vector3 vec = new Vector3(0, velocity, 0);
            //transform.Translate(Vector3.Lerp(transform.position, vec*Time.deltaTime, 0.1f));
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "onFloor")
        {
            if (gameplay)
            {
                YBotAnimController.Instance.Run();
            }
            onFloor = true;
            transform.DOMoveY(0, 0.25f);
        }

        if(other.gameObject.tag == "onObstacle")
        {
            if (!onFloor)
            {
                score--;
            }
            gameplay = false;
            finishScreen.SetActive(true);
            isDye = true;
        }

        if (other.gameObject.tag == "onScore")
        {
            score++;
            ScoreText.text = score.ToString();
        }

        if (other.gameObject.tag == "Finish")
        {
            gameplay = false;
            FinishText.text = "Congrulations";
            YBotAnimController.Instance.HappyIdle(); 
            Invoke("ChangeScene", 3);
            
        }
    }

    private void ChangeScene()
    {
        score= 0;
        FinishText.text = "";
        var level = SceneManager.GetActiveScene().buildIndex;
        level++;
        level = level % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(level);
    }
}
