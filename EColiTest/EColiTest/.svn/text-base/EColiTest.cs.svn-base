//This codes for the color selection menu. 
//Click to change colors, and tilt to pour colors into the plasmid cube. 

using System;
using System.Collections;
using System.Collections.Generic;
using Sifteo;
using Sifteo.Util;

namespace EColiTest
{

    public class EColiTest : BaseApp
    {

        override public int FrameRate
        {
            get { return 10; }
        }

        public String[] mImageNames; //array of different colors (file names)
        public String[] mDripNames; //RED - array of imgs for dripping animation (drip from colored cube)
        public String[] mPdripNames; //RED - array of imgs for dripping on the plasmid cube
        public String[] mYDripNames; //YELLOW - array of imgs for dripping animation (drip from colored cube)
        public String[] mYPdripNames; //YELLOW - array of imgs for dripping on the plasmid cube
        public String[] mBDripNames; //BLUE - array of imgs for dripping animation (drip from colored cube)
        public String[] mBPdripNames; //BLUE - array of imgs for dripping on the plasmid cube
        public String[] mBEcoliNames; // BLUE - array of E. Coli imgs
        public String[] mREcoliNames; // RED - array of E. Coli imgs
        public String[] mYEcoliNames; // YELLOW - array of E. Coli imgs
        public String[] mEcoliNames; // array of E. Coli imgs
        public String[] mEcoliTravelNames; // WHITE - array of 2 traveling white E. Coli imgs
        public String[] mBEcoliTravelNames; // BLUE - array of 2 traveling blue E. Coli imgs
        public String[] mREcoliTravelNames; // RED - array of 2 traveling red E. Coli imgs
        public String[] mYEcoliTravelNames; // YELLOW - array of 2 traveling yellow E. Coli imgs
        public String[] mBYEcoliTravelNamesC1; // C1 BLUE/YELLOW
        public String[] mRBEcoliTravelNamesC1; // C1 RED/BLUE
        public String[] mRYEcoliTravelNamesC1; // C1 RED/YELLOW
        public String[] mWBEcoliTravelNamesC1; // C1 WHITE/BLUE
        public String[] mWREcoliTravelNamesC1; // C1 WHITE/RED
        public String[] mWYEcoliTravelNamesC1; // C1 WHITE/YELLOW

        public String[] mBYEcoliTravelNamesC2; // C2 BLUE/YELLOW
        public String[] mRBEcoliTravelNamesC2; // C2 RED/BLUE
        public String[] mRYEcoliTravelNamesC2; // C2 RED/YELLOW
        public String[] mWBEcoliTravelNamesC2; // C2 WHITE/BLUE
        public String[] mWREcoliTravelNamesC2; // C2 WHITE/RED
        public String[] mWYEcoliTravelNamesC2; // C2 WHITE/YELLOW
        public List<CubeWrapper> mWrappers = new List<CubeWrapper>();
        public Random mRandom = new Random();

        //Hashtables of each type of cube
        public Hashtable cHash;
        public Hashtable pHash;
        public Hashtable eHash;

        //Transition //Prefix with t
        public static readonly string tWhiteToYellow = "WhiteToYellow";
        public static readonly string tWhiteToRed = "WhiteToRed";
        public static readonly string tWhiteToBlue = "WhiteToBlue";
        public static readonly string tRedToYellow = "RedToYellow";
        public static readonly string tRedToBlue = "tRedToBlue";
        public static readonly string tBlueToYellow = "BlueToYellow";
        public static readonly string tBlueToRed = "BlueToRed";

        //Testing out StateMachine class
        public StateMachine sm;
        
        //State Controllers
        public PlasmidController whitePlasmidController;
        public YellowPlasmidController yellowPlasmidController;
        public RedPlasmidController redPlasmidController;
        public BluePlasmidController bluePlasmidController;

        public Client _client;

        public bool 
            allHasTag = false;
        

