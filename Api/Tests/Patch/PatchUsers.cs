using Core.Ultilities.Model;

namespace Api.Tests.Patch
{
    public class PatchUsers : BaseAPITest
    {
        public PatchUsers(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC08")]
        [Theory(DisplayName = "Verify that user able to update user with PATCH")]
        [MemberData(nameof(ListUsers))]
        public async Task VerifyThatUserAbleToUpdateUser(string name, string job, int userId)
        {
            var today = DateTime.UtcNow.Date.ToString();
            // Create user with provided data
            // If user not found it will create new data
            var response = await PatchUser<UserResultModel>(name, job, userId);

            // Validation
            response.Name?.Should().Be(name,
                $"User name is not correct, [{response.Name}] but expected [{name}]");
            Logger.Text($"Name: {response.Name}");

            response.Job?.Should().Be(job, $"Job is not correct, [{response.Job}] but expected [{job}]");
            Logger.Text($"Job: {response.Job}");

            response.UpdatedAt.Date.ToString()?.Should().Be(today,
                $"Create date is not correct, [{response.UpdatedAt.Date}] but expected [{today}]");
            Logger.Text($"Updated date: {response.UpdatedAt.Date}");
        }

        public static IEnumerable<object[]> ListUsers =>
            new List<object[]>
            {
                //           |        Name        |           Job            |   Id   |
                new object[] { "Tom Cruise",        "Actor",                     1    },
                new object[] { "Johny Deep",        "Actor",                     2    },
                new object[] { "ReqresIn",          "API Provider",              3    },
                new object[] { "Adele",             "Singer",                    -1   },
                new object[] { "Hoang Vo",          "QA Automation Engineer",    -2   }
            };
    }
}
