using ListResources;
using SingleResource;

namespace Api.Tests.Get
{
    public class GetResources : BaseAPITest
    {
        public GetResources(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC04")]
        [Fact(DisplayName = "Verify that user able to get list of resources info")]
        public async Task VerifyThatUserAbleToGetResources()
        {
            const int expectedResourcesPerPage = 6;
            const int expectedTotalPages = 2;
            const int expectedTotalResources = 12;

            // Act
            var getListResourcesResults = await GetListOfResources<ListResourcesModel>();

            // Validation using FluentAssertions
            getListResourcesResults.Should().NotBeNull();

            getListResourcesResults.Page.Should().Be(1).And.BeGreaterThanOrEqualTo(0);
            Logger.Text($"Page: {getListResourcesResults.Page}");

            getListResourcesResults.Per_page.Should().Be(expectedResourcesPerPage,
                $"Result per page is {getListResourcesResults.Per_page} but it's should be {expectedResourcesPerPage}");
            Logger.Text($"Result per page: {getListResourcesResults.Per_page}");

            getListResourcesResults.Total.Should().Be(expectedTotalResources);
            Logger.Text($"Total resources: {getListResourcesResults.Total}");

            getListResourcesResults.Total_pages.Should().Be(expectedTotalPages);
            Logger.Text($"Total pages: {getListResourcesResults.Total_pages}");

            getListResourcesResults.Data.Should().NotBeNull();
            getListResourcesResults.Data.Count.Should().Be(expectedResourcesPerPage,
                $"List of data: {getListResourcesResults.Data.Count} not equal with total users on the same page: {expectedResourcesPerPage}");

            foreach (var resources in getListResourcesResults.Data)
            {
                resources.Id.ToString().Should().NotBeNullOrEmpty($"ID should not be null or empty");
                resources.Name.Should().NotBeNullOrEmpty($"Name should not be null or empty");
                resources.Year.ToString().Should().NotBeNullOrEmpty($"Year should not be null or empty");
                resources.Color.Should().NotBeNullOrEmpty($"Color should not be null or empty");
                resources.Pantone_value.Should().NotBeNullOrEmpty($"Pantone should not be null or empty");
            }

            Logger.Text($"Data on page: {getListResourcesResults.Data.Count}");
        }

        [Trait(Category.Package, CategoryName.API_Regression)]
        [Trait(Category.TestCase, "TC05")] // Get happy-case single resource case
        [Trait(Category.TestCase, "TC06")] // Get nagative single resource case
        [Theory(DisplayName = "Verify that user able to get list of users info on depend on User Id")]
        [MemberData(nameof(ListOfResources))]
        public async Task VerifyThatUserAbleToGetSingleResourceInfo(int resourceId, string name,
            int year, string color, string pantone_value)
        {
            // Act
            SingleResourceModel getSingleResourceResults;
            if (resourceId < 1 || resourceId > 12)
            {
                var expectedStatus = HttpStatusCode.NotFound;
                getSingleResourceResults = await GetSingleResource<SingleResourceModel>(resourceId, expectedStatus);

                // Validation
                getSingleResourceResults.Data.Should().BeNull(
                    "Data is not null. It should be null as Bad Request 404!");
                getSingleResourceResults.Support.Should().BeNull(
                    "Support is not null. It should be null as Bad Request 404!");
            }
            else
            {
                getSingleResourceResults = await GetSingleResource<SingleResourceModel>(resourceId);

                // Validation
                getSingleResourceResults.Data.Id.Should().Be(resourceId,
                    $"Resource ID is null. Expected: {resourceId}");
                Logger.Text($"Id: {getSingleResourceResults.Data.Id}");

                getSingleResourceResults.Data.Name.Should().Be(name,
                    $"Name is null. Expected: {name}");
                Logger.Text($"Name: {getSingleResourceResults.Data.Name}");

                getSingleResourceResults.Data.Year.Should().Be(year,
                    $"Year is null. Expected: {year}");
                Logger.Text($"Year: {getSingleResourceResults.Data.Year}");

                getSingleResourceResults.Data.Color.Should().Be(color,
                    $"Color is null. Expected: {color}");
                Logger.Text($"Color: {getSingleResourceResults.Data.Color}");

                getSingleResourceResults.Data.Pantone_value.Should().Be(pantone_value,
                    $"Pantone is null. Expected: {pantone_value}");
                Logger.Text($"Pantone: {getSingleResourceResults.Data.Pantone_value}");
            }
        }

        public static IEnumerable<object[]> ListOfResources =>
        new List<object[]>
        {
            //          Resource Id   |       Name       |  Year  |    Color    |    Pantone value     |
            new object[] { 0,           "",                0,       "",          ""                     },
            new object[] { 1,           "cerulean",        2000,    "#98B2D1",   "15-4020"              },
            new object[] { 2,           "fuchsia rose",    2001,    "#C74375",   "17-2031"              },
            new object[] { 3,           "true red",        2002,    "#BF1932",   "19-1664"              },
            new object[] { 4,           "aqua sky",        2003,    "#7BC4C4",   "14-4811"              },
            new object[] { 5,           "tigerlily",       2004,    "#E2583E",   "17-1456"              },
            new object[] { 6,           "blue turquoise",  2005,    "#53B0AE",   "15-5217"              },
            new object[] { 7,           "sand dollar",     2006,    "#DECDBE",   "13-1106"              },
            new object[] { 8,           "chili pepper",    2007,    "#9B1B30",   "19-1557"              },
            new object[] { 9,           "blue iris",       2008,    "#5A5B9F",   "18-3943"              },
            new object[] { 10,          "mimosa",          2009,    "#F0C05A",   "14-0848"              },
            new object[] { 11,          "turquoise",       2010,    "#45B5AA",   "15-5519"              },
            new object[] { 12,          "honeysuckle",     2011,    "#D94F70",   "18-2120"              },
            new object[] { 13,          "",                0,       "",          ""                     },
        };
    }
}
