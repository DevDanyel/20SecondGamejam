using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{


    public AudioSource punchSound;
    public AudioSource poofSound;
    public AudioSource fightSound;
    private Vector2 startPos;

    //private IEnumerator PlayAnim;
    public GameObject poofAnim;
    [SerializeField] private string tagName;
    public TextMeshProUGUI gmOverText;

    public GameObject playbutton;
    public GameObject restartbutton;
    public GameObject inpufField;

    public ParticleSystem floofPartcles;

    public Image P2HealthBar;

    public float maxHealth = 30;
    public float P2Health;
    public TextMeshProUGUI inputName;
    public TextMeshProUGUI playerName;

    //player objects;
    public GameObject[] bodyParts;

    //script references
    void Start(){
        startPos = transform.position;
        P2Health = maxHealth;
        P2HealthBar.fillAmount = 1;
        poofAnim.active = false;
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = false;
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = false;
        }else{
            Debug.Log("no script found");
        }
        gmOverText.text = "";
        restartbutton.active = false;
        inputName.text = "Enter Name";
    }

    public void LoseHealth(float hitPower){
        P2Health -= hitPower;
        UpdateHealth(maxHealth, P2Health);
    }

    public void UpdateHealth(float mHealth, float CHealth){
        P2HealthBar.fillAmount = CHealth / mHealth;
    }

    

    private IEnumerator PlayAnim(){
        yield return new WaitForSeconds(.5f);
        poofAnim.active = false;
    }

    void Update(){
        

        if(P2Health == 0){
            GameOver();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
            playbutton.active = true;
        }
    }

    public void GameOver(){
        DeactivateBody();
        poofSound.Play(0);
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = false;
            gmOverText.text = "You Win";
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = false;
            gmOverText.text = "You Lose";
        }else{
            Debug.Log("no script found");
        }
        poofAnim.active = true;
        StartCoroutine("PlayAnim");
        P2Health = .1f;
        //make restart button show up
        restartbutton.active = true;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(tagName)){
            LoseHealth(3);
            UpdateHealth(maxHealth, P2Health);
            punchSound.Play(0);
            floofPartcles.Play();
        }
    }

    void DeactivateBody(){
        foreach (GameObject parts in bodyParts)
        {
            parts.active = false;   
        }

    }

    void ReactivateBody(){
        foreach (GameObject parts in bodyParts)
        {
            parts.active = true;   
        }

    }

    public void StartGame(){
        //could put in input validation later
        if(GetComponent<EnemyManager>()){
            //do nothing
        }else if(GetComponent<PlayerMovement>()){
            playerName.text = inputName.text;
        }else{
            Debug.Log("no script found");
        }
        
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = true;
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = true;
        }else{
            Debug.Log("no script found");
        }
        inpufField.active = false;
        fightSound.Play();
    }

    public void Pause(){
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = false;
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = false;
        }else{
            Debug.Log("no script found");
        }
    }

    public void RestartGame(){
        ReactivateBody();
        P2Health = maxHealth;
        P2HealthBar.fillAmount = 1;
        poofAnim.active = false;
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = false;
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = false;
        }else{
            Debug.Log("no script found");
        }
        gmOverText.text = "";
        transform.position = startPos; 
        playbutton.active = true; 
        inpufField.active = true;
    }





}
