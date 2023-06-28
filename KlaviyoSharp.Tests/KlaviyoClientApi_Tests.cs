namespace KlaviyoSharp.Tests
{
    public class KlaviyoClientApi_Tests
    {
        [Fact]
        public void Setup()
        {
            KlaviyoClientApi clientApi = new(Config.CompanyId);
            Assert.NotNull(clientApi);
        }
    }
}