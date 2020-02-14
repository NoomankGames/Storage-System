/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//A cell class that allows you to work with their stored items
public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Cell Information")]
    public Item storedItem = null;
    public int countStored = 0;
    [HideInInspector] public bool selected = false;

    [Header("UI")]
    [SerializeField] private Image _imageStored = null;
    [SerializeField] private Text _countStoredText = null;

    private void Awake()
    {
        _imageStored.preserveAspect = true;
        CheckStoredItem();
    }

    private void Update()
    {
        if (selected == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                DropItem(1);
            }
        }
    }

    /// <summary>
    /// The method sets the stored item and its quantity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void SetItem(Item item, int count)
    {
        storedItem = item;
        countStored = count;
        CheckStoredItem();
    }

    /// <summary>
    /// The method adds the specified number of items
    /// </summary>
    /// <param name="count"></param>
    public void AddItem(int count)
    {
        countStored += count;
        CheckStoredItem();
    }

    /// <summary>
    /// The method removes the specified number of items
    /// </summary>
    /// <param name="count"></param>
    public void RemoveItem(int count)
    {
        countStored -= count;
        CheckStoredItem();
    }

    /// <summary>
    /// The method drop on scene the specified number of items
    /// </summary>
    /// <param name="count"></param>
    public void DropItem(int count)
    {
        if (storedItem != null)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 place = new Vector3(player.localPosition.x, player.localPosition.y, player.localPosition.z + 1.0f);
            place = player.TransformVector(place);

            Item dropedItem = Instantiate(storedItem) as Item;
            dropedItem.itemCount = count;
            dropedItem.transform.position = place;

            countStored -= count;
            CheckStoredItem();
        }
    }

    /// <summary>
    /// Method checks for stored item
    /// </summary>
    private void CheckStoredItem()
    {
        if (countStored <= 0)
        {
            storedItem = null;
            countStored = 0;
        }

        if (storedItem == null)
        {
            countStored = 0;
            _countStoredText.text = string.Empty;

            _imageStored.sprite = null;
            _imageStored.gameObject.SetActive(false);
        }
        else
        {
            _countStoredText.text = countStored.ToString();

            _imageStored.sprite = storedItem.itemIcon;
            _imageStored.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
    }
}