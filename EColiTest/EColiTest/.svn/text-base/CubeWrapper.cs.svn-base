using System;
using System.Collections;
using System.Collections.Generic;
using Sifteo;
using Sifteo.Util;

namespace EColiTest
{
    public class CubeWrapper
    {
        #region Instance Variables
        public EColiTest mApp;

        //All Neighbors involved
        public Cube mCube;
        public Cube bCube;
        public Cube lCube;
        public Cube rCube;

        //All Cube (Neighbor) Wrappers involved
        public CubeWrapper bCubeWrapper;
        public CubeWrapper lCubeWrapper;
        public CubeWrapper rCubeWrapper;

        //All Cubes in cube set Involved
        public string cCubeStringId = ""; //Colored Cube
        public string pCubeStringId = ""; //Plasmid Cube
        public string eCubeStringId = ""; //E. Coli Cube

        //All Cube Wrappers Involved
        public CubeWrapper cCubeWrapper; //Colored
        public CubeWrapper pCubeWrapper; //Plasmid
        public CubeWrapper eCubeWrapper; //E. Coli

        //All Indices that keep track of elt of images array
        public int mIndex = 0;
        //public int tIndex = 0;
        public int bIndex = 0;
        //public int lIndex = 0;
        //public int rIndex = 0;
        public int eColiIndex = 0;
        public int colorIndex = 0;
        public int travelIndex = 0;
        
        //To determine the type of cube
        public int mCubeType = 0;

        //All strings for color
        public string color;
        public string eColiColor;
        public string plasmidColor;

        //(Booleans) Flags that tell wrapper to redraw current images on cube
        public bool mNeedDraw = false; //If true, draws Colored cube
        public bool mNeedDrawDrip = false; //If true, starts dripping animation
        public bool mNeedTilt = false; //If true, starts dripping animation
        public bool mEcoli = false; //If true, starts E. Coli animation
        public bool mNeedFlip = false; //If true, changes E. Coli color
        public bool mEcoliTravel = false;

        //Extra stuff
        public int mXOffset = 0; //EXTRA
        public int mYOffset = 0; //EXTRA
        public int mScale = 1; //EXTRA
        public int mRotation = 0; //EXTRA

        //For communication with surface
        public string tagVal;
        public bool isFlipped = false;

        #endregion

        #region Constructor
        public CubeWrapper(EColiTest app, Cube cube)
        {
            mApp = app;
            mCube = cube;
            mCube.userData = this; 

            //Ensures that whatever color first appears on the cube is the color instance variable
            if (mCubeType == 0)
            {
                if (mApp.mImageNames[colorIndex].Contains("red")) this.color = "red";
                if (mApp.mImageNames[colorIndex].Contains("blue")) this.color = "blue";
                if (mApp.mImageNames[colorIndex].Contains("yellow")) this.color = "yellow";
            }

            mApp.whitePlasmidController.mCube = this.mCube;
            
            eColiColor = "white";
            plasmidColor = "white";

            //Adding the event handlers
            mCube.ButtonEvent += OnButton;
            mCube.TiltEvent += OnTilt;
            mCube.FlipEvent += OnFlip;

        }

        #endregion

