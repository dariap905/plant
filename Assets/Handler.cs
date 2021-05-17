using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{

    // Unity UI References
    public Slider waterSlider;
    public Slider happinessSlider;
    public Slider bugSlider;

    public float waterValue = 100f;
    public float WaterValue
    {
        get
        {
            return waterValue;
        }
        set
        {
            waterValue = value;
            waterSlider.value = waterValue;
        }
    }

    public float happinessValue = 100f;
    public float HappinessValue
    {
        get
        {
            return happinessValue;
        }
        set
        {
            happinessValue = value;
            happinessSlider.value = happinessValue;
        }
    }

    public float bugsValue = 100f;
    public float BugsValue
    {
        get
        {
            return bugsValue;
        }
        set
        {
            bugsValue = value;
            bugSlider.value = bugsValue;
        }
    }

    public float min = 1f;
    public float max = 100f;

    public Button Water;
    public Button Talk;
    public Button Remove;
    public Button Quit;
    public Button Music;

    public bool musicOn;

    public GameObject Cactus;
    public GameObject CactusBugs;

    public GameObject RadioOn;
    public GameObject RadioOff;

    public GameObject bugPrefab;
    public GameObject[] bugs = new GameObject[3];

    public AudioSource bgmusic;

    public bool showbugs = false;


    // Start is called before the first frame update
    void Start()
    {
        Button bt1 = Water.GetComponent<Button>();
        bt1.onClick.AddListener(WaterPlant);

        Button bt2 = Talk.GetComponent<Button>();
        bt2.onClick.AddListener(TalkToPlant);

        Button bt3 = Remove.GetComponent<Button>();
        bt3.onClick.AddListener(RemoveBugs);

        Button bt4 = Quit.GetComponent<Button>();
        bt4.onClick.AddListener(QuitGame);

        Button bt5 = Music.GetComponent<Button>();
        bt5.onClick.AddListener(HandleMusic);

        Cactus.gameObject.SetActive(true);
        CactusBugs.gameObject.SetActive(false);

        RadioOn.gameObject.SetActive(true);
        RadioOff.gameObject.SetActive(false);

        WaterValue = 100f;
        HappinessValue = 100f;
        BugsValue = 80f;

        InstantiateMealybugs();
        HideMealybugs();
        

    }

    private void HandleMusic()
    {
        if (bgmusic.isPlaying)
        {
            bgmusic.Pause();
            RadioOn.gameObject.SetActive(false);
            RadioOff.gameObject.SetActive(true);
        }

        else 
        {
            bgmusic.Play();
            RadioOn.gameObject.SetActive(true);
            RadioOff.gameObject.SetActive(false);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void TalkToPlant()
    {
        HappinessValue += 20;
    }

    private void WaterPlant()
    {
        WaterValue += 30;
    }

    private void RemoveBugs()
    {
        BugsValue -= 10;
    }

    void Update()
    {

        WaterValue -= 0.001f;
        WaterValue = Mathf.Clamp(WaterValue, min, max);

        HappinessValue -= 0.001f;
        HappinessValue = Mathf.Clamp(HappinessValue, min, max);

        BugsValue += 0.001f;
        BugsValue = Mathf.Clamp(BugsValue, min, max);

        NeedsCheck();

    }

    private void NeedsCheck()
    {
        if (BugsValue >= 80)
        {
            showbugs = true;
            Cactus.gameObject.SetActive(false);
            CactusBugs.gameObject.SetActive(true);

        }
        if (BugsValue <= 80 )
        {
            showbugs = false;
            Cactus.gameObject.SetActive(true);
            CactusBugs.gameObject.SetActive(false);
        }

        if (showbugs)
        {
            ShowMealybugs();
        }

        if (!showbugs)
        {
            HideMealybugs();
        }

    }

    private void InstantiateMealybugs()
    {

        float xOffset = -0.5f;

        for (int i = 0; i < bugs.Length; i++)
        {
            
            bugs[i] = Instantiate(bugPrefab, new Vector3(xOffset, 0, 0), Quaternion.identity);
            xOffset += 0.5f;
        }
        
    }

    private float getRandomOffset(){
        return UnityEngine.Random.Range(-1.0f, 1.0f);
    }

    private void ShowMealybugs()
    {
        for(int i = 0; i < bugs.Length; i++){
            bugs[i].gameObject.SetActive(true);
        }

    }

    private void HideMealybugs()
    {
        for(int i = 0; i < bugs.Length; i++){
            bugs[i].gameObject.SetActive(false);
        }

    }
}
