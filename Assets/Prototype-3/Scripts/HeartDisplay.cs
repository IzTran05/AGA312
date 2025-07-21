using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    public GameObject heartPrefab;
    public int spacing = 5;

    private List<GameObject> hearts = new List<GameObject>();

    public void UpdateHearts(int currentHealth)
    {
        // Clear existing
        foreach (var h in hearts)
            Destroy(h);
        hearts.Clear();

        // Add hearts equal to health
        for (int i = 0; i < currentHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform);
            RectTransform rt = heart.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * (rt.sizeDelta.x + spacing), 0);
            hearts.Add(heart);
        }
    }
}