        #region Button Event Handler
        /// <summary>
        /// Button Event Handler
        /// Colored Cube: the image changes each time
        /// E. Coli Cube: the animation runs
        /// </summary>
        /// <param name="cube">Cube event occurs on</param>
        /// <param name="pressed">True if Cube has been pressed on</param>
        private void OnButton(Cube cube, bool pressed)
        {
            Log.Debug("mCubeType: " + mCubeType);
            if (pressed)
            {
                //Log.Debug("Button pressed");
                //Log.Debug("Cube type: " + this.mCubeType);
                //Log.Debug("Color Index: " + colorIndex);
                //Log.Debug("Plasmid Name: " + plasmidName);
                //Log.Debug("Plasmid Color: " + plasmidColor);
                //Log.Debug("eColi Color: " + eColiColor);
                //Log.Debug("mNeedTilt? " + mNeedTilt.ToString());
                Log.Debug("lCube: " + (lCube == null));

                #region Check order of images
                //for (int i = 0; i < mApp.mDripNames.Length; i++)
                //{
                //    Log.Debug("Red Img Name: " + mApp.mDripNames[i]);
                //    if (i < mApp.mPdripNames.Length)
                //    {
                //        Log.Debug("Red PImg Name: " + mApp.mPdripNames[i]);
                //    }
                //}

                //for (int i = 0; i < mApp.mDripNames.Length; i++)
                //{
                //    Log.Debug("Yellow Img Name: " + mApp.mYDripNames[i]);
                //    if (i < mApp.mYPdripNames.Length)
                //    {
                //        Log.Debug("Yellow PImg Name: " + mApp.mYPdripNames[i]);
                //    }
                //}

                //for (int i = 0; i < mApp.mDripNames.Length; i++)
                //{
                //    Log.Debug("Blue Img Name: " + mApp.mBDripNames[i]);
                //    if (i < mApp.mBPdripNames.Length)
                //    {
                //        Log.Debug("Blue PImg Name: " + mApp.mBPdripNames[i]);
                //    }
                //}
                #endregion
            }
            else
            {
                Log.Debug("Button released");

                //If the Colored Cube is clicked on...
                if (mCubeType == 0)
                {
                    //Runs the animation...
                    this.colorIndex += 1;
                    if (colorIndex >= mApp.mImageNames.Length)
                    {
                        colorIndex = 0;
                    }

                    #region EXTRA STUFF
                    /*
                    //if mCube has a bottom neighbor
                    if (bCube != null)
                    {
                        //Identifies whether or not the bCube is of type 1, i.e. a Plasmid Cube
                        string bCubeId = bCube.UniqueId;
                        foreach (CubeWrapper w in mApp.mWrappers)
                        {
                            if (bCubeId == w.mCube.UniqueId && w.mCubeType == 1)
                            {
                                //used plasmidName instead of "plasmid" to make sure that if the dripping
                                //animation for a particular color has been compeleted, then the plasmid
                                //cube still has the correct color -- !! actually, I don't need this.
                                bCube.Image(plasmidName, mXOffset, mYOffset, 0, 0, 128, 128, mScale, mRotation);
                                bCube.Paint();
                                break;    
                            }
                        }
                        
                    }
                    */
                    #endregion

                    //Because the color has changed, updates the color instance variable
                    if (mApp.mImageNames[cCubeWrapper.colorIndex].Contains("red")) this.color = "red";
                    if (mApp.mImageNames[cCubeWrapper.colorIndex].Contains("blue")) this.color = "blue";
                    if (mApp.mImageNames[cCubeWrapper.colorIndex].Contains("yellow")) this.color = "yellow";
                }

            }

            mRotation = 0; //EXTRA
            mScale = 1; //EXTRA
            if (mCubeType == 0) DrawColoredCube();
            if (mCubeType == 1) DrawPlasmidCube();
            if (mCubeType == 2)
            {
                if (eCubeWrapper.eColiColor == "white")
                {
                    mApp.whitePlasmidController.mCube = this.mCube;
                    mApp.whitePlasmidController.OnTick(1);
                }

                if (eCubeWrapper.eColiColor == "yellow")
                {
                    mApp.yellowPlasmidController.mCube = this.mCube;
                    mApp.yellowPlasmidController.OnTick(1);
                }

                if (eCubeWrapper.eColiColor == "red")
                {
                    mApp.redPlasmidController.mCube = this.mCube;
                    mApp.redPlasmidController.OnTick(1);
                }

                if (eCubeWrapper.eColiColor == "blue")
                {
                    mApp.bluePlasmidController.mCube = this.mCube;
                    mApp.bluePlasmidController.OnTick(1);
                }                
            }          
        }

        #endregion

