using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{


    public AudioSource punchSound;

    //private IEnumerator PlayAnim;
    public GameObject poofAnim;
    [SerializeField] private string tagName;
    public TextMeshProUGUI gmOverText;



    public Image P2HealthBar;
    //public GameManager gm;

    public float maxHealth = 30;
    public float P2Health;

    //player objects;
    public GameObject[] bodyParts;

    //script references
    void Start(){
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
            DeactivateBody();
            
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
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(tagName)){
            LoseHealth(3);
            UpdateHealth(maxHealth, P2Health);
            punchSound.Play(0);
        }
    }

    void DeactivateBody(){
        foreach (GameObject parts in bodyParts)
        {
            parts.active = false;   
        }

    }

    public void StartGame(){
        if(GetComponent<EnemyManager>()){
            GetComponent<EnemyManager>().enabled = true;
        }else if(GetComponent<PlayerMovement>()){
            GetComponent<PlayerMovement>().enabled = true;
        }else{
            Debug.Log("no script found");
        }
        
    }




}
