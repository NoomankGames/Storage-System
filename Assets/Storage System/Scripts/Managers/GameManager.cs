/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inventoryWindow = null;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        SwitchWindowState(inventoryWindow, "Inventory");
    }

    /// <summary>
    /// The method changes the state of the specified window when you click on the specified button
    /// </summary>
    /// <param name="buttonName"></param>
    private void SwitchWindowState(GameObject target, string buttonName)
    {
        if (Input.GetButtonDown(buttonName))
        {
            target.SetActive(!target.activeSelf);

            if (target.activeSelf == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}