        #region Tilt Event Handler
        /// <summary>
        /// If the cube is neighboring another cube, advance through the drip names index 
        /// and raise the mNeedDrawDrip flag. The mNeedDrawDrip flag tells the cubes to draw 
        /// the drip animation (see bottom).
        /// </summary>
        /// <param name="cube">Cube that is being tilted</param>
        /// <param name="tiltX"></param>
        /// <param name="tiltY"></param>
        /// <param name="tiltZ"></param>
        private void OnTilt(Cube cube, int tiltX, int tiltY, int tiltZ)
        {
            Log.Debug("On Tilt method");
            if (mNeedTilt)
            {
                Log.Debug("In mNeedTilt");
                if (bCube != null)
                {
                    if ((tiltY == 0 && mCubeType == 0) && bCubeWrapper.mCubeType == 1)
                    {
                        
                        #region TEST

                        this.mIndex += 1;
                        this.bIndex += 1;
                        //Log.Debug("mPdripNames.Length: " + mApp.mPdripNames.Length);
                        //Log.Debug("bIndex: " + bIndex);
                        //Log.Debug("2 Color: " + this.color + "; Color index: " + colorIndex);

                        //Log.Debug("In mNeedDrawDrip");
                        mNeedDrawDrip = true;

                        if (this.color == "red")
                        {
                            if (mIndex >= mApp.mDripNames.Length) mIndex = 0;
                            if (bIndex >= mApp.mPdripNames.Length)
                            {
                                //Log.Debug("DONE!");
                                //plasmidName = mApp.mPdripNames[mApp.mPdripNames.Length - 1];
                                bIndex = 0;
                                mNeedDrawDrip = false;
                                mApp.OnNeighborRemove(mCube, Cube.Side.BOTTOM, bCube, Cube.Side.TOP);
                                mIndex = 0;
                                if (mCubeType == 0)
                                {
                                    mCube.Image("red color", 0, 0, 0, 0, 128, 128, 1, 0);
                                    mCube.Paint();
                                }
                            }
                            pCubeWrapper.plasmidColor = "red";
                            if (eCubeWrapper != null) eCubeWrapper.plasmidColor = "red";
                            if (cCubeWrapper != null) cCubeWrapper.plasmidColor = "red";
                        }//end of blue if block

                        if (this.color == "yellow")
                        {
                            if (mIndex >= mApp.mYDripNames.Length) mIndex = 0;
                            if (bIndex >= mApp.mYPdripNames.Length)
                            {
                                //plasmidName = mApp.mYPdripNames[mApp.mYPdripNames.Length - 1];
                                bIndex = 0;
                                mNeedDrawDrip = false;
                                mApp.OnNeighborRemove(mCube, Cube.Side.BOTTOM, bCube, Cube.Side.TOP);
                                mIndex = 0;
                                if (mCubeType == 0)
                                {
                                    mCube.Image("yellow color", 0, 0, 0, 0, 128, 128, 1, 0);
                                    mCube.Paint();
                                }
                                
                            }
                            pCubeWrapper.plasmidColor = "yellow";
                            if (eCubeWrapper != null) eCubeWrapper.plasmidColor = "yellow";
                            if (cCubeWrapper != null) cCubeWrapper.plasmidColor = "yellow";

                        }//end of yellow if block

                        if (this.color == "blue")
                        {
                            if (mIndex >= mApp.mBDripNames.Length) mIndex = 0;
                            if (bIndex >= mApp.mBPdripNames.Length)
                            {
                                //plasmidName = mApp.mBPdripNames[mApp.mBPdripNames.Length - 1];
                                bIndex = 0;
                                mNeedDrawDrip = false;
                                mApp.OnNeighborRemove(mCube, Cube.Side.BOTTOM, bCube, Cube.Side.TOP);
                                mIndex = 0;
                                if (mCubeType == 0)
                                {
                                    mCube.Image("blue color", 0, 0, 0, 0, 128, 128, 1, 0);
                                    mCube.Paint();
                                }
                                
                            }
                            pCubeWrapper.plasmidColor = "blue";
                            if (eCubeWrapper != null) eCubeWrapper.plasmidColor = "blue";
                            if (cCubeWrapper != null) cCubeWrapper.plasmidColor = "blue";
                        }//end of blue if block
                        
                        #endregion
                    }//end of if block that checks for whether cubes interacting are the correct ones
                }//checks if bottom neighbor of mCube is null or not
            }//end of mNeedTilt

        }

        #endregion

