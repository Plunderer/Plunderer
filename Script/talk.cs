using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class talk : MonoBehaviour {
    public GameObject talkevent;
    public PlayerController pl;
    public string[] scenarios;
    public string[] scenariosname;
    [SerializeField]
    Text uiText;
    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;
    public bool talkon =false;
    private string currentText = string.Empty;
    private string currentname = string.Empty;
    private float timeUntilDisplay = 0;
    private float timeElapsed = 1;
    public int currentLine = 0;
    private int lastUpdateCharacter = -1;
    public Text nameText;
    public Image fede;
    void Awake(){
        pl = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    void Update()
    {
        if(talkon){
            // 文字の表示が完了してるならクリック時に次の行を表示する
            if (IsCompleteDisplayText)
            {
                if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0)){
                    SetNextLine();
                }
                else if (currentLine >= scenarios.Length && Input.GetMouseButtonDown(0)){
                    close();
                }
            }
            else
            {
                // 完了してないなら文字をすべて表示する
                if (Input.GetMouseButtonDown(0))
                {
                    timeUntilDisplay = 0;
                }
            }

            int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
            if (displayCharacterCount != lastUpdateCharacter)
            {
                uiText.text = currentText.Substring(0, displayCharacterCount);
                nameText.text = currentname;
                lastUpdateCharacter = displayCharacterCount;
            }
        }
    }


    void SetNextLine()
    {
        currentText = scenarios[currentLine];
        currentname = scenariosname[currentLine];
        if (currentText == "tutorialend") { StartCoroutine("tutolialend"); }
        else
        {
            timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
            timeElapsed = Time.time;
            currentLine++;
            lastUpdateCharacter = -1;
        }
    }

    void close() {
        if (GetComponent<tutolial>() != null) GetComponent<tutolial>().talkbool = true;
        pl.stop = false;
        talkevent.SetActive(false);
        Destroy(this);
    }

    public void talkstart(){
        currentLine = 0;
        pl.stop = true;
        talkevent.SetActive(true);
        talkon = true;
        SetNextLine();
    }
    IEnumerator tutolialend()
    {
        float a = 0;
        while (a <= 1)//開始時の暗転
        {
            a += 0.01f;
            fede.color = new Color(0, 0, 0, 0 + a);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("title");
    }
}