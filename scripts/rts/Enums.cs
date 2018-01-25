using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RTS
{

    public class Job
    {

        public string position;
        public float pay;
        public ResourcePurse Production;
        public Pop worker;
        public Job(string positionname, int paypoint, ResourcePurse produce)
        {
            position = positionname;
            pay = paypoint;
            Production = produce;
            worker = null;
        }
        public bool IsFilled()
        {
            return worker != null ? true : false;
        }
        public void Fill(Pop newworker)
        {
            if (!IsFilled()) {
                worker = newworker;
                newworker.Myjob = this;

            }

        }
    }

    public class Want
    {
        public ResourceEnum type;
        public float wantamount;
        int resamount;
        public float price;
        public float devidor;

        public int usednum = 1;

        public Want(ResourceEnum typee, float wantamountt, float devidorr, float pricee)
        {

            type = typee;
            wantamount = wantamountt;
            devidor = devidorr;
            price = pricee;

        }
        public Want(ResourceEnum typee, float wantamountt, float devidorr)
        {
            type = typee;
            wantamount = wantamountt;
            devidor = devidorr;
            price = 1;
        }
        public float usewant()
        {
            float wantused = wantamount / (devidor*usednum);
            usednum++;
            return wantused;

        }
        public float getvalue()
        {
            return wantamount / (devidor * usednum);

        }
        public void reset()
        {
            usednum = 1;
        }

    }
    public static class TimeKeeper
    {
        public static int gametime = 0;
        public static float TimeDeltasumer = 0;
        public static int gametimedelta = 0;
        public static bool paused = false;

        public static void Timer(UIManager uimanager)
        { 
        TimeDeltasumer += Time.deltaTime;
        if (TimeDeltasumer > 2)
        {
            gametime += 1;
            gametimedelta += 1;
            uimanager.timetext.GetComponent<Text>().text = gametime.ToString()+" "+ Time.deltaTime;
            TimeDeltasumer = 0;
        }
        }
    }


public enum CursorState { Select, Move, Attack, PanLeft, PanRight, PanUp, PanDown, Harvest, RallyPoint }

}
