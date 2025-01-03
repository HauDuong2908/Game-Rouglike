using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotManager : MonoBehaviour
{
    private SaveSlots[] saveSlots;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlots>();
    }
}
