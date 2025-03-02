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
    Upgrade Oven = new Upgrade("Low Quality Oven", "oven.png", 0, 15, 0.1);
    Upgrade Employee = new Upgrade("Employee", "chef.jpg", 0, 100, 1);
    Upgrade SecretRecipe = new Upgrade("Secret Recipe", "recipe.png", 0, 750, 5);
    Upgrade Factory = new Upgrade("Factory", "factory.png", 0, 2000, 10);
    Upgrade Portal = new Upgrade("Dimensional Portal", "portal.jpg", 0, 10000, 45);
    Upgrade MatterDuplicator = new Upgrade("Matter Duplicator", "duplicator.png", 0, 50000, 100);

    //Game Timer
    async void UpdateCakes()
    {
        var gameTimer = new PeriodicTimer(TimeSpan.FromSeconds(0.1));
        while (await gameTimer.WaitForNextTickAsync())
        {
            cakes += (total_cps / 10);
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

    private void EmployeeButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= Employee.cost)
        {
            cakes -= Employee.cost;
            Employee.upgradeCount += 1;
            Employee.cost = (int)Math.Floor((Employee.cost * 1.15));
            total_cps += Employee.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            EmployeeLabel.Text = $"Cost: {Employee.cost} Cakes | Owned: {Employee.upgradeCount}";

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

    private void FactoryButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= Factory.cost)
        {
            cakes -= Factory.cost;
            Factory.upgradeCount += 1;
            Factory.cost = (int)Math.Floor((Factory.cost * 1.15));
            total_cps += Factory.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            FactoryLabel.Text = $"Cost: {Factory.cost} Cakes | Owned: {Factory.upgradeCount}";
        }
    }

    private void PortalButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= Portal.cost)
        {
            cakes -= Portal.cost;
            Portal.upgradeCount += 1;
            Portal.cost = (int)Math.Floor((Portal.cost * 1.15));
            total_cps += Portal.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            PortalLabel.Text = $"Cost: {Portal.cost} Cakes | Owned: {Portal.upgradeCount}";
        }
    }

    private void MDButton_Clicked(object sender, EventArgs e)
    {
        if (cakes >= MatterDuplicator.cost)
        {
            cakes -= MatterDuplicator.cost;
            MatterDuplicator.upgradeCount += 1;
            MatterDuplicator.cost = (int)Math.Floor((MatterDuplicator.cost * 1.15));
            total_cps += MatterDuplicator.cakes_per_second;
            updateCounter();
            cpsDisplay.Text = $"Current cps: {Math.Round(total_cps, 1)}";
            MDLabel.Text = $"Cost: {MatterDuplicator.cost} Cakes | Owned: {MatterDuplicator.upgradeCount}";
        }
    }
}