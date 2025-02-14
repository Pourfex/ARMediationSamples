using UnityEngine;
using System.Collections.Generic;

public static class ObjectTracker
{
    private static HashSet<string> clickedObjects = new HashSet<string>();

    public static void MarkObjectAsClicked(string objectName)
    {
        clickedObjects.Add(objectName);
        PlayerPrefs.SetString("ClickedObjects", string.Join(",", clickedObjects));
        PlayerPrefs.Save();
    }

    public static bool IsObjectClicked(string objectName)
    {
        LoadClickedObjects();
        return clickedObjects.Contains(objectName);
    }

    public static void LoadClickedObjects()
    {
        if (clickedObjects.Count == 0)
        {
            string savedData = PlayerPrefs.GetString("ClickedObjects", "");
            if (!string.IsNullOrEmpty(savedData))
            {
                clickedObjects = new HashSet<string>(savedData.Split(','));
            }
        }
    }
}
