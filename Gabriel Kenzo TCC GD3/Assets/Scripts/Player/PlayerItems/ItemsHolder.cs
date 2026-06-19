using UnityEngine;
using System.Collections.Generic;

public class ItemsHolder
{
    public static float money;
    public static List<InventoryItem> items = new List<InventoryItem>();
    public static List<InventoryItem> gameItems = new List<InventoryItem>();
    public static List<InventoryItem> upgrades = new List<InventoryItem>();
    public static List<InventoryItem> consumables = new List<InventoryItem>();
    public static List<InventoryItem> unlockedGlyphs = new List<InventoryItem>();
}
