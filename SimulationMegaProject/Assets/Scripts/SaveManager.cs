using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveManager : MonoBehaviour
{
    private static SaveManager saveManager;

    public ExpirationManager expirationManager;

    public void Awake()
    {
        if (saveManager == null)
        {
            saveManager = this;
        }
        else
        {
            Destroy(this);
        }


        expirationManager = GameObject.FindObjectOfType<ExpirationManager>();
        Load();
    }

    public void SaveActivation()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/ActivationState.dat", FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, expirationManager.activated);

        file.Close();
    }

    public void SaveExpiration()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/ExpirationState.dat", FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, expirationManager.expired);

        file.Close();
    }

    public void SaveDateOfExpiration()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/DateOfExpirationState.dat", FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, expirationManager.dateOfExpiration);

        file.Close();
    }

    public void LoadActivation()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/ActivationState.dat", FileMode.Open);

        BinaryFormatter formatter = new BinaryFormatter();

        expirationManager.activated = formatter.Deserialize(file) as ActivationState;

        file.Close();
    }

    public void LoadExpiration()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/ExpirationState.dat", FileMode.Open);

        BinaryFormatter formatter = new BinaryFormatter();

        expirationManager.expired = formatter.Deserialize(file) as ExpirationState;

        file.Close();
    }

    public void LoadDateOfExpiration()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/DateOfExpirationState.dat", FileMode.Open);

        BinaryFormatter formatter = new BinaryFormatter();

        expirationManager.dateOfExpiration = formatter.Deserialize(file) as DateOfExpiration;

        file.Close();
    }

    public void Save()
    {
        SaveActivation();
        SaveExpiration();
        SaveDateOfExpiration();
    }
    public void Load()
    {
        LoadActivation();
        LoadExpiration();
        LoadDateOfExpiration();
    }
}
