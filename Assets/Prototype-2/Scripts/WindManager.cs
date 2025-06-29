using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;

    public float currentWind = 0f;
    public float maxWind = 2f;
    public float windChangeInterval = 5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(ChangeWind), 0f, windChangeInterval);
    }
    void ChangeWind()
    {
        currentWind = Random.Range(-maxWind, maxWind);

    }
}