        #region Flip Event Handler
        /// <summary>
        /// Flip Functionality -- If the Colored Cube is to the left/right of the E. Coli Cube then
        /// flipping the colored cube changes the color of the E. Coli cube to whatever the color
        /// of the colored cube is
        /// </summary>
        /// <param name="c"></param>
        /// <param name="newOrientationIsUp"></param>
        private void OnFlip(Cube c, bool newOrientationIsUp)
        {
            if (newOrientationIsUp)
            {
                isFlipped = false;
                Log.Debug("Face Up");
            }
            else //screen is facing ground
            {
                isFlipped = true;
                Log.Debug("FLIPPED! " + eColiColor);
                if (tagVal == null)
                {
                    mApp._client.ReceiveTag();
                    if (mApp._client.tagValue != "")
                    {
                        tagVal = mApp._client.tagValue;
                        Log.Debug("Cube (" + mCube.UniqueId + ") is assigned tag value: " + tagVal);
                    }
                    mApp._client.tagValue = ""; //resets tagValue in Client class
                }

                if (mApp.allHasTag)
                {
                    mApp._client.ReceiveTag();
                    string tag = mApp._client.tagValue;

                    foreach (CubeWrapper w in mApp.mWrappers)
                    {
                        Log.Debug("Tag: " + tag + " vs the wrapper: " + w.tagVal);
                        if (tag == w.tagVal && w.mCubeType == 2)
                        {
                            mApp._client.SendPhoto(w.eColiColor);
                        }
                    }

                }
                if (mNeedFlip)
                {
                    
                    Log.Debug("Face Down");
                    if (pCubeWrapper.plasmidColor == "yellow")
                    {
                         Log.Debug("YELLOW!!");
                         
                         //mApp.sm.QueueTransition("Yellow");
                         mApp.sm.SetState("Yellow", EColiTest.tWhiteToYellow);
                         mApp.yellowPlasmidController.mCube = this.eCubeWrapper.mCube;
                         mApp.sm.CurrentState.OnTick(1);
                         //mApp._client.SendPhoto("Yellow");
                         eCubeWrapper.eColiColor = "yellow";
                         if (pCubeWrapper != null) pCubeWrapper.eColiColor = "yellow";
                         if (cCubeWrapper != null) cCubeWrapper.eColiColor = "yellow";
                    }

                    //if (mApp.mImageNames[cCubeWrapper.colorIndex].Contains("red"))
                    if (pCubeWrapper.plasmidColor == "red")
                    {
                        Log.Debug("RED!!");
                        //mApp.sm.QueueTransition("Yellow");
                        mApp.sm.SetState("Red", EColiTest.tWhiteToRed);
                        mApp.redPlasmidController.mCube = this.eCubeWrapper.mCube;
                        mApp.sm.CurrentState.OnTick(1);
                        //mApp._client.SendPhoto("Red");
                        eCubeWrapper.eColiColor = "red";
                        if (pCubeWrapper != null) pCubeWrapper.eColiColor = "red";
                        if (cCubeWrapper != null) cCubeWrapper.eColiColor = "red";
                    }

                    //if (mApp.mImageNames[cCubeWrapper.colorIndex].Contains("blue"))
                    if (pCubeWrapper.plasmidColor == "blue") 
                    {
                        Log.Debug("BLUE!!");
                        //mApp.sm.QueueTransition("Yellow");
                        mApp.sm.SetState("Blue", EColiTest.tWhiteToBlue);
                        mApp.bluePlasmidController.mCube = this.eCubeWrapper.mCube;
                        mApp.sm.CurrentState.OnTick(1);
                        //mApp._client.SendPhoto("Blue");
                        eCubeWrapper.eColiColor = "blue";
                        if (pCubeWrapper != null) pCubeWrapper.eColiColor = "blue";
                        if (cCubeWrapper != null) cCubeWrapper.eColiColor = "blue"; 
                    }

                    Log.Debug("Current [now] State: " + mApp.sm.CurrentState);
                    
                }
                    
            }

        }
        #endregion

