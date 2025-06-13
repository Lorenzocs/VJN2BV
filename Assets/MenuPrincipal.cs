using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject imagenAAgrandar;
    public CanvasGroup menuPrincipal;
    public CanvasGroup instrucciones;
    void Start()
    {
        DOTween.Init();

    }


    // Update is called once per frame
    void Update()
    {
 
    }

    public void GoToInstructions()
    {
        menuPrincipal.gameObject.transform.DOScale(0, 2f).
            OnComplete(()=>menuPrincipal.gameObject.SetActive(false)).
            SetEase(Ease.OutBounce);
        instrucciones.gameObject.SetActive(true);
        instrucciones.DOFade(1, 1f).SetDelay(2f);
    }

    public void GoToMenu()
    {

    }



    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
