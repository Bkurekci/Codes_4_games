using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource menuSounds;
    [SerializeField] AudioClip crunch;
   public void PlayAgain()
    {
        StartCoroutine(GameScene(1));//I don't want my sounds suddenly stop so that's why I use IEnumerators(wait for the sound)
    }

    public void GoToMenu()
    {
        StartCoroutine(GameScene(0));
    }

    public void Exit()
    {
        StartCoroutine(ExitApp());
    }

    IEnumerator GameScene(int index)
    {
        menuSounds.PlayOneShot(crunch);
        yield return new WaitForSeconds(0.4f);//wait for the sound
        SceneManager.LoadScene(index);//and go to indexed scene(I didn't wanna separate them like game scene, menu scene so I used indexes)
    }
    IEnumerator ExitApp()
    {
        menuSounds.PlayOneShot(crunch);
        yield return new WaitForSeconds(0.4f);
        Application.Quit();
    }
}
