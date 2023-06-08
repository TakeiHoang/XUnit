using ListUsers;
using SingleUser;

namespace Api.Tests.Get
{
    public class GetUsers : BaseAPITest
    {
        public GetUsers(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC01")]
        [Theory(DisplayName = "Verify that user able to get list of users info")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task VerifyThatUserAbleToGetUsersInfoPage(int pageNo)
        {
            const int expectedUsersPerPage = 6;
            const int expectedTotalPages = 2;
            const int expectedTotalUsers = 12;

            // Act
            var getListUsersResults = await GetListOfUsers<ListUsersModel>(pageNo);

            // Validation using FluentAssertions
            getListUsersResults.Should().NotBeNull();

            getListUsersResults.Page.Should().Be(pageNo).And.BeGreaterThanOrEqualTo(0);
            Logger.Text($"Page: {getListUsersResults.Page}");

            getListUsersResults.Per_page.Should().Be(expectedUsersPerPage,
                $"Result per page is {getListUsersResults.Per_page} but it's should be {expectedUsersPerPage}");
            Logger.Text($"Result per page: {getListUsersResults.Per_page}");

            getListUsersResults.Total.Should().Be(expectedTotalUsers);
            Logger.Text($"Total users: {getListUsersResults.Total}");

            getListUsersResults.Total_pages.Should().Be(expectedTotalPages);
            Logger.Text($"Total pages: {getListUsersResults.Total_pages}");

            if (3 != pageNo)
            {
                getListUsersResults.Data.Should().NotBeNull();
                getListUsersResults.Data.Count.Should().Be(expectedUsersPerPage,
                    $"List of data: {getListUsersResults.Data.Count} not equal with total users on the same page: {expectedUsersPerPage}");

                foreach (var user in getListUsersResults.Data)
                {
                    user.Id.ToString().Should().NotBeNullOrEmpty($"ID should not be null or empty");
                    user.Email.Should().NotBeNullOrEmpty($"Email should not be null or empty");
                    user.First_name.Should().NotBeNullOrEmpty($"First Name should not be null or empty");
                    user.Last_name.Should().NotBeNullOrEmpty($"Last Name should not be null or empty");
                    user.Avatar.Should().NotBeNullOrEmpty($"Avatar should not be null or empty");
                }
            }
            else
            {
                getListUsersResults.Data.Should().BeNullOrEmpty("Data on page 3 should be null or empty");
            }
            Logger.Text($"Data on page: {getListUsersResults.Data.Count}");
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC12")]
        [Fact(DisplayName = "Verify that user able to get list of users info being delay")]
        public async Task VerifyThatUserAbleToGetUsersInfoPageBeingDelayed()
        {
            const int expectedUsersPerPage = 6;
            const int expectedTotalPages = 2;
            const int expectedTotalUsers = 12;

            // Act
            var getListUsersResults = await GetListOfUsersDelayed<ListUsersModel>();

            // Validation using FluentAssertions
            getListUsersResults.Should().NotBeNull();

            getListUsersResults.Page.Should().Be(1).And.BeGreaterThanOrEqualTo(0);
            Logger.Text($"Page: {getListUsersResults.Page}");

            getListUsersResults.Per_page.Should().Be(expectedUsersPerPage,
                $"Result per page is {getListUsersResults.Per_page} but it's should be {expectedUsersPerPage}");
            Logger.Text($"Result per page: {getListUsersResults.Per_page}");

            getListUsersResults.Total.Should().Be(expectedTotalUsers);
            Logger.Text($"Total users: {getListUsersResults.Total}");

            getListUsersResults.Total_pages.Should().Be(expectedTotalPages);
            Logger.Text($"Total pages: {getListUsersResults.Total_pages}");

            getListUsersResults.Data.Should().NotBeNull();
            getListUsersResults.Data.Count.Should().Be(expectedUsersPerPage,
                $"List of data: {getListUsersResults.Data.Count} not equal with total users on the same page: {expectedUsersPerPage}");

            foreach (var user in getListUsersResults.Data)
            {
                user.Id.ToString().Should().NotBeNullOrEmpty($"ID should not be null or empty");
                user.Email.Should().NotBeNullOrEmpty($"Email should not be null or empty");
                user.First_name.Should().NotBeNullOrEmpty($"First Name should not be null or empty");
                user.Last_name.Should().NotBeNullOrEmpty($"Last Name should not be null or empty");
                user.Avatar.Should().NotBeNullOrEmpty($"Avatar should not be null or empty");
            }

            Logger.Text($"Data on page: {getListUsersResults.Data.Count}");
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC02")] // Get happy-case single user case
        [Trait(Category.TestCase, "TC03")] // Get nagative single user case
        [Theory(DisplayName = "Verify that user able to get single user info")]
        [MemberData(nameof(ListOfUsers))]
        public async Task VerifyThatUserAbleToGetSingleUserInfo(int userId, string email, string firstName,
            string lastName, string avatar)
        {
            // Act
            SingleUserModel getSingleUserResults;
            if (userId < 1 || userId > 12)
            {
                var expectedStatus = HttpStatusCode.NotFound;
                getSingleUserResults = await GetSingleUser<SingleUserModel>(userId, expectedStatus);

                // Validation
                getSingleUserResults.Data.Should().BeNull(
                    "Data is not null. It should be null as Bad Request 404!");
                getSingleUserResults.Support.Should().BeNull(
                    "Support is not null. It should be null as Bad Request 404!");
            }
            else
            {
                getSingleUserResults = await GetSingleUser<SingleUserModel>(userId);

                // Validation
                getSingleUserResults.Data.Id.Should().Be(userId,
                    $"User ID is null. Expected: {userId}");
                Logger.Text($"Id: {getSingleUserResults.Data.Id}");

                getSingleUserResults.Data.Email.Should().Be(email,
                    $"Email is null. Expected: {email}");
                Logger.Text($"Email: {getSingleUserResults.Data.Email}");

                getSingleUserResults.Data.First_name.Should().Be(firstName,
                    $"First Name is null. Expected: {firstName}");
                Logger.Text($"First name: {getSingleUserResults.Data.First_name}");

                getSingleUserResults.Data.Last_name.Should().Be(lastName,
                    $"Last Name is null. Expected: {lastName}");
                Logger.Text($"Last name: {getSingleUserResults.Data.Last_name}");

                getSingleUserResults.Data.Avatar.Should().Contain(avatar,
                    $"Avatar Url is null. Expected: {avatar}");
                Logger.Text($"Avatar Url: {getSingleUserResults.Data.Avatar}");
            }
        }

        public static IEnumerable<object[]> ListOfUsers =>
        new List<object[]>
        {
            //          User Id   |         Email                 |    First Name  |  Last Name    |    Avatar       |
            new object[] { 0 ,      "",                              "",              "" ,            ""             },
            new object[] { 1 ,      "george.bluth@reqres.in",        "George",        "Bluth" ,       "1-image.jpg"  },
            new object[] { 2 ,      "janet.weaver@reqres.in",        "Janet",         "Weaver",       "2-image.jpg"  },
            new object[] { 3 ,      "emma.wong@reqres.in",           "Emma",          "Wong",         "3-image.jpg"  },
            new object[] { 4 ,      "eve.holt@reqres.in",            "Eve",           "Holt",         "4-image.jpg"  },
            new object[] { 5 ,      "charles.morris@reqres.in",      "Charles",       "Morris",       "5-image.jpg"  },
            new object[] { 6 ,      "tracey.ramos@reqres.in",        "Tracey",        "Ramos",        "6-image.jpg"  },
            new object[] { 7 ,      "michael.lawson@reqres.in",      "Michael",       "Lawson",       "7-image.jpg"  },
            new object[] { 8 ,      "lindsay.ferguson@reqres.in",    "Lindsay",       "Ferguson",     "8-image.jpg"  },
            new object[] { 9 ,      "tobias.funke@reqres.in",        "Tobias",        "Funke",        "9-image.jpg"  },
            new object[] { 10,      "byron.fields@reqres.in",        "Byron",         "Fields",       "10-image.jpg" },
            new object[] { 11,      "george.edwards@reqres.in",      "George",        "Edwards",      "11-image.jpg" },
            new object[] { 12,      "rachel.howell@reqres.in",       "Rachel",        "Howell",       "12-image.jpg" },
            new object[] { 13,      "",                              "",              "",             ""             }
        };
    }
}