        // Here we initialize our app.
        public override void Setup()
        {
            //Init Hashtables
            cHash = new Hashtable();
            pHash = new Hashtable();
            eHash = new Hashtable();

            int i = 0;

            // Load up the list of images.
            mImageNames = LoadImageIndex();
            mDripNames = LoadDripIndex("r");
            mPdripNames = LoadPdripIndex("r");
            mYDripNames = LoadDripIndex("y");
            mYPdripNames = LoadPdripIndex("y");
            mBDripNames = LoadDripIndex("b");
            mBPdripNames = LoadPdripIndex("b");
            mBEcoliNames = LoadEColiIndex("b");
            mREcoliNames = LoadEColiIndex("r");
            mYEcoliNames = LoadEColiIndex("y");
            mEcoliNames = LoadEColiIndex("w");
            mEcoliTravelNames = LoadSameEColiTravelIndex("w");
            mBEcoliTravelNames = LoadSameEColiTravelIndex("b");
            mREcoliTravelNames = LoadSameEColiTravelIndex("r");
            mYEcoliTravelNames = LoadSameEColiTravelIndex("y");

            mBYEcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("b", "y");
            mBYEcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("b", "y");

            mRBEcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("r", "b");
            mRBEcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("r", "b");

            mRYEcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("r", "y");
            mRYEcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("r", "y");

            mWBEcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("w", "b");
            mWBEcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("w", "b");

            mWREcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("w", "r");
            mWREcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("w", "r");

            mWYEcoliTravelNamesC1 = LoadMixC1EcoliTravelIndex("w", "y");
            mWYEcoliTravelNamesC2 = LoadMixC2EcoliTravelIndex("w", "y"); 


            Array.Sort(mDripNames);
            Array.Sort(mPdripNames);
            Array.Sort(mYDripNames);
            Array.Sort(mYPdripNames);
            Array.Sort(mBDripNames);
            Array.Sort(mBPdripNames);
            Array.Sort(mBEcoliNames);
            Array.Sort(mREcoliNames);
            Array.Sort(mYEcoliNames);
            Array.Sort(mEcoliNames);
            Array.Sort(mEcoliTravelNames);
            Array.Sort(mBEcoliTravelNames);
            Array.Sort(mREcoliTravelNames);
            Array.Sort(mYEcoliTravelNames);
            Array.Sort(mBYEcoliTravelNamesC1);
            Array.Sort(mBYEcoliTravelNamesC2);
            Array.Sort(mRBEcoliTravelNamesC1);
            Array.Sort(mRBEcoliTravelNamesC2);
            Array.Sort(mRYEcoliTravelNamesC1);
            Array.Sort(mRYEcoliTravelNamesC2);
            Array.Sort(mWBEcoliTravelNamesC1);
            Array.Sort(mWBEcoliTravelNamesC2);
            Array.Sort(mWREcoliTravelNamesC1);
            Array.Sort(mWREcoliTravelNamesC2);
            Array.Sort(mWYEcoliTravelNamesC1);
            Array.Sort(mWYEcoliTravelNamesC2);


            //Init the StateMachine
            sm = new StateMachine();

            //Init the Controllers
            whitePlasmidController = new PlasmidController(this);
            yellowPlasmidController = new YellowPlasmidController(this);
            redPlasmidController = new RedPlasmidController (this);
            bluePlasmidController = new BluePlasmidController(this);

            sm.State("White", whitePlasmidController);
            sm.State("Yellow", yellowPlasmidController);
            sm.State("Red", redPlasmidController);
            sm.State("Blue", bluePlasmidController);

            sm.Transition("White", tWhiteToYellow, "Yellow");
            sm.Transition("White", tWhiteToRed, "Red");
            sm.Transition("White", tWhiteToBlue, "Blue");

            sm.SetState("White", tWhiteToYellow);
            

            //Log.Debug("mImageNames Length: " + mImageNames.Length);
            //Log.Debug("mDripNames Length: " + mDripNames.Length);
            //Log.Debug("mPdripNames Length: " + mPdripNames.Length);
            //Log.Debug("mYDripNames Length: " + mYDripNames.Length);
            //Log.Debug("mYPdripNames Length: " + mYPdripNames.Length);
            //Log.Debug("mBDripNames Length: " + mBDripNames.Length);
            //Log.Debug("mBPdripNames Length: " + mBPdripNames.Length);


            // Loop through all the cubes and set them up.\
            foreach (Cube cube in CubeSet)
            {
                // Create a wrapper object for each cube. The wrapper object allows us
                // to bundle a cube with extra information and behavior.
                CubeWrapper wrapper = new CubeWrapper(this, cube);

                wrapper.mCubeType = i % 3; //set each cube as a cube type 
                i++;

                //wrapper.mCubeType = 2;

                mWrappers.Add(wrapper);
                

                //grab the UniqueId of the proper cubes
                //if (wrapper.mCubeType == 0) cId = wrapper.mCube.UniqueId;
                //if (wrapper.mCubeType == 1) pId = wrapper.mCube.UniqueId;
                //if (wrapper.mCubeType == 2) eId = wrapper.mCube.UniqueId;

                //sort each cube into appropriate hashtables & update CubeWrapper information
                if (wrapper.mCubeType == 0)
                {
                    wrapper.cCubeWrapper = wrapper;
                    wrapper.cCubeStringId = cube.UniqueId;
                    wrapper.DrawColoredCube();
                    cHash.Add(wrapper.mCube.UniqueId, wrapper);
                    continue;
                }
                    
                if (wrapper.mCubeType == 1)
                {
                    wrapper.pCubeWrapper = wrapper;
                    wrapper.pCubeStringId = cube.UniqueId;
                    wrapper.DrawPlasmidCube();
                    pHash.Add(wrapper.mCube.UniqueId, wrapper);
                    continue;
                }
                    
                if (wrapper.mCubeType == 2)
                {
                    wrapper.eCubeWrapper = wrapper;
                    wrapper.eCubeStringId = cube.UniqueId;
                    wrapper.DrawEcoliCube();
                    eHash.Add(wrapper.mCube.UniqueId, wrapper);
                    continue;                    
                }    
                
            }

            //## Event Handlers ##
            // Objects in the Sifteo API (particularly BaseApp, CubeSet, and Cube)
            // fire events to notify an app of various happenings, including actions
            // that the player performs on the cubes.
            //
            // To listen for an event, just add the handler method to the event. The
            // handler method must have the correct signature to be added. Refer to
            // the API documentation or look at the examples below to get a sense of
            // the correct signatures for various events.
            //
            // **NeighborAddEvent** and **NeighborRemoveEvent** are triggered when
            // the player puts two cubes together or separates two neighbored cubes.
            // These events are fired by CubeSet instead of Cube because they involve
            // interaction between two Cube objects. (There are Cube-level neighbor
            // events as well, which comes in handy in certain situations, but most
            // of the time you will find the CubeSet-level events to be more useful.)

            CubeSet.NeighborAddEvent += OnNeighborAdd;
            CubeSet.NeighborRemoveEvent += OnNeighborRemove;

            //Init client
            _client = new Client();

            
        }

