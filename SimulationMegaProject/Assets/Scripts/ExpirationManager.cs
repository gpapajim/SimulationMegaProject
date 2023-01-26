using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpirationManager : MonoBehaviour
{
    private static ExpirationManager expManager;

    public SaveManager saveManager;
    public float expirationTimer;
    public ActivationState activated;
    public ExpirationState expired;
    public DateOfExpiration dateOfExpiration;
    

    public DateOfExpiration trialTimer;

    public GameObject trialScreen;

    public bool sceneSelected;

    public bool trialOpen;

    private void Awake()
    {
        

        if (expManager == null)
        {
            expManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

    }

    public void Start()
    {
        if (activated.activated == true)
        {
            SceneManager.LoadSceneAsync("MenuSelection");
        }

        trialTimer.min = 900f;
        trialOpen = false;
    }

    public void Update()
    {

        saveManager.Save();

        expirationTimer = dateOfExpiration.timerExpiration;

        if (trialOpen == true)
        {
            trialScreen.SetActive(true);
            Cursor.visible = true;
        }
        if (trialOpen == false)
        {
            trialScreen.SetActive(false);
        }


        if (activated.activated == true)
        {
            
            dateOfExpiration.timerExpiration -= Time.deltaTime;
        }

        /*if (trialOpen == false && activated.activated == true)
        {
            trialTimer.min -= Time.deltaTime; 
        }*/

        if (trialTimer.min < 0 && activated.activated == true)
        {
            trialOpen = true;
            trialTimer.min = 900f;
        }

        if (dateOfExpiration.timerExpiration < 0 && activated.activated == true)
        {
            dateOfExpiration.day -= 1;
            dateOfExpiration.timerExpiration = 3600f;
        }

        if (dateOfExpiration.day<0 && activated.activated == true)
        {
            expired.expired = true;
        }

        if (expired.expired==true)
        {
            activated.activated = false;
            trialTimer.min = 900f;
        }

        if (expired.expired == true && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Expired"))
        {
            SceneManager.LoadScene("Expired");
        }
         

    }
}
