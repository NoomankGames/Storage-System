/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using System.Collections.Generic;
using UnityEngine;

//Storage class for working with its cells
public class Storage : MonoBehaviour
{
    public List<Cell> storageCells = new List<Cell>(0);

    /// <summary>
    /// The method checks all storage cells and puts items in the selected ones
    /// </summary>
    public void PutInStorage(Item targetItem, int count)
    {
        foreach(Cell targetCell in storageCells)
        {
            if(targetCell.storedItem == targetItem)
            {
                targetCell.AddItem(count);
                break;
            }
            else if(targetCell.storedItem == null)
            {
                targetCell.SetItem(targetItem, count);
                break;
            }
        }
    }
}