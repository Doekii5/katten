using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelloaderscript : MonoBehaviour
{

    public Animator transition;
    public Button settings;
    public Button stats;
    public Button shop;
    public Button inventory;
    public Button walk;
    public Button quit;
    public Button quests;
    public Button settingswalk;
    public Button questswalk;
    public Button dayforward;
    public Image[] buttons;
    public TextMeshProUGUI daycounter;
    public Image Stats;
    public RawImage map;
    public Animator bg;
    public Animator catspr;
    public GameObject bone;

    public WalkTracker walkTracker;
    public FORWARDDAY forwardday;
    public MusicVolumeUI muziek;
    public float timesWalked;

    Color color1 = new Color32(36, 197, 29, 255);
    Color color2 = new Color32(155, 226, 20, 255);
    Color color3 = new Color32(229, 200, 18, 255);
    Color color4 = new Color32(229, 137, 18, 255);
    Color color5 = new Color32(179, 58, 41, 255);

    public float transitionTime = 1.0f;
    public void mainmenu()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(loadmain(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void walkmenu()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(loadwalk(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadmain(int levelIndex)
    {
        transition.SetTrigger("close");
        walkTracker.StopWalk();

        ++timesWalked;

        yield return new WaitForSeconds(transitionTime);

        quit.gameObject.SetActive(false);
        settingswalk.gameObject.SetActive(false);
        questswalk.gameObject.SetActive(false);
        stats.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        quests.gameObject.SetActive(true);
        walk.gameObject.SetActive(true);
        daycounter.gameObject.SetActive(true);
        dayforward.gameObject.SetActive(true);
        Stats.gameObject.SetActive(false);
        map.gameObject.SetActive(false);

        StageChange(forwardday.stage);

        transition.SetTrigger("open");
    }

    IEnumerator loadwalk(int levelIndex)
    {
        transition.SetTrigger("close");
        walkTracker.StartWalk();

        yield return new WaitForSeconds(transitionTime);

        quit.gameObject.SetActive(true);
        settingswalk.gameObject.SetActive(true);
        questswalk.gameObject.SetActive(true);
        stats.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        quests.gameObject.SetActive(false);
        walk.gameObject.SetActive(false);
        daycounter.gameObject.SetActive(false);
        dayforward.gameObject.SetActive(false);
        Stats.gameObject.SetActive(true);
        map.gameObject.SetActive(true);

        bg.SetTrigger("walkbg");
        transition.SetTrigger("open");
    }

    public void StageChange(float stage)
    {
        if (stage == 1)
        {
            catspr.SetTrigger("cat1");
            bone.SetActive(false);
            bg.SetTrigger("bganim");
            muziek.back();
            foreach (Image btn in buttons)
            {
                btn.color = color1;
            }
        }
        if (stage == 2)
        {
            catspr.SetTrigger("cat2");
            bg.SetTrigger("bg2");
            foreach (Image btn in buttons)
            {
                btn.color = color2;
            }
        }
        if (stage == 3)
        {
            catspr.SetTrigger("cat3");
            bg.SetTrigger("bg3");
            foreach (Image btn in buttons)
            {
                btn.color = color3;
            }
        }
        if (stage == 4)
        {
            catspr.SetTrigger("cat4");
            bg.SetTrigger("bg4");
            foreach (Image btn in buttons)
            {
                btn.color = color4;
            }
        }
        if (stage == 5)
        {
            catspr.SetTrigger("cat5");
            bone.SetActive(true);
            muziek.scary();
            foreach (Image btn in buttons)
            {
                btn.color = color5;
            }
        }
    }
}
