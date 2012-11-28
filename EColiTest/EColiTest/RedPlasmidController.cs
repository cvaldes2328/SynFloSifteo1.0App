using System;
using System.Collections.Generic;
using System.Text;
using Sifteo;
using Sifteo.Util;

namespace EColiTest
{
    public class RedPlasmidController : IStateController
    {
        String className = "RedPlasmidColor";
        public Cube mCube;
        public EColiTest mApp;
        public String[] redAnimation;
        public string redPlasmidImg;
        public int rIndex;

        public RedPlasmidController(EColiTest app)
        {
            //mCube = cube;
            mApp = app;
            redAnimation = mApp.mREcoliNames;
            redPlasmidImg = mApp.mREcoliNames[0];
            rIndex = 0;
        }

        public void OnSetup(string transitionId)
        {
            Log.Debug("OnSetup Red");
        }

        public void OnTick(float dt)
        {
            for (int i = 0; i < redAnimation.Length; i++)
            {
                rIndex++;
                //Log.Debug("EcoliIndex: " + ecoliIndex + " Ecoli Length: " + mApp.mEcoliNames.Length);
                if (rIndex >= redAnimation.Length)
                {
                    rIndex = 0;
                    break;
                }
                mCube.Image(redAnimation[rIndex], 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint();
            }
            Log.Debug("RED!");
            mApp.sm.AquireLock();
        }

        public void OnDispose()
        {

        }

        public void OnPaint(bool canvasDirty)
        {
            mCube.Image(redAnimation[rIndex], 0, 0, 0, 0, 128, 128, 1, 0);
            mCube.Paint();
        }
    }
}
