/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "Item's name";
    [Multiline(lines:3)] public string itemDescription = "Item's description";

    public int itemCount = 1;

    public Sprite itemIcon = null;

    private void Awake()
    {
        transform.name = itemName;
    }
}