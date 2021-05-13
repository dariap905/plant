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

    public Boolean musicOn;

    public Text GameOverText;

    public GameObject Cactus;
    public GameObject CactusBugs;


    // Start is called before the first frame update
    void Start()
    {
        Button bt1 = Water.GetComponent<Button>();
        bt1.onClick.AddListener(WaterPlant);

        Button bt2 = Talk.GetComponent<Button>();
        bt1.onClick.AddListener(TalkToPlant);

        Button bt3 = Remove.GetComponent<Button>();
        bt1.onClick.AddListener(RemoveBugs);

        Cactus.gameObject.SetActive(true);
        CactusBugs.gameObject.SetActive(false);
        WaterValue = 100f;
        HappinessValue = 100f;
        BugsValue = 0f;

    }

    private void TalkToPlant()
    {
        throw new NotImplementedException();
    }

    private void WaterPlant()
    {
        throw new NotImplementedException();
    }

    private void RemoveBugs()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

        WaterValue -= 0.01f;
        if(WaterValue < min)
        {
            WaterValue = min;
        }

        HappinessValue -= 0.01f;
        if (HappinessValue < min)
        {
            HappinessValue = min;
        }

        BugsValue += 0.01f;
        if (BugsValue > max)
        {
            BugsValue = max;
        }

        needsCheck();

    }

    private void needsCheck()
    {
        if (BugsValue >= 80)
        {
            Cactus.gameObject.SetActive(false);
            CactusBugs.gameObject.SetActive(true);
        }

    }
}
