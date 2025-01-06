using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel; 
    public Slider VolumeSlider; 
    public AudioSource Music;
    public AudioSource AudioEffect;

    private float currentVolume;
    private const string VolumeKey = "VolumeSettings";
    private bool isPaused = false; 

    void Start()
    {
        AudioEffect = gameObject.GetComponent<Inizializator>().CurrentKnife.GetComponent<AudioSource>();
        pausePanel.SetActive(false);  // Устанавливаем панель паузы в неактивное состояние.
        LoadVolume();
        UpdateVolume();
        
        VolumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); 
        }
    }

    public void OnVolumeChanged(float newVolume)
    {
        currentVolume = newVolume;
        SaveVolume();
        UpdateVolume();
    }
    private void UpdateVolume()
    {
        Music.volume = currentVolume;
        AudioEffect.volume = currentVolume;
    }

    private void LoadVolume()
    {
        currentVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        VolumeSlider.value = currentVolume;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumeKey, currentVolume);
        PlayerPrefs.Save();
    }
   
    public void TogglePause()
    {
        isPaused = !isPaused; 

        if (isPaused)
        {
            PauseGame();
            print(PlayerPrefs.GetFloat("MaxScore"));
        }
        else
        {
            ResumeGame(); 
        }
    }
    // метод для вызова паузы
    public void PauseGame()
    {
        Time.timeScale = 0; 
        pausePanel.SetActive(true);
    }
    // метод для вызова продолжения игры
    public void ResumeGame()
    {
        Time.timeScale = 1; 
        pausePanel.SetActive(false); 
    }
    // метод выхода из игры
    public void QuitGame()
    {
        Debug.Log("Выход из игры!");
        Application.Quit(); // закрывает игру
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    // метод рестарта игры
    public void RestartGame()
    {
        Time.timeScale = 1; // Возобновляем время.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // перезагружаем текущую сцену
    }
}
