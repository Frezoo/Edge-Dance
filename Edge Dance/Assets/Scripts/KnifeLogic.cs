using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnifeLogic : MonoBehaviour
{
    public GameObject Knife;
    private Rigidbody knifeRB;
    private AudioSource knifeAudio;
    private Vector3 forceVector;

    public TextMeshProUGUI ScoreBar;

    public float impulseCooldown = 0.1f;
    private float lastImpulseTime = 0f;
    private bool addKnifeForce = false;
    private float score;

     void Awake()
    {
        knifeAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        Knife = gameObject;
        knifeRB = GetComponent<Rigidbody>();
        forceVector = new Vector3(0, 300, 140) * 1.1f;
        ScoreBar = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            addKnifeForce = true;
            
        }
    }
    private void FixedUpdate()
    {
        if (addKnifeForce)
        {
            AddKnifeForce();
            addKnifeForce = false;
        }

    }

    void AddKnifeForce()
    {
        if (Time.time - lastImpulseTime >= impulseCooldown)
        {
            knifeRB.linearVelocity = new Vector3(0, 0, knifeRB.linearVelocity.z / 20);
            knifeRB.AddForce(forceVector * Time.deltaTime, ForceMode.Impulse);
            knifeRB.AddTorque(1080 * Time.deltaTime, 0, 0);
            lastImpulseTime = Time.time;
            knifeAudio.Play();
        }
    }

    public void UpdateScore(float Value)
    {
        score += Value;
        ScoreBar.text = score.ToString();
    }

}
