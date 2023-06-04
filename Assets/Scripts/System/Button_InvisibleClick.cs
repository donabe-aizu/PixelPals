
using UnityEngine;
using UnityEngine.UI;

public class Button_InvisibleClick : MonoBehaviour
{
    //�}�E�X����̃I�u�W�F�N�g�i�摜�j
    public Transform mouseObject;
    private Vector2 mousePos;

    //Canvas�̕ϐ�
    public Canvas canvas;
    //�L�����o�X���̃��N�g�g�����X�t�H�[��
    public RectTransform canvasRect;

    //�{�^���̌`�����W
    private RectTransform body_;
    private Rect body;
    private Vector2 position;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        //mousePos = mouseObject.position;

        body_ = this.GetComponent<RectTransform>();
        body = body_.rect;
        position = body_.position;

        //�L�����o�X�����W�ɕϊ��i�}�E�X���̍��W�ƍ��킹��j
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,
                body_.position, canvas.worldCamera, out position);

        button = this.GetComponent<Button>();
    }

    bool IsInvisibleHover()
    {
        return
            (body.height + position.y) > mousePos.y && mousePos.y > position.y
            && (body.width + position.x) > mousePos.x && mousePos.x > position.x;
    }

    void SelfDebug()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Debug:mouse X:" + mousePos.x + "Y:" + mousePos.y);
            Debug.Log("Debug:body X:" + position.x + "   Y:" + position.y);
            Debug.Log("Debug:body W:" + body.width + "   H:" + body.height);
            Debug.Log("Debug:" + (body.width + position.x) + "> X >" + position.x);
            Debug.Log("Debug:" + (body.height + position.y) + "> Y >" + position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,
                mouseObject.position, canvas.worldCamera, out mousePos);

        // �{�^�����N���b�N���ꂽ���ǂ��������o����
        if (Input.GetMouseButtonDown(0)&& IsInvisibleHover())
        {
            //Debug.Log("Debug:ChangeScene!");
            //this.GetComponent<Button>().onClick.Invoke();
            button.onClick.Invoke();
        }

        //SelfDebug();
    }
}
