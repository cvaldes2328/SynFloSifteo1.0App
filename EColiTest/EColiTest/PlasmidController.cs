using System;
using System.Collections.Generic;
using Sifteo;
using Sifteo.Util;
using System.Text;

namespace EColiTest
{
    public class PlasmidController : IStateController
    {
        String className = "WhitePlasmidController";
        public Cube mCube;
        public EColiTest mApp;
        public String[] whiteAnimation;
        public string whitePlasmidImg;
        public int wIndex;

        public PlasmidController(EColiTest app)
        {
            //mCube = cube;
            mApp = app;
            whiteAnimation = mApp.mEcoliNames;
            whitePlasmidImg = mApp.mEcoliNames[0];
            wIndex = 0;
        }

        public void OnSetup(string transitionId)
        {
            Log.Debug("OnSetup White");
        }

        public void OnTick(float dt)
        {
            for (int i = 0; i < whiteAnimation.Length; i++)
            {
                wIndex++;
                //Log.Debug("EcoliIndex: " + ecoliIndex + " Ecoli Length: " + mApp.mEcoliNames.Length);
                if (wIndex >= whiteAnimation.Length)
                {
                    wIndex = 0;
                    break;
                }
                OnPaint(true);
            }
        }

        public void OnDispose()
        {

        }

        public void OnPaint(bool canvasDirty){
            mCube.Image(whiteAnimation[wIndex], 0, 0, 0, 0, 128, 128, 1, 0);
            mCube.Paint();
        }
    }
}
