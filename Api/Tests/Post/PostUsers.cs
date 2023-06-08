using Core.Ultilities.Model;

namespace Api.Tests.Post
{
    public class PostUsers : BaseAPITest
    {
        public PostUsers(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC07")]
        [Theory(DisplayName = "Verify that user able to create new user")]
        [MemberData(nameof(Users))]
        public async Task VerifyThatUserAbleToCreateNewUser(string name, string job)
        {
            var today = DateTime.UtcNow.Date.ToString();
            // Create user with provided data
            var response = await CreateUser<UserResultModel>(name, job);

            // Validation
            response.Name?.Should().Be(name,
                $"User name is not correct, [{response.Name}] but expected [{name}]");
            Logger.Text($"Name: {response.Name}");

            response.Job?.Should().Be(job, $"Job is not correct, [{response.Job}] but expected [{job}]");
            Logger.Text($"Job: {response.Job}");

            response.Id?.Should().NotBeNullOrEmpty($"Id is null or empty!");
            Logger.Text($"Id: {response.Id}");

            response.CreateAt.Date.ToString()?.Should().Be(today,
                $"Create date is not correct, [{response.CreateAt.Date}] but expected [{today}]");
            Logger.Text($"Create date: {response.CreateAt.Date}");
        }

        public static IEnumerable<object[]> Users =>
            new List<object[]>
            {
                //           |        Name        |           Job           |
                new object[] { "Tom Cruise",        "Actor"                 },
                new object[] { "Johny Deep",        "Actor"                 },
                new object[] { "ReqresIn",          "API Provider"          },
                new object[] { "Adele",             "Singer"                },
                new object[] { "Hoang Vo",          "QA Automation Engineer"},
            };
    }
}
