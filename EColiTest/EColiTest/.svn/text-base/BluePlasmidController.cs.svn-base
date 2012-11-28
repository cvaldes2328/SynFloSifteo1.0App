using System;
using System.Collections.Generic;
using System.Text;
using Sifteo;
using Sifteo.Util;

namespace EColiTest
{
    public class BluePlasmidController : IStateController
    {
        String className = "RedPlasmidColor";
        public Cube mCube;
        public EColiTest mApp;
        public String[] blueAnimation;
        public string bluePlasmidImg;
        public int bIndex;

        public BluePlasmidController(EColiTest app)
        {
            //mCube = cube;
            mApp = app;
            blueAnimation = mApp.mBEcoliNames;
            bluePlasmidImg = mApp.mBEcoliNames[0];
            bIndex = 0;
        }

        public void OnSetup(string transitionId)
        {
            Log.Debug("OnSetup Blue");
        }

        public void OnTick(float dt)
        {
            for (int i = 0; i < blueAnimation.Length; i++)
            {
                bIndex++;
                //Log.Debug("EcoliIndex: " + ecoliIndex + " Ecoli Length: " + mApp.mEcoliNames.Length);
                if (bIndex >= blueAnimation.Length)
                {
                    bIndex = 0;
                    break;
                }
                mCube.Image(blueAnimation[bIndex], 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint();
            }
            Log.Debug("BLUE!");
            mApp.sm.AquireLock();
        }

        public void OnDispose()
        {

        }

        public void OnPaint(bool canvasDirty)
        {
            mCube.Image(blueAnimation[bIndex], 0, 0, 0, 0, 128, 128, 1, 0);
            mCube.Paint();
        }
    }
}