        #region Draws Plasmid Cube
        public void DrawPlasmidCube()
        {
            #region Extra Info (screenX, screenY, imageX, imageY, scale, rotation)
            // You can specify the top/left point on the screen to start drawing at.
            int screenX = mXOffset;
            int screenY = mYOffset;

            // You can draw a portion of an image by specifying coordinates to start
            // reading from (top/left). In this case, we're just going to draw the
            // whole image every time.
            int imageX = 0;
            int imageY = 0;

            // You should always specify the width and height of the image to be
            // drawn. If you specify values that are less than the size of the image,
            // only the portion you specify will be drawn. If you specify values
            // larger than the image, the behavior is undefined (so don't do that).
            //
            // In this example, we assume that the image is 128x128, big enough to
            // cover the full size of the display. If the image runs off the sides of
            // the display (because of offsets due to tilting; see OnTilt, above), it
            // will be clipped.
            int width = 128;
            int height = 128;

            // You can upscale an image by integer multiples. A scaled image still
            // starts drawing at the specified top/left point, but the area of the
            // display it covers (width/height) will be multipled by the scale.
            //
            // The default value is 1 (1:1 scale).
            int scale = mScale;

            // You can rotate an image by quarters. The rotation value is an integer
            // representing counterclockwise rotation.
            //
            // * 0 = no rotation
            // * 1 = 90 degrees counterclockwise
            // * 2 = 180 degrees
            // * 3 = 90 degrees clockwise
            //
            // A rotated image still starts drawing at the specified top/left point;
            // the pixels are just drawn in rotated order.
            //
            // The default value is 0 (no rotation).
            int rotation = mRotation;
            #endregion

            if (mCubeType == 1)
            {
                if (pCubeWrapper.plasmidColor == "white")
                {
                    mCube.Image("plasmid", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                    mCube.Paint();
                }

                if (pCubeWrapper.plasmidColor == "blue")
                {
                    mCube.Image("b Pdrip 16", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                    mCube.Paint();
                }

                if (pCubeWrapper.plasmidColor == "red")
                {
                    mCube.Image("r Pdrip 16", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                    mCube.Paint();
                }

                if (pCubeWrapper.plasmidColor == "yellow")
                {
                    mCube.Image("y Pdrip 16", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                    mCube.Paint();
                }
            }
            
        }

        #endregion

        #region Draws E. Coli Cube
        public void DrawEcoliCube()
        {
            #region Extra Info (screenX, screenY, imageX, imageY, scale, rotation)
            // You can specify the top/left point on the screen to start drawing at.
            int screenX = mXOffset;
            int screenY = mYOffset;

            // You can draw a portion of an image by specifying coordinates to start
            // reading from (top/left). In this case, we're just going to draw the
            // whole image every time.
            int imageX = 0;
            int imageY = 0;

            // You should always specify the width and height of the image to be
            // drawn. If you specify values that are less than the size of the image,
            // only the portion you specify will be drawn. If you specify values
            // larger than the image, the behavior is undefined (so don't do that).
            //
            // In this example, we assume that the image is 128x128, big enough to
            // cover the full size of the display. If the image runs off the sides of
            // the display (because of offsets due to tilting; see OnTilt, above), it
            // will be clipped.
            int width = 128;
            int height = 128;

            // You can upscale an image by integer multiples. A scaled image still
            // starts drawing at the specified top/left point, but the area of the
            // display it covers (width/height) will be multipled by the scale.
            //
            // The default value is 1 (1:1 scale).
            int scale = mScale;

            // You can rotate an image by quarters. The rotation value is an integer
            // representing counterclockwise rotation.
            //
            // * 0 = no rotation
            // * 1 = 90 degrees counterclockwise
            // * 2 = 180 degrees
            // * 3 = 90 degrees clockwise
            //
            // A rotated image still starts drawing at the specified top/left point;
            // the pixels are just drawn in rotated order.
            //
            // The default value is 0 (no rotation).
            int rotation = mRotation;
            #endregion
            if (mCubeType == 2)
            {
                if (eCubeWrapper.eColiColor == "white") mCube.Image("w Ecoli 01", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                if (eCubeWrapper.eColiColor == "red") mCube.Image("b Ecoli 01", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                if (eCubeWrapper.eColiColor == "yellow") mCube.Image("y Ecoli 01", screenX, screenY, imageX, imageY, width, height, scale, rotation);
                if (eCubeWrapper.eColiColor == "blue") mCube.Image("r Ecoli 01", screenX, screenY, imageX, imageY, width, height, scale, rotation);

                mCube.Paint();
            }
        }


        #endregion

        #region Draws Current Image to Cube's Display

        /// <summary>
        /// This method draws the current image to the cube's display. The
        /// Cube.Image method has a lot of arguments, but many of them are optional
        /// and have reasonable default values.
        /// </summary>
        public void DrawColoredCube()
        {
            String imgName = this.mApp.mImageNames[this.colorIndex];
            String eColiName = this.mApp.mEcoliNames[this.eColiIndex];

            #region Extra Info (screenX, screenY, imageX, imageY, scale, rotation)
            // You can specify the top/left point on the screen to start drawing at.
            int screenX = mXOffset;
            int screenY = mYOffset;

            // You can draw a portion of an image by specifying coordinates to start
            // reading from (top/left). In this case, we're just going to draw the
            // whole image every time.
            int imageX = 0;
            int imageY = 0;

            // You should always specify the width and height of the image to be
            // drawn. If you specify values that are less than the size of the image,
            // only the portion you specify will be drawn. If you specify values
            // larger than the image, the behavior is undefined (so don't do that).
            //
            // In this example, we assume that the image is 128x128, big enough to
            // cover the full size of the display. If the image runs off the sides of
            // the display (because of offsets due to tilting; see OnTilt, above), it
            // will be clipped.
            int width = 128;
            int height = 128;

            // You can upscale an image by integer multiples. A scaled image still
            // starts drawing at the specified top/left point, but the area of the
            // display it covers (width/height) will be multipled by the scale.
            //
            // The default value is 1 (1:1 scale).
            int scale = mScale;

            // You can rotate an image by quarters. The rotation value is an integer
            // representing counterclockwise rotation.
            //
            // * 0 = no rotation
            // * 1 = 90 degrees counterclockwise
            // * 2 = 180 degrees
            // * 3 = 90 degrees clockwise
            //
            // A rotated image still starts drawing at the specified top/left point;
            // the pixels are just drawn in rotated order.
            //
            // The default value is 0 (no rotation).
            int rotation = mRotation;
            #endregion

            // color menu cube
            if(mCubeType == 0)
            {
                mCube.Image(imgName, screenX, screenY, imageX, imageY, width, height, scale, rotation);
                mCube.Paint();
            }

        }
        #endregion

        #region Runs Dripping Animation 
        /// <summary>
        /// Method to draw the dripping on the color cube
        /// </summary>
        public void DrawDrip()
        {
            if (this.color == "red")
            {
                //Console.WriteLine("mDripNames: " + this.mApp.mDripNames[mIndex]);
                String dripName = this.mApp.mDripNames[this.mIndex];
                mCube.Image(dripName, 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint();
            }

            if (this.color == "blue")
            {
                //Console.WriteLine("mBDripNames: " + this.mApp.mBDripNames[mIndex]);
                String dripName = this.mApp.mBDripNames[this.mIndex];
                mCube.Image(dripName, 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint(); 
            }

            if (this.color == "yellow")
            {
                //Console.WriteLine("mYDripNames: " + this.mApp.mYDripNames[mIndex]);
                String dripName = this.mApp.mYDripNames[this.mIndex];
                mCube.Image(dripName, 0, 0, 0, 0, 128, 128, 1, 0);
                mCube.Paint();
            }

        }

        /// <summary>
        /// Runs dripping animation for plasmid cube
        /// </summary>
        public void DrawPdrip()
        {

            //Log.Debug("in DrawPdrip");
            
            //Log.Debug("4 Color: " + this.color + "; Color index: " + colorIndex);
            if (this.color == "red")
            {
                //Log.Debug("PDrip Img Name " + this.mApp.mPdripNames[this.bIndex]);
                String PdripName = this.mApp.mPdripNames[this.bIndex];
                bCube.Image(PdripName, 0, 0, 0, 0, 128, 128, 1, 0);
                bCube.Paint();
                
            }

            if (this.color == "yellow")
            {
                //Log.Debug("PDrip Img Name " + this.mApp.mYPdripNames[this.bIndex]);
                String PdripName = this.mApp.mYPdripNames[this.bIndex];
                bCube.Image(PdripName, 0, 0, 0, 0, 128, 128, 1, 0);
                bCube.Paint();
                
            }

            if (this.color == "blue")
            {
                //Log.Debug("PDrip Img Name " + this.mApp.mBPdripNames[this.bIndex]);
                //Log.Debug("bIndex: " + bIndex);
                String PdripName = this.mApp.mBPdripNames[this.bIndex];
                bCube.Image(PdripName, 0, 0, 0, 0, 128, 128, 1, 0);
                bCube.Paint();
                
            }

        }
        #endregion

        #region Runs Ecoli Traveling animation

        public void DrawEcoliTravel()
        {
            if (bCubeWrapper != null && bCubeWrapper.mCubeType == 2)
            {
                #region White on White if top-bottom
                if (this.eColiColor == "white" && bCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for two white ecoli cubes");
                    String ecoliTravel = this.mApp.mEcoliTravelNames[this.travelIndex];
                    bCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region Blue on Blue if top-bottom
                if (this.eColiColor == "blue" && bCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for two blues ecoli cubes");
                    String ecoliTravel = this.mApp.mBEcoliTravelNames[this.travelIndex];
                    bCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region Red on Red if top-bottom
                if (this.eColiColor == "red" && bCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for two blues ecoli cubes");
                    String ecoliTravel = this.mApp.mREcoliTravelNames[this.travelIndex];
                    bCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region Yellow on Yellow if top-bottom
                if (this.eColiColor == "yellow" && bCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for two blues ecoli cubes");
                    String ecoliTravel = this.mApp.mYEcoliTravelNames[this.travelIndex];
                    bCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region Blue on Yellow if top-bottom
                if (this.eColiColor == "yellow" && bCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mBYEcoliTravelNamesC2[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mBYEcoliTravelNamesC1[this.travelIndex];
                    bCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "blue" && bCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mBYEcoliTravelNamesC2[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mBYEcoliTravelNamesC1[this.travelIndex];
                    bCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region Red on Blue if top-bottom

                if (this.eColiColor == "blue" && bCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliRedTravel = this.mApp.mRBEcoliTravelNamesC1[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mRBEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "red" && bCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliRedTravel = this.mApp.mRBEcoliTravelNamesC1[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mRBEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }

                #endregion

                #region Red on Yellow if top-bottom

                if (this.eColiColor == "yellow" && bCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliRedTravel = this.mApp.mRYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mRYEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "red" && bCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliRedTravel = this.mApp.mRYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mRYEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }

                #endregion

                #region White on Blue if top-bottom
                if (this.eColiColor == "blue" && bCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWBEcoliTravelNamesC1[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mWBEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "white" && bCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWBEcoliTravelNamesC1[this.travelIndex];
                    String ecoliBlueTravel = this.mApp.mWBEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region White on Red if top-bottom
                if (this.eColiColor == "red" && bCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWREcoliTravelNamesC1[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mWREcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "white" && bCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWREcoliTravelNamesC1[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mWREcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

                #region White on Yellow if top-bottom
                if (this.eColiColor == "yellow" && bCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mWYEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    bCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 0);
                    mCube.Paint();
                    return;
                    //return;
                }

                if (this.eColiColor == "white" && bCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow and one blue ecoli cubes");
                    String ecoliWhiteTravel = this.mApp.mWYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mWYEcoliTravelNamesC2[this.travelIndex];
                    bCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    bCube.Paint();
                    mCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 2);
                    mCube.Paint();
                    return;
                    //return;
                }
                #endregion

            }

            if (rCubeWrapper != null && rCubeWrapper.mCubeType == 2)
            {
                #region White on White if right-left
                if (this.eColiColor == "white" && rCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for two white ecoli cubes");
                    String ecoliTravel = this.mApp.mEcoliTravelNames[this.travelIndex];
                    rCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                    //return;
                }
                #endregion

                #region Blue on Blue if side to side
                if (this.eColiColor == "blue" && rCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for two blue ecoli cubes");
                    String ecoliTravel = this.mApp.mBEcoliTravelNames[this.travelIndex];
                    rCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                    //return;
                }
                #endregion

                #region Red on Red if side to side
                if (this.eColiColor == "red" && rCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for two blue ecoli cubes");
                    String ecoliTravel = this.mApp.mREcoliTravelNames[this.travelIndex];
                    rCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                    //return;
                }
                #endregion

                #region Yellow on Yellow if side to side
                if (this.eColiColor == "yellow" && rCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for two blue ecoli cubes");
                    String ecoliTravel = this.mApp.mYEcoliTravelNames[this.travelIndex];
                    rCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                    //return;
                }
                #endregion

                #region Yellow on Blue if side to side

                if (this.eColiColor == "blue" && rCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow (right) and one blue (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mBYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mBYEcoliTravelNamesC2[this.travelIndex];
                    rCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "yellow" && rCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one yellow (right) and one blue (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mBYEcoliTravelNamesC1[this.travelIndex];
                    String ecoliYellowTravel = this.mApp.mBYEcoliTravelNamesC2[this.travelIndex];
                    rCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }



                #endregion

                #region Red on Blue if side to side

                if (this.eColiColor == "red" && rCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one blue (right) and one red (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mRBEcoliTravelNamesC2[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mRBEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "blue" && rCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one red (right) and one blue (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mRBEcoliTravelNamesC2[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mRBEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }

                #endregion

                #region Red on Yellow if side to side

                if (this.eColiColor == "red" && rCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one blue (right) and one red (left) ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mRYEcoliTravelNamesC2[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mRYEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "yellow" && rCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one red (right) and one yellow (left) ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mRYEcoliTravelNamesC2[this.travelIndex];
                    String ecoliRedTravel = this.mApp.mRYEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }

                #endregion

                #region White on Blue if side to side
                if (this.eColiColor == "white" && rCubeWrapper.eColiColor == "blue")
                {
                    Log.Debug("Run traveling e.coli animation for one blue (right) and one red (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mWBEcoliTravelNamesC2[this.travelIndex];
                    String ecolWhiteTravel = this.mApp.mWBEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecolWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "blue" && rCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one red (right) and one yellow (left) ecoli cubes");
                    String ecoliBlueTravel = this.mApp.mWBEcoliTravelNamesC2[this.travelIndex];
                    String ecoliWhiteTravel = this.mApp.mWBEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliBlueTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }
                #endregion 

                #region White on Red if side to side
                if (this.eColiColor == "white" && rCubeWrapper.eColiColor == "red")
                {
                    Log.Debug("Run traveling e.coli animation for one blue (right) and one red (left) ecoli cubes");
                    String ecoliRedTravel = this.mApp.mWREcoliTravelNamesC2[this.travelIndex];
                    String ecolWhiteTravel = this.mApp.mWREcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecolWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "red" && rCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one red (right) and one yellow (left) ecoli cubes");
                    String ecoliRedTravel = this.mApp.mWREcoliTravelNamesC2[this.travelIndex];
                    String ecoliWhiteTravel = this.mApp.mWREcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliRedTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }
                #endregion 

                #region White on Yellow if side to side
                if (this.eColiColor == "white" && rCubeWrapper.eColiColor == "yellow")
                {
                    Log.Debug("Run traveling e.coli animation for one blue (right) and one red (left) ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mWYEcoliTravelNamesC2[this.travelIndex];
                    String ecolWhiteTravel = this.mApp.mWYEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    rCube.Paint();
                    mCube.Image(ecolWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 3);
                    mCube.Paint();
                    //return;
                }
                if (this.eColiColor == "yellow" && rCubeWrapper.eColiColor == "white")
                {
                    Log.Debug("Run traveling e.coli animation for one red (right) and one yellow (left) ecoli cubes");
                    String ecoliYellowTravel = this.mApp.mWYEcoliTravelNamesC2[this.travelIndex];
                    String ecoliWhiteTravel = this.mApp.mWYEcoliTravelNamesC1[this.travelIndex];
                    rCube.Image(ecoliWhiteTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    rCube.Paint();
                    mCube.Image(ecoliYellowTravel, 0, 0, 0, 0, 128, 128, 1, 1);
                    mCube.Paint();
                    //return;
                }
                #endregion 

            }

        }

        #endregion

        #region Tick Method
        /// <summary>
        ///  This method is called every frame by the Tick in SlideShowApp (see above.)
        /// </summary>
        public void Tick()
        {
            
            if (mCube.Neighbors.Bottom != null) //updating Plasmid cube
            {
                bCube = mCube.Neighbors.Bottom;
                bCubeWrapper = (CubeWrapper) bCube.userData;
            }

            if (mCube.Neighbors.Right != null) 
            {
                rCube = mCube.Neighbors.Right;
                rCubeWrapper = (CubeWrapper)rCube.userData; 
            }
            if (mCube.Neighbors.Left != null)
            {
                lCube = mCube.Neighbors.Left;
                lCubeWrapper = (CubeWrapper)lCube.userData;
            }

            //Iterate through Hashtables to find colored/plasmid/eColi CubeWrappers

            foreach (DictionaryEntry pair in mApp.cHash)
            {
                if (cCubeStringId != "")
                {
                    if (cCubeStringId == (string) pair.Key) cCubeWrapper = (CubeWrapper)pair.Value;
                }
            }

            foreach(DictionaryEntry pair in mApp.eHash)
            {
                if (eCubeStringId != "")
                {
                    if (eCubeStringId == (string) pair.Key) eCubeWrapper = (CubeWrapper)pair.Value;
                }
            }

            foreach (DictionaryEntry pair in mApp.pHash)
            {
                if (pCubeStringId != "")
                {
                    if (pCubeStringId == (string) pair.Key) pCubeWrapper = (CubeWrapper)pair.Value;
                }
            }

            // If anyone has raised the mNeedDrawDrip flag, draw the dripping.
            if (mNeedDrawDrip)
            {
                //Log.Debug("DrawDrip is called here");
                #region TEST
                //Log.Debug("Plasmid Name: " + plasmidName);
                //if (this.color == "red")
                //{
                //    for (int i = 0; i < mApp.mDripNames.Length; i++)
                //    {
                //        this.mIndex++;
                //        if (!(bIndex >= mApp.mPdripNames.Length)) this.bIndex++;
                //        else plasmidName = mApp.mPdripNames[mApp.mPdripNames.Length - 1];
                //        this.DrawDrip();
                //        this.DrawPdrip();
                //    }
                //}

                //if (this.color == "blue")
                //{
                //    for (int i = 0; i < mApp.mBDripNames.Length; i++)
                //    {
                //        this.mIndex++;
                //        if (!(bIndex >= mApp.mBPdripNames.Length)) this.bIndex++;
                //        else plasmidName = mApp.mBPdripNames[mApp.mBPdripNames.Length - 1];
                //        this.DrawDrip();
                //        this.DrawPdrip();
                //    }

                //}

                //if (this.color == "yellow")
                //{
                //    for (int i = 0; i < mApp.mYDripNames.Length; i++)
                //    {
                //        this.mIndex++;
                //        if (!(bIndex >= mApp.mYPdripNames.Length)) this.bIndex++;
                //        else plasmidName = mApp.mYPdripNames[mApp.mYPdripNames.Length - 1];
                //        this.DrawDrip();
                //        this.DrawPdrip();
                //    }

                //}
                #endregion

                this.DrawDrip();
                this.DrawPdrip();

            }

            if (mEcoliTravel)
            {
                for (int i = 0; i < mApp.mEcoliTravelNames.Length; i++)
                {   
                    travelIndex++;
                    if (travelIndex >= mApp.mEcoliTravelNames.Length)
                    {
                        travelIndex = 0;
                        break;
                    }
                    this.DrawEcoliTravel();
                }

                mEcoliTravel = false;
                
                //do
                //{
                //    travelIndex++;
                //    this.DrawEcoliTravel();
                //}
                //while (!(travelIndex > mApp.mEcoliTravelNames.Length));

                
            }

        }
        #endregion
    }
}
