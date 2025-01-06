using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KnifeLogic : MonoBehaviour
{
    public GameObject Knife;
    private Rigidbody knifeRB;
    private AudioSource knifeAudio;
    private Vector3 forceVector;

    public TextMeshProUGUI ScoreBar;

    public float impulseCooldown = 0.1f;
    public float shortImpulseCooldown;
    private float lastImpulseTime = 0f;
    private float lastHalfImpulseTime = 0f;

    private bool addKnifeForce = false;
    private bool addHalfKnifeForce = false;
    private float score;

    public float TorqueCoef;

    public Color ReadyColor;
    public Color ReloadColor;
    public Image ColdownImage;

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
        ColdownImage = GameObject.Find("ColDown").GetComponent<Image>();
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            addKnifeForce = true;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            addHalfKnifeForce = true;
        }
        ColdownImage.fillAmount = Mathf.Clamp((Time.time - lastHalfImpulseTime) / shortImpulseCooldown, 0, 1);
        ColdownImage.color = ColdownImage.fillAmount == 1 ? ReadyColor : ReloadColor;
    }
    private void FixedUpdate()
    {
        if (addKnifeForce)
        {
            AddKnifeForce();
            addKnifeForce = false;
        }
        if (addHalfKnifeForce)
        {
            AddHalfKnifeForce();
            addHalfKnifeForce= false;
        }


    }

    void AddKnifeForce()
    {
        if (Time.time - lastImpulseTime >= impulseCooldown)
        {
            knifeRB.linearVelocity = new Vector3(0, 0, knifeRB.linearVelocity.z / 20);
            knifeRB.AddForce(forceVector * Time.deltaTime, ForceMode.Impulse);
            knifeRB.AddTorque(1080 * Time.deltaTime * TorqueCoef, 0, 0);
            lastImpulseTime = Time.time;
            knifeAudio.Play();
        }
    }
    void AddHalfKnifeForce()
    {
        if (Time.time - lastHalfImpulseTime >= shortImpulseCooldown)
        {
            knifeRB.linearVelocity = new Vector3(0, 0, knifeRB.linearVelocity.z / 20);
            knifeRB.AddForce(forceVector / 1.5f * Time.deltaTime, ForceMode.Impulse);
            knifeRB.AddTorque(1080 * Time.deltaTime * TorqueCoef, 0, 0);
            lastHalfImpulseTime = Time.time;
            knifeAudio.Play();
        }
    }


    public void UpdateScore(float Value)
    {
        score += Value;
        ScoreBar.text = score.ToString();
    }
    public void MultiplyeScore(float Value)
    {
        score *= Value;
        UpdateScore(0);
    }
    public float GetScore()
    {
        return score;
    }
}
