using System;
using System.Collections;
using UnityEngine;


public class NetworkManager : MonoBehaviour {

    public void CreateUser( string userName, string apellido, string carrera, string correo, string password, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(userName, apellido, carrera, correo, password, response));

    }


    private IEnumerator CO_CreateUser(string userName, string apellido, string carrera, string correo, string password, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("apellido", apellido);
        form.AddField("carrera", carrera);
        form.AddField("correo", correo);
        form.AddField("password", password);

        WWW w = new WWW("http://localhost:8080/Game/createUser.php", form);
        yield return w;

        print(w.text);

        response(JsonUtility.FromJson<Response>(w.text));


    }
    public void checkUser(string userName, string password, Action<Response> response)
    {
        StartCoroutine(CO_checkUser(userName, password, response));

    }


    private IEnumerator CO_checkUser(string userName, string password, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("password", password);

        WWW w = new WWW("http://localhost:8080/Game/checkUser.php", form);
        yield return w;

        print(w.text);

        response(JsonUtility.FromJson<Response>(w.text));


    }
}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}
