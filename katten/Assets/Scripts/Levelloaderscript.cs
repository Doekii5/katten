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
    public TextMeshProUGUI daycounter;
    public Image bgmain;
    public Image bgwalk;
    public Image Stats;
    public RawImage map;

    public WalkTracker walkTracker;


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
        bgmain.gameObject.SetActive(true);
        bgwalk.gameObject.SetActive(false);
        Stats.gameObject.SetActive(false);
        map.gameObject.SetActive(false);

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
        bgmain.gameObject.SetActive(false);
        bgwalk.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        map.gameObject.SetActive(true);

        transition.SetTrigger("open");
    }
}
