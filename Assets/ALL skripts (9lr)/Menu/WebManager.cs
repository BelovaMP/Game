using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class UserData
{
    public Player playerData;
    public Error error;
}
[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}
[System.Serializable]
public class Player
{
    public int Number_Save;
    public string login;

    public Player()
    {

    }

   

    public void SetNumber_Save(string color) => Number_Save = color;
    public void SetName_User(string name) => Name_User = name;
}

//WebManager

public class WebManager : MonoBehaviour
{
    public static UserData userData = new UserData();
    [SerializeField] private string targetURL;

    [SerializeField] private UnityEvent OnLogged, OnRegistered, OnError;

    public enum RequestType
    {
        logging, register, save
    }


    public string GetUserData(UserData data)
    {
        return JsonUtility.ToJson(data);
    }

    public UserData SetUserData(string data)
    {
        print(data);
        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() { errorText = "text", isError = true };
        userData.playerData = new Player("Yagir", "", "");
    }

    public void Login(string login, string password)
    {
        StopAllCoroutines();
        if (CheckString(login) && CheckString(password))
        {
            Logging(login, password);
        }
        else
        {
            userData.error.errorText = "To small length";
            OnError.Invoke();
        }
    }
    public void Registration(string login, string password, string password2, string Name_User)
    {
        StopAllCoroutines();
        if (CheckString(login) && CheckString(password) && CheckString(password2) && CheckString(Name_User) && password == password2)
        {
            Registering(login, password, password2, Name_User);
        }
        else
        {
            userData.error.errorText = "To small length";
            OnError.Invoke();
        }
    }

    public bool CheckString(string toCheck)
    {
        toCheck = toCheck.Trim();
        if (toCheck.Length > 4 && toCheck.Length < 16)
        {
            return true;
        }
        return false;
    }

    public void SaveData(int Number_Save, string Name_User, string main, string second)
    {
        StopAllCoroutines();
        SaveProgress(Number_Save, Name_User, main, second);
    }

    public void Logging(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.logging.ToString());
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form, RequestType.logging));
    }

    public void Registering(string login, string password1, string password2, string Name_User)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.register.ToString());
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        form.AddField("Name_User", Name_User);
        StartCoroutine(SendData(form, RequestType.register));
    }
    public void SaveProgress(int Number_Save, string Name_User)
    {
        WWWForm form = new WWWForm();
        form.AddField("type", RequestType.save.ToString());
        form.AddField("Number_Save", Number_Save);
        form.AddField("Name_User", Name_User);
        StartCoroutine(SendData(form, RequestType.save));
    }

    IEnumerator SendData(WWWForm form, RequestType type)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(targetURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var data = SetUserData(www.downloadHandler.text);
                if (!data.error.isError)
                {
                    if (type != RequestType.save)
                    {
                        userData = data;
                        if (type == RequestType.logging)
                        {
                            OnLogged.Invoke();
                        }
                        else
                        {
                            OnRegistered.Invoke();
                        }
                    }
                }
                else
                {
                    userData = data;
                    OnError.Invoke();
                }
            }
        }
    }
}
