using Core.Ultilities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests.Delete
{
    public class DeleteUsers : BaseAPITest
    {
        public DeleteUsers(ITestOutputHelper outputHelper ) : base( outputHelper ) { }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC09")]
        [Theory(DisplayName = "Verify that user able to delete user")]
        [MemberData(nameof(ListUsersId))]
        public async Task VerifyThatUserAbleToCreateNewUser(int userId)
        {
            // Delete user with provided data
            var response = await DeleteUser<UserResultModel>(userId);

            // Validate the response have no content which is null or empty
            response.Should().BeNull("Delete user currently not null! Please debug your code!");
        }

        public static IEnumerable<object[]> ListUsersId =>
            new List<object[]>
            {
                //           |        User ID       |
                new object[] {        1             },
                new object[] {        2             },
                new object[] {        3             },
                new object[] {        4             },
                new object[] {        5             },
                new object[] {        6             },
                new object[] {        7             },
                new object[] {        8             },
                new object[] {        9             },
                new object[] {        10            },
                new object[] {        11            },
                new object[] {        12            },
                new object[] {        13            }
            };
    }
}
