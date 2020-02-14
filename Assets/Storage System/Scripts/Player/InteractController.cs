/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

public class InteractController : MonoBehaviour
{
    [SerializeField] private Storage _inventory = null;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            PickUpItem();
        }
    }

    /// <summary>
    /// The method picks up an item from the scene and adds it to inventory
    /// </summary>
    public void PickUpItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Item targetItem = hit.transform.GetComponent<Item>();
            if (targetItem != null)
            {
                Item newItem = Resources.Load(hit.transform.GetComponent<Item>().itemName, typeof(Item)) as Item;
                _inventory.PutInStorage(newItem, targetItem.itemCount);

                Destroy(targetItem.gameObject);
            }
        }
    }
}