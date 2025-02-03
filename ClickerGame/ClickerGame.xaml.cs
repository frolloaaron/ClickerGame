namespace ClickerGame;
public partial class ClickerGame : ContentPage
{
	public ClickerGame()
	{
		InitializeComponent();
		UpdateCakes();
	}

	//Variables
	double cakes = 0;
	double total_cps = 0;

	//Upgrades
	Upgrade Oven = new Upgrade("Low Quality Oven", "", 0, 15, 0.1);
    Upgrade MWE = new Upgrade("Minimum Wage Employee", "", 0, 100, 1);
    Upgrade SecretRecipe = new Upgrade("Secret Recipe", "", 0, 750, 5);

    //Game Timer
    async void UpdateCakes()
	{
		var gameTimer = new PeriodicTimer(TimeSpan.FromSeconds(0.1));
		while (await gameTimer.WaitForNextTickAsync())
		{
			cakes += (total_cps/10);
			updateCounter();
		}
	}

	//Main Button
	private void cakeButton_Clicked(object sender, EventArgs e)
    {
		cakes++;
		updateCounter();
    }

	//Classes
	public class Upgrade
	{
		public string name;
        public string imageSource;
        public int upgradeCount;
        public int cost;
        public double cakes_per_second;

		public Upgrade(string n, string i, int u, int c, double cps)
		{
			name = n; 
			imageSource = i;
			upgradeCount = u;
			cost = c;
			cakes_per_second = cps;
		}
	}

	public void updateCounter()
	{
        cakeCounter.Text = "Cakes: " + Math.Floor(cakes).ToString();
    }

    //Upgrade Buttons
	private void OvenButton_Clicked(object sender, EventArgs e)
    {
		if (cakes >= Oven.cost)
		{
			cakes -= Oven.cost;
			Oven.upgradeCount += 1;
			Oven.cost = (int)Math.Floor((Oven.cost * 1.15));
			total_cps += Oven.cakes_per_second;
			updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            OvenLabel.Text = $"Cost: {Oven.cost} Cakes | Owned: {Oven.upgradeCount}";
        }
    }

    private void MWEButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= MWE.cost)
        {
            cakes -= MWE.cost;
            MWE.upgradeCount += 1;
            MWE.cost = (int)Math.Floor((MWE.cost * 1.15));
            total_cps += MWE.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            MWELabel.Text = $"Cost: {MWE.cost} Cakes | Owned: {MWE.upgradeCount}";

        }
    }

    private void SRButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= SecretRecipe.cost)
        {
            cakes -= SecretRecipe.cost;
            SecretRecipe.upgradeCount += 1;
            SecretRecipe.cost = (int)Math.Floor((SecretRecipe.cost * 1.15));
            total_cps += SecretRecipe.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            SRLabel.Text = $"Cost: {SecretRecipe.cost} Cakes | Owned: {SecretRecipe.upgradeCount}";
        }
    }
}