        // ## Neighbor Add ##
        // This method is a handler for the NeighborAdd event. It is triggered when
        // two cubes are placed side by side.
        //
        // Cube1 and cube2 are the two cubes that are involved in this neighboring.
        // The two cube arguments can be in any order; if your logic depends on
        // cubes being in specific positions or roles, you need to add logic to
        // this handler to sort the two cubes out.
        //
        // Side1 and side2 are the sides that the cubes neighbored on.

        // If two cubes are neighboring each other, raise the mNeedTilt flag (see the OnTilt method).
        
        private void OnNeighborAdd(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2)
        {
            Log.Debug("In neighbor method");
            CubeWrapper wrapper = (CubeWrapper)cube1.userData;
            CubeWrapper wrapper2 = (CubeWrapper)cube2.userData;
            //If neither CubeWrappers are null...
            if (wrapper != null && wrapper2 != null)
            {
                string wId = wrapper.mCube.UniqueId;
                string w2Id = wrapper2.mCube.UniqueId;
                
                #region If colored and plasmid cubes become neighbors

                if (wrapper.mCubeType == 0 && wrapper2.mCubeType == 1)
                {
                    Log.Debug("wrapper is 0 and wrapper2 is 1");
                    //reorients cubes - if cube1 is the color cube and cube2 is the plasmid cube
                    if (cube1.Neighbors.SideOf(cube2) != Cube.Side.BOTTOM &&
                        cube2.Neighbors.SideOf(cube1) != Cube.Side.TOP)
                    {
                        Cube.Side sidePlasmid = cube1.Neighbors.SideOf(cube2); //defines side neighboring cube is on
                        Cube.Side sideColor = cube2.Neighbors.SideOf(cube1); //defines side of neighbor original cube is adjacent to

                        #region reorients plasmid cube
                        if (sideColor == Cube.Side.BOTTOM)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.TOP;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.BOTTOM;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.LEFT;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.RIGHT;
                        }

                        if (sideColor == Cube.Side.RIGHT)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.LEFT;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.RIGHT;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.BOTTOM;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.TOP;
                        }

                        if (sideColor == Cube.Side.LEFT)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.RIGHT;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.LEFT;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.TOP;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.BOTTOM;
                        }
                        #endregion

                        #region reorients color cube
                        if (sidePlasmid == Cube.Side.LEFT)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.LEFT;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.RIGHT;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.BOTTOM;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.TOP;
                        }
                        if (sidePlasmid == Cube.Side.RIGHT)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.RIGHT;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.LEFT;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.BOTTOM;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.TOP;

                        }
                        if (sidePlasmid == Cube.Side.TOP)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.TOP;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.BOTTOM;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.RIGHT;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.LEFT;
                        }
                        #endregion
                        //redraws both cubes
                        wrapper.DrawColoredCube();
                        wrapper2.DrawPlasmidCube();
                    }

                    //Log.Debug("1 Neighbors: Colored and Plasmid");
                    if (wrapper.mCube.Neighbors.Bottom == cube2)
                    {

                        Log.Debug("1 Neighbors: Colored and Plasmid");
                        //wrapper.cCubeStringId = wId;
                        wrapper2.cCubeStringId = wId;
                        wrapper.pCubeStringId = w2Id;
                        //wrapper2.pCubeStringId = w2Id;
                        
                    }
                }//end if wrapper has colored cube and wrapper2 has plasmid cube

                if (wrapper.mCubeType == 1 && wrapper2.mCubeType == 0)
                {
                    Log.Debug("wrapper2 is 0 and wrapper is 1");
                    //reorients cube - if cube2 is the color cube and cube1 is the plasmid cube
                    if (cube2.Neighbors.SideOf(cube1) != Cube.Side.BOTTOM &&
                        cube1.Neighbors.SideOf(cube2) != Cube.Side.TOP)
                    {
                        Cube.Side sidePlasmid = cube2.Neighbors.SideOf(cube1); //defines side neighboring cube is on
                        Cube.Side sideColor = cube1.Neighbors.SideOf(cube2); //defines side of neighbor original cube is adjacent to

                        #region reorients plasmid cube
                        if (sideColor == Cube.Side.BOTTOM)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.TOP;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.BOTTOM;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.LEFT;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.RIGHT;
                        }

                        if (sideColor == Cube.Side.RIGHT)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.LEFT;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.RIGHT;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.BOTTOM;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.TOP;
                        }

                        if (sideColor == Cube.Side.LEFT)
                        {
                            if (cube1.Orientation == Cube.Side.BOTTOM) cube1.Orientation = Cube.Side.RIGHT;
                            else if (cube1.Orientation == Cube.Side.TOP) cube1.Orientation = Cube.Side.LEFT;
                            else if (cube1.Orientation == Cube.Side.RIGHT) cube1.Orientation = Cube.Side.TOP;
                            else if (cube1.Orientation == Cube.Side.LEFT) cube1.Orientation = Cube.Side.BOTTOM;
                        }
                        #endregion

                        #region reorients color cube
                        if (sidePlasmid == Cube.Side.LEFT)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.LEFT;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.RIGHT;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.BOTTOM;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.TOP;
                        }
                        if (sidePlasmid == Cube.Side.RIGHT)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.RIGHT;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.LEFT;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.BOTTOM;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.TOP;

                        }
                        if (sidePlasmid == Cube.Side.TOP)
                        {
                            if (cube2.Orientation == Cube.Side.BOTTOM) cube2.Orientation = Cube.Side.TOP;
                            else if (cube2.Orientation == Cube.Side.TOP) cube2.Orientation = Cube.Side.BOTTOM;
                            else if (cube2.Orientation == Cube.Side.LEFT) cube2.Orientation = Cube.Side.RIGHT;
                            else if (cube2.Orientation == Cube.Side.RIGHT) cube2.Orientation = Cube.Side.LEFT;
                        }
                        #endregion

                        //redraws both cubes
                        wrapper2.DrawColoredCube();
                        wrapper.DrawPlasmidCube();
                    }

                    //Log.Debug("2 Neighbors: Colored and Plasmid");
                    if (wrapper2.mCube.Neighbors.Bottom == cube1)
                    {
                        Log.Debug("2 Neighbors: Colored and Plasmid");
                        //wrapper.pCubeStringId = wId;
                        wrapper2.pCubeStringId = wId;
                        wrapper.cCubeStringId = w2Id;
                        //wrapper2.cCubeStringId = w2Id;
                    }
                }//end if wrapper has plasmid cube and wrapper2 has colored cube
                #endregion

                #region If plasmid and E. Coli cubes become neighbors
                if (wrapper.mCubeType == 1 && wrapper2.mCubeType == 2)
                {
                    cube1.Orientation = Cube.Side.TOP;
                    wrapper.DrawPlasmidCube();
                    
                    Log.Debug("1 Neighbors: Plasmid and E. Coli");
                    //if (wrapper.mCube.Neighbors.Right == cube2 ||
                    //    wrapper.mCube.Neighbors.Left == cube2)
                    //{
                        wrapper2.pCubeStringId = wId;
                        wrapper.eCubeStringId = w2Id;
                        wrapper.mNeedFlip = true;
                    //}
                }

                if (wrapper.mCubeType == 2 && wrapper2.mCubeType == 1)
                {
                    cube2.Orientation = Cube.Side.TOP;
                    wrapper2.DrawPlasmidCube();
                    Log.Debug("2 Neighbors: Plasmid and E. Coli");
                    
                    //if (wrapper2.mCube.Neighbors.Right == cube1 ||
                    //    wrapper2.mCube.Neighbors.Left == cube1)
                    //{
                        wrapper2.eCubeStringId = wId;
                        wrapper.pCubeStringId = w2Id;
                        wrapper2.mNeedFlip = true;
                        
                    //}
                }

                #endregion

                #region Tilting animation 
                //Each if statement does the same thing just from a different cube's perspective--
                //If the bottom neighbor of the cube is cube2 and if cube is a colored cube and 
                //the neighboring cube is a bottom cube 

                if (cube1.Neighbors.Bottom == cube2
                    && (wrapper.mCubeType == 0 && wrapper2.mCubeType == 1))
                {
                    Log.Debug("mNeedTilt is true");
                    wrapper.mNeedTilt = true;
                }

                if (cube2.Neighbors.Bottom == cube1 &&
                    (wrapper.mCubeType == 1 && wrapper2.mCubeType == 0))
                {
                    Log.Debug("mNeedTilt is true");
                    wrapper2.mNeedTilt = true;
                }
                #endregion

                #region Left-Right Plasmid/Ecoli Interaction
                //Each if statement checks for whether the neighboring cubes are Plasmid and E. Coli cubes
                //and they are to the left or right of each other

                //if ((cube1.Neighbors.Left == cube2
                //    && (wrapper.mCubeType == 1 && wrapper2.mCubeType == 2)) ||
                //    ((cube1.Neighbors.Right == cube2)
                //    && (wrapper.mCubeType == 1 && wrapper2.mCubeType == 2)))
                //{
                //    Log.Debug("mNeedFlip is true");
                //    wrapper.mNeedFlip = true;
                //}

                //if ((cube2.Neighbors.Left == cube1 &&
                //    (wrapper.mCubeType == 2 && wrapper2.mCubeType == 1)) ||
                //    (cube2.Neighbors.Right == cube1 &&
                //    (wrapper.mCubeType == 2 && wrapper2.mCubeType == 1)))
                //{
                //    Log.Debug("mNeedFlip is true");
                //    wrapper2.mNeedFlip = true;
                //}
                #endregion

                #region If two E. Coli cubes become top-bottom neighbors
                if (wrapper.mCubeType == 2 && wrapper2.mCubeType == 2)
                {
                    resetCubeWrappers(cube1, cube2);
                    Log.Debug("two white Ecoli!");
                    if (wrapper.mCube.Neighbors.Bottom == cube2) //If cube1 is on top
                    {
                        Log.Debug("white top, white bottom");
                        wrapper.bCubeWrapper = wrapper2;
                        wrapper.bCube = cube2;
                        //wrapper.mCube.Orientation = Cube.Side.BOTTOM;
                        wrapper.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 2);
                        wrapper.mEcoliTravel = true;
                    }

                    if (wrapper2.mCube.Neighbors.Bottom == cube1) //If cube2 is on top
                    {
                        Log.Debug("white bottom, white top");
                        wrapper2.bCubeWrapper = wrapper;
                        wrapper2.bCube = cube1;
                        //wrapper2.mCube.Orientation = Cube.Side.BOTTOM;
                        wrapper2.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 2);
                        wrapper2.mEcoliTravel = true;
                    }

                }

                #endregion

                #region If two Ecoli cubes Left-Right Neighbors
                if (wrapper.mCubeType == 2 && wrapper2.mCubeType == 2)
                {
                    resetCubeWrappers(cube1, cube2);
                    //Log.Debug("two white Ecoli!");
                    if (wrapper.mCube.Neighbors.Right == cube2 ||
                        wrapper2.mCube.Neighbors.Left == cube1) 
                    {
                        
                        //Log.Debug("white left, white right");
                        wrapper.rCubeWrapper = wrapper2;
                        wrapper.rCube = cube2;
                        //wrapper2.lCubeWrapper = wrapper;
                        //wrapper2.lCube = cube1;
                        //wrapper.mCube.Orientation = Cube.Side.BOTTOM;
                        wrapper.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 1);
                        wrapper2.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 3);
                        wrapper.mEcoliTravel = true;
                        return;
                    }

                    if (wrapper2.mCube.Neighbors.Right == cube1 ||
                        wrapper.mCube.Neighbors.Left == cube2) 
                    {
                        
                        //Log.Debug("white right, white left");
                        wrapper2.rCubeWrapper = wrapper;
                        wrapper2.rCube = cube1;
                        //wrapper.lCubeWrapper = wrapper2;
                        //wrapper.lCube = cube2;
                        //wrapper.mCube.Orientation = Cube.Side.BOTTOM;
                        wrapper2.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 1);
                        wrapper.mCube.Image(mEcoliTravelNames[0], 0, 0, 0, 0, 128, 128, 1, 3);
                        wrapper2.mEcoliTravel = true;
                        return;
                    }

                }

                #endregion
            }           
        }
        


        // ## Neighbor Remove ##
        // This method is a handler for the NeighborRemove event. It is triggered
        // when two cubes that were neighbored are separated.
        //
        // The side arguments for this event are the sides that the cubes
        // _were_ neighbored on before they were separated. If you check the
        // current state of their neighbors on those sides, they should of course
        // be NONE.
        public void OnNeighborRemove(Cube cube1, Cube.Side side1, Cube cube2, Cube.Side side2)
        {

            CubeWrapper wrapper = (CubeWrapper)cube1.userData;
            CubeWrapper wrapper2 = (CubeWrapper)cube2.userData;

            if (wrapper != null)
            {
                wrapper.mNeedTilt = false;
                //wrapper.mNeedFlip = false;
                Log.Debug("In OnNeighborRemove");
            }

            if (wrapper2 != null)
            {
                wrapper2.mNeedTilt = false;
                //wrapper.mNeedFlip = false;
                Log.Debug("In OnNeighborRemove");
            }

            //if (wrapper.eColiColor == "blue")
            //{
            //    _client.SendPhoto("Blue");
            //}
            //else if (wrapper.eColiColor == "red")
            //{
            //    _client.SendPhoto("Red");
            //}
            //else if (wrapper.eColiColor == "yellow")
            //{
            //    _client.SendPhoto("Yellow");
            //}

        }

        private void resetCubeWrappers(Cube cube1, Cube cube2)
        {
            CubeWrapper cw1 = (CubeWrapper)cube1.userData;
            CubeWrapper cw2 = (CubeWrapper)cube2.userData;

            cw1.bCube = null;
            cw1.bCubeWrapper = null;
            cw1.rCube = null;
            cw1.rCubeWrapper = null;
            cw1.lCube = null;
            cw1.lCubeWrapper = null;

            cw2.bCube = null;
            cw2.bCubeWrapper = null;
            cw2.rCube = null;
            cw2.rCubeWrapper = null;
            cw2.lCube = null;
            cw2.lCubeWrapper = null;
        }


        // Defer all per-frame logic to each cube's wrapper.
        public override void Tick()
        {
            //Log.Debug("top tick");
            foreach (CubeWrapper wrapper in mWrappers)
            {
                wrapper.Tick();
            }

            
            #region For the "handshake" between surface and the cubes

            //allHasTag = true;
            int allTag = 0;
            foreach (CubeWrapper wrapper in mWrappers)
            {
                if (wrapper.tagVal != null)
                {
                    allTag++;
                }
            }

            if (allTag == 6) allHasTag = true;

            //Assumption: If all wrappers have tags, that means any receiving of a tag would be a request
            //for E. Coli color should the cube be an E. Coli cube

            //if (allHasTag)
            //{
            //    //_client.ReceiveTag();
            //    string tag = _client.tagValue;
                
            //    foreach (CubeWrapper w in mWrappers)
            //    {
            //        Log.Debug("Tag: " + tag + " vs the wrapper: " + w.tagVal);
            //        if (tag == w.tagVal && w.mCubeType == 2)
            //        {
            //            _client.SendPhoto(w.eColiColor);
            //        }
            //    }
            //}
            #endregion
            
        }
        ///// <summary>
        ///// Based on the value of the tag inputted, returns the color of the E. Coli cube with that tag
        ///// </summary>
        ///// <param name="tagValue"></param>
        ///// <returns></returns>
        //public string getWrapperFromTag(string tagValue)
        //{
        //    foreach (CubeWrapper wrapper in mWrappers)
        //    {
        //        if (tagValue == wrapper.tagVal && wrapper.mCubeType == 2)
        //        {
        //            return wrapper.eColiColor;
        //        }
        //    }
        //    return "";
        //}

        #region load images
        // Checks to see if images in the image set contain "color" and builds an array with them. 
        private String[] LoadImageIndex()
        {
            ImageSet imageSet = this.Images;
            ArrayList nameList = new ArrayList();
            foreach (ImageInfo image in imageSet)
            {
                
                if (image.name.Contains("color"))
                {
                    Log.Debug(image.name);
                    nameList.Add(image.name);

                }
            }
            String[] rv = new String[nameList.Count];
            for (int i = 0; i < nameList.Count; i++)
            {
                rv[i] = (string)nameList[i];
            }
            //Log.Debug("Color Cubes: " + nameList.Count);
            return rv;
        }

        // Checks to see if images in the image set contain "drip" and builds an array with them. 
        private String[] LoadDripIndex(string color)
        {
            ImageSet imageSet = this.Images;
            ArrayList dripList = new ArrayList();
            foreach (ImageInfo image in imageSet)
            {

                if (image.name.Contains(color + " drip"))
                {
                    dripList.Add(image.name);
                }
            }
            String[] rv = new String[dripList.Count];
            for (int i = 0; i < dripList.Count; i++)
            {
                rv[i] = (string)dripList[i];
            }
            //Log.Debug(color + " Drip Length: " + rv.Length);
            return rv;
        }

        // Checks to see if images in the image set contain "Pdrip" and builds an array with them. 
        private String[] LoadPdripIndex(string color)
        {
            ImageSet imageSet = this.Images;
            ArrayList pDripList = new ArrayList();
            //int test = 0;
            foreach (ImageInfo image in imageSet)
            {
                //Log.Debug(color + " Pdrip");
                //test++;
                
                if (image.name.Contains(color + " Pdrip"))
                {
                    //Log.Debug("PImg Name: " + image.name);
                    pDripList.Add(image.name);
                }
            }
            String[] rv = new String[pDripList.Count];
            for (int i = 0; i < pDripList.Count; i++)
            {
                rv[i] = (string)pDripList[i];
            }
            //Log.Debug(color + " Pdrip Length: " + rv.Length);
            return rv;
        }

        private String[] LoadEColiIndex(string color)
        {
            ImageSet imageSet = this.Images;
            ArrayList eColiList = new ArrayList();
            int test = 0;
            foreach (ImageInfo image in imageSet)
            {
                //Log.Debug(color + " Ecoli");
                test++;
                //Log.Debug("Img Name: " + image.name);
                if (image.name.Contains(color + " Ecoli") && !image.name.Contains("travel"))
                {
                    eColiList.Add(image.name);
                }
            }
            String[] rv = new String[eColiList.Count];
            for (int i = 0; i < eColiList.Count; i++)
            {
                rv[i] = (string)eColiList[i];
            }
            //Log.Debug(color + " Ecoli Length: " + rv.Length);
            return rv;
        }

        private String[] LoadSameEColiTravelIndex(string color)
        {
            ImageSet imageSet = this.Images;
            ArrayList eColiList = new ArrayList();
            foreach (ImageInfo image in imageSet)
            {
                if (image.name.Contains(color + " Ecoli travel"))
                {
                    Log.Debug("Same Color: " + image.name);
                    eColiList.Add(image.name);
                }
            }
            String[] rv = new String[eColiList.Count];
            for (int i = 0; i < eColiList.Count; i++)
            {
                rv[i] = (string)eColiList[i];
            }
            //Log.Debug(color + " Ecoli Travel Length: " + rv.Length);
            return rv;
        }

        private String[] LoadMixC1EcoliTravelIndex(string bottomCube, string topCube)
        {
            ImageSet imageSet = this.Images;
            ArrayList eColiList = new ArrayList();
            foreach (ImageInfo image in imageSet)
            {
                if (image.name.Contains(bottomCube + topCube + " c1 Ecoli travel"))
                {
                    Log.Debug("C1Img: " + image.name);
                    eColiList.Add(image.name);
                }
            }
            String[] rv = new String[eColiList.Count];
            for (int i = 0; i < eColiList.Count; i++)
            {
                rv[i] = (string)eColiList[i];
            }
            Log.Debug(bottomCube + topCube + " c1 Ecoli Travel Length: " + rv.Length);
            return rv;
        }

        private String[] LoadMixC2EcoliTravelIndex(string bottomCube, string topCube)
        {
            ImageSet imageSet = this.Images;
            ArrayList eColiList = new ArrayList();
            foreach (ImageInfo image in imageSet)
            {
                if (image.name.Contains(bottomCube + topCube + " c2 Ecoli travel"))
                {
                    Log.Debug("C2Img: " + image.name);
                    eColiList.Add(image.name);
                }
            }
            String[] rv = new String[eColiList.Count];
            for (int i = 0; i < eColiList.Count; i++)
            {
                rv[i] = (string)eColiList[i];
            }
            Log.Debug(bottomCube + topCube + " c2 Ecoli Travel Length: " + rv.Length);
            return rv;
        } 

        #endregion

    }

}

// -----------------------------------------------------------------------
//
// SlideShowApp.cs
//
// Copyright &copy; 2011 Sifteo Inc.
//
// This program is "Sample Code" as defined in the Sifteo
// Software Development Kit License Agreement. By adapting
// or linking to this program, you agree to the terms of the
// License Agreement.
//
// If this program was distributed without the full License
// Agreement, a copy can be obtained by contacting
// support@sifteo.com.
//

