using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    [Header("login")]
    [SerializeField] private InputField m_InputNombreRegLog = null;
    [SerializeField] private InputField m_InputPasswordRegLog = null;

    [SerializeField] private InputField m_InputNombreReg = null;
    [SerializeField] private InputField m_InputApellidoReg = null;
    [SerializeField] private InputField m_InputCarreraReg = null;
    [SerializeField] private InputField m_InputCorreoReg = null;
    [SerializeField] private InputField m_InputPasswordReg = null;
    [SerializeField] private InputField m_InputPasswordReg2 = null;
    [SerializeField] private Text m_avisos = null;

    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;


    private NetworkManager m_networkManager = null;
    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void submitLogin()
    {
        if (m_InputNombreRegLog.text == "" || m_InputPasswordRegLog.text == "")
        {
            m_avisos.text = "Campo vacio, por favor verificar";
            return;
        }
        m_avisos.text = "procesando...";

        m_networkManager.checkUser(m_InputNombreRegLog.text, m_InputPasswordRegLog.text, delegate (Response response) {
            m_avisos.text = response.message;
            m_avisos.text = response.message;
        });

        //showRegister();

    }

    public void submitRegister()
    {
        if(m_InputNombreReg.text==""|| m_InputApellidoReg.text == ""|| m_InputCarreraReg.text == ""
            ||m_InputCorreoReg.text==""|| m_InputPasswordReg.text==""|| m_InputPasswordReg2.text==""){
            m_avisos.text = "Campo vacio, por favor verificar";
            return;
        }
        if (m_InputPasswordReg.text == m_InputPasswordReg2.text){
            m_avisos.text="procesando...";
            m_networkManager.CreateUser(m_InputNombreReg.text, m_InputApellidoReg.text, m_InputCarreraReg.text, m_InputCorreoReg.text, m_InputPasswordReg.text, delegate(Response response) {
               // m_avisos.text = response.message;
            });
        }
        else
        {
            m_avisos.text = "Contraseñas no iguales, por favor verificar";
        }

    }

    public void showLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);

    }

    public void showRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }
	
}
