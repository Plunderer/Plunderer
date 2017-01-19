using UnityEngine; 
using System.Collections;
using UnityEngine.UI;

public class start : MonoBehaviour {
    public GameObject shatta;
    public Text buttontext;
    public Image title;
    public Image fede;
    private Color originalColor;
    float a,b;
    float time;
    bool Fadeout = true;
    public void Buttonpush()
    {
        if (Fadeout)
        {
            StartCoroutine("FadeOut");
            Fadeout = false;
        }
        

    }
    IEnumerator FadeOut()
    {
		AsyncOperation async = Application.LoadLevelAsync("TutorialStage");//シーンのロード
        async.allowSceneActivation = false;//だがまだシーンの移動はしない
        while (a <= 1)//タイトルロゴとスイッチのフェードアウト
        {
            a += 0.1f;
            buttontext.color = new Color(190, 190, 190,1-a);
            title.color = new Color(190, 190, 190, 1 - a);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f); 
        iTween.MoveBy(shatta, iTween.Hash("z", -5, "time", 40.0f));
        yield return new WaitForSeconds(3.5f);
        while (b <= 1)
        {
            b += 0.01f;
            fede.color = new Color(0, 0, 0, 0 + b);
            yield return null;
        }
        async.allowSceneActivation = true;
    }
} 

