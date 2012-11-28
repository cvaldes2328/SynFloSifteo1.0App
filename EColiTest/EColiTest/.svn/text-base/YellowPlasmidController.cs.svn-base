using System;
using System.Collections.Generic;
using System.Text;
using Sifteo;
using Sifteo.Util;

namespace EColiTest
{
    public class YellowPlasmidController : IStateController
    {
        String className = "YellowPlasmidController";
        public Cube mCube;
        public EColiTest mApp;
        public String[] yellowAnimation;
        public string yellowPlasmidImg;
        public int yIndex;

        public YellowPlasmidController(EColiTest app)
        {
            //mCube = cube;
            mApp = app;
            yellowAnimation = mApp.mYEcoliNames;
            yellowPlasmidImg = mApp.mYEcoliNames[0];
            yIndex = 0;
        }

        public void OnSetup(string transitionId)
        {
            Log.Debug("OnSetup Yellow");
        }

        public void OnTick(float dt)
        {
            for (int i = 0; i < yellowAnimation.Length; i++)
            {
                yIndex++;
                //Log.Debug("EcoliIndex: " + ecoliIndex + " Ecoli Length: " + mApp.mEcoliNames.Length);
                if (yIndex >= yellowAnimation.Length)
                {
                    yIndex = 0;
                    break;
                }
                mCube.Image(yellowAnimation[yIndex], 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint();
            }
            //Log.Debug("YELLOW1!");
            mApp.sm.AquireLock();
        }

        public void OnDispose()
        {

        }

        public void OnPaint(bool canvasDirty)
        {
            mCube.Image(yellowAnimation[yIndex], 0, 0, 0, 0, 128, 128, 1, 0);
            mCube.Paint();
        }
    }
}
