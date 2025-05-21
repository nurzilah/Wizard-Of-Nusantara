using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void Back(){
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void Level1(){
        SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
    }

    public void Level2(){
        SceneManager.LoadScene("Level-2", LoadSceneMode.Single);
    }

    public void Level3(){
        SceneManager.LoadScene("Level-3", LoadSceneMode.Single);
    }

    public void Level4(){
        SceneManager.LoadScene("Level-4", LoadSceneMode.Single);
    }

    public void Level5(){
        SceneManager.LoadScene("Level-5", LoadSceneMode.Single);
    }

    public void Level6(){
        SceneManager.LoadScene("Level-6", LoadSceneMode.Single);
    }
    
    public void Level7(){
        SceneManager.LoadScene("Level-7", LoadSceneMode.Single);
    }

    public void Level8(){
        SceneManager.LoadScene("Level-8", LoadSceneMode.Single);
    }

    public void Level9(){
        SceneManager.LoadScene("Level-9", LoadSceneMode.Single);
    }
}
