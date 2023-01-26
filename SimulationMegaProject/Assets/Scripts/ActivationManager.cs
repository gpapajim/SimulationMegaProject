using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ActivationManager : MonoBehaviour
{

    
    public GameObject activationMenu;

    public TMP_InputField codeGet;
    public string codeUsed;
    public TextMeshProUGUI activationInfo;

    //public  CodeHolder codes;
    public static ActivationManager activationManager;
    

    public ActivationState activated;
    public ExpirationState expired;
    public DateOfExpiration dateOfExpiration;

    
    public ExpirationManager expManager;
    public SaveManager saveManager;
    //

    public void Update()
    {
        

        

        
    }


    public void Activate()
    {
        codeUsed = codeGet.text;

       /* foreach (Codes code in codes.codes.codeList)
        {
            if (codeUsed == code.code)
            {
                expManager.activated.activated = true;
                Expiration();
                SceneManager.LoadSceneAsync("MenuSelection");
                return;
            } 
        } */

        activationInfo.text = "Wrong code!";
    }

    public void Expiration()
    {
        expManager.dateOfExpiration.day = 900;
        expManager.dateOfExpiration.timerExpiration = 3600f;



        /*dateOfExpiration.year = year + 1;

        if(day>27)
        {
            dateOfExpiration.month = month + 1;
            dateOfExpiration.day = 1;
        }
        if(day<28)
        {
            dateOfExpiration.month = month;
            dateOfExpiration.day = day;
        }
        */
    }
}
