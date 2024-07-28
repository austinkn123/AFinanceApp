namespace MyFinanceApp.Server.Site
{
    public class Settings : AppLibrary.Settings
    {
        public Settings(IConfiguration configuration) : base(configuration) 
        {
            configuration.SetProps(this);
        }
    }
}
 