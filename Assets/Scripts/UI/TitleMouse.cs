using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMouse : MonoBehaviour
{
    //画像
    public Image Mouse_Image;
    //Canvasの変数
    public Canvas canvas;
    //キャンバス内のレクトトランスフォーム
    public RectTransform canvasRect;
    //マウスの位置
    public Vector2 MousePos;

    // Start is called before the first frame update
    private void Start()
    {
        //マウスポインター非表示
        Cursor.visible = true;
        //Cursor.visible = false;

        //HierarchyにあるCanvasオブジェクトを探してcanvasに入れいる
        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //canvas内にあるRectTransformをcanvasRectに入れる
        //canvasRect = canvas.GetComponent<RectTransform>();

        //Canvas内にあるMouseImageを探してMouse_Imageに入れる
        //Mouse_Image = GameObject.Find("MouseImage").GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        //CanvasのRectTransform内にあるマウスの位置をRectTransformのローカルポジションに変換する
        //canvas.worldCameraはカメラ
        //出力先はMousePos
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,
                Input.mousePosition, canvas.worldCamera, out MousePos);

        //Mouse_Imageを表示する位置にMousePosを使う
        Mouse_Image.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(MousePos.x, MousePos.y);
    }

}
