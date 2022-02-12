using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject menuGO;
    [SerializeField] GameEvent inventroyEnterEvent, inventroyExitEvent;
    bool isUsingMenu;
    bool isCallingMenu;

    public void HandleMenuCalls()
    {
        if (isCallingMenu)
            return;

        if (!isUsingMenu)
            CallMenu();
        else
            UncallMenu();
    }
    void CallMenu()
    {
        StartCoroutine(CO_HandleInteruptions());
        //menuGO.SetActive(true);
        inventroyEnterEvent.Raise();
        isUsingMenu = true;
    }

    void UncallMenu()
    {
        StartCoroutine(CO_HandleInteruptions());

        inventroyExitEvent.Raise();
        isUsingMenu = false;
        //StartCoroutine(CO_CloseMenuGO());
    }
    IEnumerator CO_CloseMenuGO()
    {
        yield return new WaitForSeconds(1f);
        menuGO.SetActive(false);
    }
    IEnumerator CO_HandleInteruptions()
    {
        isCallingMenu = true;
        yield return new WaitForSeconds(1.2f);
        isCallingMenu = false;
    }
}
