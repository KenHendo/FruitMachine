using System;
using System.Linq;
using System.Web.UI;

namespace Casino_Challenge
{
    public partial class Default : System.Web.UI.Page
    {

        string[] imageDescriptions = new string[] {
                    "Bar", "Bell","Cherry","Clover","Diamond",
                    "Horseshoe","Lemon","Orange","Plum","Seven",
                    "Strawberry","Watermelon" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //initialise player's starting funds and update displayed funds total.
                ViewState.Add("funds", 100);
                UpdateFundsDisplay();

                //set initial display of random reel positions
                int[] reelPositions = SpinReels();
                DisplayAllReels(reelPositions);
            }
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            bool fundsCheck = ValidateRemainingFunds();
            bool inputCheck = ValidateInput();
            if (fundsCheck && inputCheck)
            {
                int[] reelPositions = SpinReels();
                DisplayAllReels(reelPositions);
                int winnings = CalculateResults(reelPositions, int.Parse(betTextbox.Text));
                DisplayResultText(winnings);
                RecalculateFunds(winnings);
                UpdateFundsDisplay();
            }
        }


        private bool ValidateRemainingFunds()
        {
            //ensure that there are sufficient funds to continue playing
            int remainingFunds = (int)ViewState["funds"];
            if (remainingFunds <= 0)
            {
                resultLabel.Text = "Insufficient Funds Remaining";
                return false;
            }

            return true;
        }

        private bool ValidateInput()
        {
            //ensure that the input is valid: a number that is less than or equal to remaining pot
            if (!int.TryParse(betTextbox.Text, out int bet))
            {
                resultLabel.Text = "Please enter a valid amount";
                return false;
            }

            return true;
        }

        private int[] SpinReels()
        {
            //Select random number between 1 and 12
            Random newrRand = new Random();

            int reelPosition0 = newrRand.Next(0, 11);
            int reelPosition1 = newrRand.Next(0, 11);
            int reelPosition2 = newrRand.Next(0, 11);

            int[] reelPositions = new int[3] { reelPosition0, reelPosition1, reelPosition2 };
            return reelPositions;
        }

        private void DisplayAllReels(int[] reelPositions)
        {
            DisplayReel(0, reelPositions[0]);
            DisplayReel(1, reelPositions[1]);
            DisplayReel(2, reelPositions[2]);
        }

        private void DisplayReel(int reelNumber, int reelPosition)
        {
            string imageName = imageDescriptions[reelPosition];
            string imageURL = String.Format("/Assets/Images/{0}.png", imageName);
            if (reelNumber == 0) { reelImage0.ImageUrl = imageURL; }
            else if (reelNumber == 1) { reelImage1.ImageUrl = imageURL; }
            else { reelImage2.ImageUrl = imageURL; }
        }

        private int CalculateResults(int[] reelPositions, int bet)
        {

            if (ReelsContainsBars(reelPositions)) { return 0; }
            else if (ReelsIsJackpot(reelPositions)) { return bet * 100; }
            else if (CountCherries(reelPositions) > 0) { return CalculateCherryWinnings(CountCherries(reelPositions), bet); }
            else return 0;
        }

        private bool ReelsContainsBars(int[] reelPositions)
        {
            if ((reelPositions[0] == 0 || reelPositions[1] == 0 || reelPositions[2] == 0))
            {
                return true;
            }
            return false;
        }

        private bool ReelsIsJackpot(int[] reelPositions)
        {
            if (reelPositions.SequenceEqual(new int[] { 9, 9, 9, }))
            {
                return true;
            }
            else { return false; }
        }

        private int CountCherries(int[] reelPositions)
        {
            int cherries = 0;
            if (reelPositions[0] == 2) { cherries++; }
            if (reelPositions[1] == 2) { cherries++; }
            if (reelPositions[2] == 2) { cherries++; }
            return cherries;
        }

        private int CalculateCherryWinnings(int cherries, int bet)
        {
            if (cherries == 1) { return bet * 2; }
            else if (cherries == 2) { return bet * 3; }
            else { return bet * 4; }
        }

        private void DisplayResultText(int winnings)
        {
            if (winnings > 0)
            {
                resultLabel.Text = String.Format("Your have won {0:C}", winnings);
            }
            else
            {

                resultLabel.Text = String.Format("You have lost {0:C}", int.Parse(betTextbox.Text));
            }
        }

        private void RecalculateFunds(int winnings)
        {
            if (winnings == 0)
            {
                ViewState["funds"] = (int)ViewState["funds"] - int.Parse(betTextbox.Text);
            }
            else
            {
                ViewState["funds"] = (int)ViewState["funds"] + winnings;
            }
        }

        private void UpdateFundsDisplay()
        {
            fundsLabel.Text = String.Format("{0:C}", ViewState["funds"]);
        }

    }
}