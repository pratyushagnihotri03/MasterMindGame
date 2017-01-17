    using System;
    using System.Collections;
    using System.Threading;
    using Microsoft.SPOT;
    using Microsoft.SPOT.Presentation;
    using Microsoft.SPOT.Presentation.Controls;
    using Microsoft.SPOT.Presentation.Media;
    using Microsoft.SPOT.Presentation.Shapes;
    using Microsoft.SPOT.Touch;

    using Gadgeteer.Networking;
    using GT = Gadgeteer;
    using GTM = Gadgeteer.Modules;
    using Gadgeteer.Modules.GHIElectronics;
/**
 * @author: Group M-TK3 2015
 * 
 **/

    namespace Mastermind_GroupM
    {
        public partial class Program
        {

            //selecting font
            Font font = Resources.GetFont(Resources.FontResources.NinaB);

            //set timer
            GT.Timer timer = new GT.Timer(250);

            // all global variables
            bool userChoice = false;
            int count = 0;
            int jyStkPrs = 0;
            bool player_1 = false;
            bool player_2 = false;
            bool red = false;
            bool green = false;
            bool cyan = false;
            bool purple = false;
            bool yellow = false;
            bool blue = false;
            int xPos = 150;
            int xchance = 20, ychance = 20;
            Random aiSequence = new Random();
            int[] stringCheck = new int[4];
            Color[] colorUserSelected = new Color[4];
            int colorCounter = 0;
            Color[] drawColors = new Color[100];
            Color[] computerChoice = new Color[100];
            String answer = "";
            String[] stringAnswers = new String[4];
            
            bool firstscreen = true;
            int temp = 0;
            bool win = false, lose = false;
            int xchanceChoice = 170, ychanceChoice = 180;


            void ProgramStarted()
            {
                timer.Tick += new GT.Timer.TickEventHandler(timer_Tick);
                timer.Start();
                button.ButtonPressed += button_ButtonPressed;
                Debug.Print("Program Started");
                ledStrip.TurnAllLedsOff();
            }

            private void button_ButtonPressed(Button sender, Button.ButtonState state)
            {

                //check for the answer and display it
                if (colorCounter == 4)
                {
                    int j = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        Color[] colorSeq = { drawColors[j], drawColors[j + 1], drawColors[j + 2], drawColors[j + 3] };
                        if (i != 0 && i % 3 == 0)
                        {
                            stringAnswers = getSortedArray(computerChoice, colorSeq);
                            answer = stringAnswers[0] + "   " + stringAnswers[1] + "   " + stringAnswers[2] + "   " + stringAnswers[3];
                        }
                    }
                    drawChecks();
                }
                else
                {
                    userChoice = true;

                    //if no selection is made
                    if (!yellow && !blue && !purple && !green && !cyan && !red)
                    {
                        // the spaces for the player to fill
                        //row1
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 20, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 20, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 20, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 20, 5, 5);
                        //row2
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 40, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 40, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 40, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 40, 5, 5);
                        //row3
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 60, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 60, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 60, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 60, 5, 5);
                        //row4
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 80, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 80, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 80, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 80, 5, 5);
                        //row5
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 100, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 100, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 100, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 100, 5, 5);
                        //row6
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 120, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 120, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 120, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 120, 5, 5);
                        //row7
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 140, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 140, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 140, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 140, 5, 5);
                        //row8
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 160, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 160, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 160, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 160, 5, 5);
                        //row9
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 180, 5, 5);
                        //row10
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 20, 200, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 50, 200, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 80, 200, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 110, 200, 5, 5);
                       
                    }
                }

                //reset screen after win or lose
                if (win || lose)
                {
                    jyStkPrs = 0;
                    firstscreen = true;
                    displayTE35.SimpleGraphics.Clear();
                    resetAll();
                }
            }

            //reset all global variables for the next round of the game
            private void resetAll()
            {
                win = false;
                lose = false;
                temp = 0;
                userChoice = false;
                count = 0;
                stringAnswers = new String[4];
                player_1 = false;
                player_2 = false;
                red = false;
                green = false;
                cyan = false;
                purple = false;
                yellow = false;
                blue = false;
                xPos = 150;
                xchance = 20;
                ychance = 20;
                aiSequence = new Random();
                ledStrip.TurnAllLedsOff();
                colorUserSelected = new Color[4];
                colorCounter = 0;
                drawColors = new Color[100];
                computerChoice = new Color[100];
                answer = "";

            }

            private void drawChecks()
            {
                displayTE35.SimpleGraphics.DisplayText(answer, font, GT.Color.White, 200, 20);
            }

            public int[] aiCheck(Color[] gameRandomSeq, Color[] userInputSeq)
            {
                int[] answer = new int[4]; 
                for (int i = 0; i < 4; i++)
                {
                    // right color , right place
                    if (userInputSeq[i] == gameRandomSeq[i]) answer[i] = 1;
                    else
                        for (int j = 0; j < 4; j++)
                            // right color , wrong place
                            if (userInputSeq[i] == gameRandomSeq[j] && i != j)
                            {

                                answer[i] = 2;
                                break;
                            }
                            else
                                answer[i] = 3;
                }
                return answer;
            }

    /**The indication needs to be sorted! First show how many pins are totally correct
    *(correct color and position), then how many pins are partially correct (only correct color), then how many pins are wrong.
    **/
            String[] getSortedArray(Color[] gameRandomSeq, Color[] userInputSeq)
            {
                String[] sortedAnswer = new String[4];
                stringCheck = aiCheck(gameRandomSeq, userInputSeq);
                for (int write = 0; write < stringCheck.Length; write++)
                {
                    for (int sort = 0; sort < stringCheck.Length - 1; sort++)
                    {
                        if (stringCheck[sort] > stringCheck[sort + 1])
                        {
                            temp = stringCheck[sort + 1];
                            stringCheck[sort + 1] = stringCheck[sort];
                            stringCheck[sort] = temp;
                        }
                    }
                }

                for (int i = 0; i < stringCheck.Length; i++)
                {
                    if (stringCheck[i] == 1)
                        sortedAnswer[i] = "C";
                    else if (stringCheck[i] == 2)
                        sortedAnswer[i] = "WP";
                    else if (stringCheck[i] == 3)
                        sortedAnswer[i] = "W";
                }
                return sortedAnswer;

            }

            void timer_Tick(GT.Timer timer)
            {
                //each ticker moment is followed by the following instructions
                double joystickPosX = joystick.GetPosition().X;
                double joystickPosY = joystick.GetPosition().Y;

                //will enter only if the 
                if (firstscreen)
                {
                    displayTE35.SimpleGraphics.DisplayText("######  MASTERMIND GAME  ######", font, GT.Color.White, 35, 20);
                    displayTE35.SimpleGraphics.DisplayText("Joystick UP/DOWN for player mode", font, GT.Color.Cyan, 60, 150);
                    displayTE35.SimpleGraphics.DisplayText("1. SINGLE PLAYER", font, GT.Color.White, 90, 70);
                    displayTE35.SimpleGraphics.DisplayText("2. DOUBLE PLAYER", font, GT.Color.White, 90, 90);
               
                    if (joystickPosY > 0.3 && joystickPosY < 1 && jyStkPrs == 0)
                    {
                        displayTE35.SimpleGraphics.Clear();
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Orange, 1, GT.Color.Orange, 80, 73, 3, 3);
                        player_1 = true;
                        player_2 = false;
                    }

                    if (joystickPosY < (-0.3) && joystickPosY > (-1) && jyStkPrs == 0)
                    {
                        displayTE35.SimpleGraphics.Clear();
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Orange, 1, GT.Color.Orange, 80, 93, 3, 3);
                        player_2 = true;
                        player_1 = false;
                    }
                }

                if (firstscreen == false)
                {

                    if (stringAnswers[0] == "C" && stringAnswers[1] == "C" && stringAnswers[2] == "C" && stringAnswers[3] == "C")
                    {
                        win = true;
                        displayTE35.SimpleGraphics.DisplayText("!!YOU WIN!!", font, GT.Color.Green, 150, 160);
                        displayTE35.SimpleGraphics.DisplayText("Press Button to play again!", font, GT.Color.Red, 135, 180);

                        ledStrip.TurnLedOn(1);
                        ledStrip.TurnLedOn(0);

                    }
                    else if (ychance == 200 && xchance == 110)
                    {

                    }
                    if (joystickPosX > 0.3 && joystickPosX < 1 && jyStkPrs > 0 && xPos > 149 && xPos < 291)
                    {
                   
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 1, GT.Color.Black, xPos, 130, 3, 3);
                        xPos += 20;
                        if (xPos < 271)
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Orange, 1, GT.Color.Orange, xPos, 130, 3, 3);
                        if (xPos > 270)
                        {
                            xPos = 270;
                        }
                    }

                    if (joystickPosX < (-0.3) && joystickPosX > (-1) && jyStkPrs > 0 && xPos > 189 && xPos < 271)
                    {
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 1, GT.Color.Black, xPos, 130, 3, 3);
                        xPos -= 20;
                        if (xPos < 271)
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Orange, 1, GT.Color.Orange, xPos, 130, 3, 3);
                        if (xPos == 270)
                            xPos = 170;
                    }

                }
                joystick.JoystickPressed += joystick_JoystickPressed;
            }

            void joystick_JoystickPressed(Joystick sender, Joystick.ButtonState state)
            {
                temp++;

                firstscreen = false;

                //to clear previous screen
                if (temp == 1)
                    displayTE35.SimpleGraphics.Clear();

                jyStkPrs++;

                if (jyStkPrs == 1 && !player_2)
                {
                    computerChoice = randomSequence();
                    displayTE35.SimpleGraphics.Clear();
                }

                //clear the answer string 
                if (jyStkPrs > 4)
                {
                    displayTE35.SimpleGraphics.DisplayText(answer, font, GT.Color.Black, 200, 20);
                }

                if (jyStkPrs % 5 == 0 && jyStkPrs != 5 || jyStkPrs == 6)
                    colorCounter = 0;

                if (player_1 || userChoice)
                {
                    //  For cleaning the selected color for User 2
                    displayTE35.SimpleGraphics.DisplayText("Selected code:", font, GT.Color.Black, 170, 150);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 2, GT.Color.Black, 170, 180, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 2, GT.Color.Black, 190, 180, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 2, GT.Color.Black, 210, 180, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Black, 2, GT.Color.Black, 230, 180, 5, 5);

                    if (ychance < 200 || xchance < 111)
                    {
                        if (colorCounter < 4)
                        {

                            if (xPos == 170)
                            {
                                drawColors[colorCounter] = GT.Color.Yellow;
                                colorCounter++;
                                if (xchance < 111)
                                {
                                    yellow = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Yellow, 2, GT.Color.Yellow, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Yellow, 2, GT.Color.Yellow, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }

                            if (xPos == 190)
                            {
                                drawColors[colorCounter] = GT.Color.Purple;
                                colorCounter++;
                                if (xchance < 111)
                                {
                                    purple = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Purple, 2, GT.Color.Purple, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Purple, 2, GT.Color.Purple, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }

                            if (xPos == 210)
                            {
                                drawColors[colorCounter] = GT.Color.Green;
                                if (xchance < 111)
                                {
                                    colorCounter++;
                                    green = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Green, 2, GT.Color.Green, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    colorCounter++;
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Green, 2, GT.Color.Green, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }

                            if (xPos == 230)
                            {
                                drawColors[colorCounter] = GT.Color.Blue;
                                if (xchance < 111)
                                {
                                    colorCounter++;
                                    blue = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Blue, 2, GT.Color.Blue, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    colorCounter++;
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Blue, 2, GT.Color.Blue, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }

                            if (xPos == 250)
                            {
                                drawColors[colorCounter] = GT.Color.Cyan;
                                if (xchance < 111)
                                {
                                    colorCounter++;
                                    cyan = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Cyan, 2, GT.Color.Cyan, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    colorCounter++;
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Cyan, 2, GT.Color.Cyan, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }

                            if (xPos == 270)
                            {
                                drawColors[colorCounter] = GT.Color.Red;
                                if (xchance < 111)
                                {
                                    colorCounter++;
                                    red = true;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Red, 2, GT.Color.Red, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                                else if (xchance > 110)
                                {
                                    colorCounter++;
                                    xchance = 20;
                                    ychance += 20;
                                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Red, 2, GT.Color.Red, xchance, ychance, 5, 5);
                                    xchance += 30;
                                }
                            }
                        }
                    }
                    else
                    {
                        drawAnswers();
                    }

                    displayTE35.SimpleGraphics.DisplayText("Choose colour", font, GT.Color.White, 170, 90);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Yellow, 2, GT.Color.Yellow, 170, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Purple, 2, GT.Color.Purple, 190, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Green, 2, GT.Color.Green, 210, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Blue, 2, GT.Color.Blue, 230, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Cyan, 2, GT.Color.Cyan, 250, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Red, 2, GT.Color.Red, 270, 120, 5, 5);


                }


                //TWO player mode starts here
                if (player_2)
                {

                    if (xPos == 170)
                    {
                        if (xchanceChoice < 231)
                        {

                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Yellow, 2, GT.Color.Yellow, xchanceChoice, ychanceChoice, 5, 5);
                            xchanceChoice += 20;
                            colorUserSelected[count] = GT.Color.Yellow;
                            count++;

                        }
                    }

                    if (xPos == 190)
                    {
                        if (xchanceChoice < 231)
                        {
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Purple, 2, GT.Color.Purple, xchanceChoice, ychanceChoice, 5, 5);
                            xchanceChoice += 20;
                            colorUserSelected[count] = GT.Color.Purple;
                            count++;
                        }
                    }

                    if (xPos == 210)
                    {
                        if (xchanceChoice < 231)
                        {
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Green, 2, GT.Color.Green, xchanceChoice, ychanceChoice, 5, 5);
                            xchanceChoice += 20;
                            colorUserSelected[count] = GT.Color.Green;
                            count++;
                        }
                    }

                    if (xPos == 230)
                    {
                        if (xchanceChoice < 231)
                        {
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Blue, 2, GT.Color.Blue, xchanceChoice, ychanceChoice, 5, 5);
                            xchanceChoice += 20;
                            colorUserSelected[count] = GT.Color.Blue;
                            count++;
                        }
                    }

                    if (xPos == 250)
                    {
                        if (xchanceChoice < 231)
                        {
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Cyan, 2, GT.Color.Cyan, xchanceChoice, ychanceChoice, 5, 5);
                            xchance += 20;
                            colorUserSelected[count] = GT.Color.Cyan;
                            count++;
                        }
                    }

                    if (xPos == 270)
                    {
                        if (xchanceChoice < 231)
                        {
                            displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Red, 2, GT.Color.Red, xchanceChoice, ychanceChoice, 5, 5);
                            xchance += 20;
                            colorUserSelected[count] = GT.Color.Red;
                            count++;
                        }
                    }

                    computerChoice = colorUserSelected;

                    //displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Orange, 1, GT.Color.Orange, 170, 120, 3, 3);
                    displayTE35.SimpleGraphics.DisplayText("Choose colour:", font, GT.Color.White, 170, 90);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Yellow, 2, GT.Color.Yellow, 170, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Purple, 2, GT.Color.Purple, 190, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Green, 2, GT.Color.Green, 210, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Blue, 2, GT.Color.Blue, 230, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Cyan, 2, GT.Color.Cyan, 250, 120, 5, 5);
                    displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.Red, 2, GT.Color.Red, 270, 120, 5, 5);


                    if (count == 0)
                    {
                        displayTE35.SimpleGraphics.DisplayText("Selected code:", font, GT.Color.White, 170, 150);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 170, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 190, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 210, 180, 5, 5);
                        displayTE35.SimpleGraphics.DisplayEllipse(GT.Color.White, 2, GT.Color.White, 230, 180, 5, 5);
                    }
               
                }
                throw new NotImplementedException();
            }


            public Color[] randomSequence()
            {

                Color[] randomSeq = new Color[4];
                for (int p = 0; p < randomSeq.Length; p++)
                {
                    int a = aiSequence.Next(5);
                    if (a == 0)
                    {
                        randomSeq[p] = GT.Color.Red;
                    }
                    else if (a == 1)
                    {
                        randomSeq[p] = GT.Color.Green;
                    }
                    else if (a == 2)
                    {
                        randomSeq[p] = GT.Color.Cyan;
                    }
                    else if (a == 3)
                    {
                        randomSeq[p] = GT.Color.Yellow;
                    }
                    else if (a == 4)
                    {
                        randomSeq[p] = GT.Color.Purple;
                    }
                    else if (a == 5)
                    {
                        randomSeq[p] = GT.Color.Blue;
                    }

                }
                return randomSeq;

            }

            private void drawAnswers()
            {
                displayTE35.SimpleGraphics.DisplayText("Secret Code", font, GT.Color.Orange, 130, 215);
                displayTE35.SimpleGraphics.DisplayRectangle(GT.Color.LightGray, 1, 130, 230, 10, 10, 0, 0, computerChoice[0], 0, 0, computerChoice[0], 0, 0, Bitmap.OpacityOpaque);
                displayTE35.SimpleGraphics.DisplayRectangle(GT.Color.LightGray, 1, 150, 230, 10, 10, 0, 0, computerChoice[1], 0, 0, computerChoice[1], 0, 0, Bitmap.OpacityOpaque);
                displayTE35.SimpleGraphics.DisplayRectangle(GT.Color.LightGray, 1, 170, 230, 10, 10, 0, 0, computerChoice[2], 0, 0, computerChoice[2], 0, 0, Bitmap.OpacityOpaque);
                displayTE35.SimpleGraphics.DisplayRectangle(GT.Color.LightGray, 1, 190, 230, 10, 10, 0, 0, computerChoice[3], 0, 0, computerChoice[3], 0, 0, Bitmap.OpacityOpaque);
                if (!win)
                {
                    lose = true;
                    displayTE35.SimpleGraphics.DisplayText("YOU LOOOOSE!!muhaha", font, GT.Color.Green, 150, 160);
                    displayTE35.SimpleGraphics.DisplayText("Press Button to play again!", font, GT.Color.Red, 135, 180);
                    ledStrip.TurnLedOn(5);
                    ledStrip.TurnLedOn(6);
                }
            }

        }
    }