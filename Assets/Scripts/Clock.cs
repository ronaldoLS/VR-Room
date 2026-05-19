using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock Instance { get; private set; }
    [Header("Clock Settings")]
    [SerializeField] private float _time = 0f;
    [Tooltip("Time scale factor. 1 means real-time, 2 means twice as fast, etc.")]
    [SerializeField] private float _timeScale = 10f;
    private float handsRotationOffset = -90f;
    [SerializeField] private int _secunds = 0;
    [SerializeField] private int _minutes = 0;
    [SerializeField] private int _hours = 0;
    [SerializeField] private int _days = 0;




    [Header("Clock Hands")]
    [SerializeField] private GameObject _secundHand;
    [SerializeField] private GameObject _minuteHand;
    [SerializeField] private GameObject _hourHand;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        float secHandRotation = 6f * _secunds;
        float minHandRotation = 6f * _minutes;
        float hourHandRotation = 30f * _hours;
        
        _secundHand.transform.localRotation = Quaternion.Euler(secHandRotation, 0f , 0f);
        _minuteHand.transform.localRotation = Quaternion.Euler(minHandRotation, 0f, 0f);
        _hourHand.transform.localRotation = Quaternion.Euler(hourHandRotation, 0f, 0f);


        _time += Time.deltaTime * _timeScale;
        _secunds = (int)(_time % 60);
        _minutes = (int)((_time / 60) % 60);
        _hours = (int)((_time / 3600) % 24);
        _days = (int)(_time / 86400);
    }
}
