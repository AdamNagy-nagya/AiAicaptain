
using UnityEngine;
using UnityEngine.SceneManagement;

class SceneRouter : ISceneRouter
{
  
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void exitApplication()
    {
        Application.Quit();
    }

    public void loadFirstMap()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMapNumber(int mapNumber)
    {
        SceneManager.LoadScene(mapNumber);
    }

    public void loadRandomMap()
    {
        SceneManager.LoadScene(2);
    }
}