using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CodeLock : MonoBehaviour {

    [Header("Password to unlock the lock")]
    public string password = "55239";

    public UnityEvent OnUnlock;

    private ObjectWithLock objectWithLock;
    private GameObject codeLock;
    private Animator codeLockAnim;

    private GameObject redLight;
    private GameObject greenLight;

    void Start() {
        objectWithLock = FindObjectOfType<ObjectWithLock>();
        codeLock = transform.Find("Code Lock").gameObject;
        codeLockAnim = codeLock.GetComponent<Animator>();
        redLight = transform.Find("Red Light").gameObject;
        greenLight = transform.Find("Green Light").gameObject;
    }

    string passwordEntered = "";

    public void NumberPressed() {
        string numberPressed = EventSystem.current.currentSelectedGameObject.gameObject.name;

        passwordEntered += numberPressed;

        Check();
    }

    void Check() {
        if (passwordEntered.Length == 5 && !passwordEntered.Equals(password))
            WrongPassword();
        else if (passwordEntered.Length == 5 && passwordEntered.Equals(password))
            CorrectPassword();
    }

    void WrongPassword() {
        passwordEntered = "";
        StartCoroutine(BlinkRedLight());
    }

    void CorrectPassword() {
        StartCoroutine(BlinkGreenLight());
    }

    IEnumerator BlinkRedLight() {
        redLight.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        redLight.SetActive(false);

        yield return new WaitForSeconds(0.4f);

        redLight.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        redLight.SetActive(false);
    }

    IEnumerator BlinkGreenLight() {
        greenLight.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        greenLight.SetActive(false);

        yield return new WaitForSeconds(0.4f);

        greenLight.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        greenLight.SetActive(false);

        OnUnlock?.Invoke();

        StartCoroutine(objectWithLock.DeactivateLockScreen(true));
    }

}
