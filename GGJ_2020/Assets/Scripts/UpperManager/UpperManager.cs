using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UpperManager : MonoBehaviour
{

    public List<RoomManager> Rooms = new List<RoomManager>();
    public GameObject Player1;
    public GameObject Player2;
    public float RunTime = 30;
    public bool started = false;
    private bool GameDone = false;
    public GameObject winnerPanel;
    public GameObject gamePanel;
    public GameObject GameOverPanel;
    public AudioSource EndSoundSource;
    public AudioClip endSound;
    public AudioClip winSound;
    public AudioClip countdownSound;
    
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Coundown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            ExitGame();

        if(!started || GameDone)
            return;
        
        RunTime -= Time.deltaTime;

        Timer.text = RunTime.ToString("N2");

        if(RunTime <= 0){
            GameOver();
            GameDone = true;
            Player1.GetComponent<CharacterMovement>().enabled = false;
            Player2.GetComponent<CharacterMovement>().enabled = false;
        }

        if(Rooms.All(asd => asd.Done)){
            AllFixed();
            GameDone = true;
            Player1.GetComponent<CharacterMovement>().enabled = false;
            Player2.GetComponent<CharacterMovement>().enabled = false;
        }
    }
    
    public void GameOver(){
        GameOverPanel.SetActive(true);
        EndSoundSource.clip = endSound;
        EndSoundSource.Play();
    }

    public void AllFixed(){
        winnerPanel.SetActive(true);
        EndSoundSource.clip = winSound;
        EndSoundSource.Play();
    }

    public void StartGame(bool Solo){
        StartCoroutine(StartCountdown(Solo));
        
    }

    public void Restart(){
        Debug.Log("ladataan");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame(){
        Application.Quit();
    }

    IEnumerator StartCountdown(bool Solo){

        Coundown.text = 3.ToString();
        EndSoundSource.volume = 0.75f;
        EndSoundSource.clip = countdownSound;
        EndSoundSource.Play();
        yield return new WaitForSeconds(1);
        Coundown.text = 2.ToString();
        EndSoundSource.Play();
        yield return new WaitForSeconds(1);
        Coundown.text = 1.ToString();
        EndSoundSource.Play();
        yield return new WaitForSeconds(1);
        Coundown.text = "GO";
        EndSoundSource.Play();

        if (Solo){
            Player2.SetActive(false);
        }
        started = true;
        Player1.GetComponent<CharacterMovement>().enabled = true;
        Player2.GetComponent<CharacterMovement>().enabled = true;

        yield return new WaitForSeconds(1);
        Coundown.text = "";
    }
}
