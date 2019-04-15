using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Die : MonoBehaviour
{

    public static string DieOBJ;

    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (DieOBJ)
        {
            case "Car":
                message.text = " 장난감 기차에 부딪혀 넘어졌습니다.";
                break;
            
            case "Mom":
                message.text = " 엄마카드로 몰래 결제한 걸 들켜 혼났습니다.";
                break;
            
            case "SalaryMan":
                message.text = " 출근하느라 바쁜 직장인과 부딪쳐 버렸습니다.";
                break;
            
            case "Digda":
                message.text = " 앗! 야생 디그다가 튀어나왔다.";
                break;
            
            case "Digda (1)":
                message.text = " 앗! 야생 디그다가 튀어나왔다.";
                break;
            
            case "Tomas":
                message.text = " 항상 좌우를 살피고 가셔야죠!";
                break;
            
            case "Killer":
                message.text = " 당신은 킬러조에게 뺑소니를 당했습니다..";
                break;
            
            case "Guardian":
                message.text = " 학생이 말이야! 옷을 단정히 입어야지~!";
                break;
            
            case "Soccor":
                message.text = " 당신은 국대 출신 학생의 마하 3천의 축구공을 몸에 맞았습니다.";
                break;
            
            case "조혜련":
                message.text = " 당신은 태보에 맞았습니다. 30초 안에...";
                break;
            
            case "유투버 1":
                message.text = " 당신은 태보단의 의해 태보를 당했습니다..";
                break;
            
            case "유투버 2":
                message.text = " 당신은 태보단의 의해 태보를 당했습니다..";
                break;
            case "Crab":
                message.text = " 이때를 노렸어!!!!!";
                break;
            case "Npc":
                message.text = " 당신은 공장 담배 냄새로 인해 폐암에 걸렸습니다..";
                break;
            
            case "Ball":
                message.text = " ANG! ANG!";
                break;
            case "Ball(Clone)":
                message.text = " ANG! ANG!";
                break;
            
            default:
                message.text = " ???";
                break;



            
        }
    }
    
    
}
