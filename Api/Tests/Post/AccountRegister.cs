using Core.Ultilities.Model;

namespace Api.Tests.Post
{
    public class AccountRegister : BaseAPITest
    {
        public AccountRegister(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC10")]
        [Theory(DisplayName = "Verify that user able / not able to register new account")]
        [InlineData("eve.holt@reqres.in", "pistol")] // Verify status 200
        [InlineData("hoang@gmail.com", "test")] // Verify status 400
        public async Task VerifyThatUserAbleToRegister(string email, string password)
        {
            AccountResultModel response;
            if ("eve.holt@reqres.in" == email)
            {
                response = await RegisterAccount<AccountResultModel>(email, password);

                // Validation
                response.Id.Should().BeGreaterThan(0);
                Logger.Text($"Id: {response.Id}");
                response.Token.Should().NotBeNullOrEmpty();
                Logger.Text($"Token: {response.Token}");
            }
            else
            {
                HttpStatusCode statusCode = HttpStatusCode.BadRequest;
                response = await RegisterAccount<AccountResultModel>(email, password, statusCode);
                // Validation
                response.Id.Should().Be(0);
                Logger.Text($"Id: {response.Id}");
                response.Token.Should().BeNullOrEmpty();
                Logger.Text($"Token: {response.Token}");
            }    
        }
    }
}
