using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Tests
{

    public class UserAPITests : BaseTest
    {
        private readonly RestClient _client = new("https://jsonplaceholder.typicode.com");

        [Test]
        public void TestGetListOfUsers()
        {
            Log.Info("Hello. This is the beginning of Test GetListOfUsers");
            Log.Info("Create and send request");
            var _request = new RestRequest("/users", Method.Get);
            var _response = _client.Get(_request);

            Console.WriteLine(_response.Content);
            
            Log.Info("Validate the HTTP response code equals to OK");
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Console.WriteLine("HttpStatusCode: " + _response.StatusCode);

            Log.Info("Validate that user contains the fields");
            Assert.That(_response.Content, Does.Contain("id"));
            Assert.That(_response.Content, Does.Contain("name"));
            Assert.That(_response.Content, Does.Contain("username"));
            Assert.That(_response.Content, Does.Contain("email"));
            Assert.That(_response.Content, Does.Contain("address"));
            Assert.That(_response.Content, Does.Contain("phone"));
            Assert.That(_response.Content, Does.Contain("website"));
            Assert.That(_response.Content, Does.Contain("company"));
        }

        [Test]
        public void TestValidateResponseHeader()
        {
            Log.Info("Hello. This is the beginning of Test ValidateResponseHeader");
            Log.Info("Create and send request");
            var _request = new RestRequest("/users", Method.Get);
            var _response = _client.Get(_request);

            Log.Info("Find the Content-Type header");
            Console.WriteLine("Response Headers:");
            foreach (Parameter header in _response.ContentHeaders)
            {
                Console.WriteLine($"{header.Name}: {header.Value}");
            }

            Parameter? contentTypeHeader = null;
            foreach (Parameter header in _response.ContentHeaders)
            {
                if (header.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    contentTypeHeader = header;
                    break;
                }
            }

            Log.Info("Validate that Content-Type Header value equals to 'application/json; charset=utf-8'");
            Assert.That(contentTypeHeader.Value.ToString(), Is.EqualTo("application/json; charset=utf-8"), "Unexpected value of Content-Type header");

            Log.Info("Validate the HTTP response code equals to OK");
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Console.WriteLine("HttpStatusCode: " + _response.StatusCode);
        }

        [Test]
        public void TestUsersContainsCompany()
        {
            Log.Info("Hello. This is the beginning of Test ValidateResponseHeader");
            Log.Info("Create and send request");
            var _request = new RestRequest("/users", Method.Get);
            var _response = _client.Get(_request);

            Log.Info("Validating the HTTP response code equals to OK");
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            Log.Info("Validating that the content of the response body is the array of 10 users");
            var usersArray = JArray.Parse(_response.Content);
            Assert.That(usersArray, Has.Count.EqualTo(10), "Response body does not contain array of 10 users.");

            HashSet<int> userIds = new HashSet<int>();
            int counter = 1;
            foreach (JObject user in usersArray.OfType<JObject>())
            {
                Log.Info("Validating that each user should be with different ID");
                var userId = user.Value<int>("id");
                Assert.That(userIds, Does.Not.Contain(userId), $"Duplicate user ID found: {userId}");
                userIds.Add(userId);

                Log.Info("Validating that each user should be with non-empty Name");
                var name = user.Value<string>("name");
                Assert.That(string.IsNullOrEmpty(name), Is.False, "User's name is empty.");

                Log.Info("Validating that each user should be with non-empty Username");
                var username = user.Value<string>("username");
                Assert.That(string.IsNullOrEmpty(username), Is.False, "User's username is empty.");

                Log.Info("Validating that each user contains the Company with non-empty");
                var company = user.Value<JObject>("company");
                var companyName = company?.Value<string>("name");
                Assert.That(string.IsNullOrEmpty(companyName), Is.False, "User's company name is empty.");

                Console.WriteLine($"{counter}. User: {user["name"]} ({user["username"]}), Company: {user["company"]["name"]}");
                counter++;
            }
        }

        [Test]
        public void TestCreateUser()
        {
            Log.Info("Hello. This is the beginning of Test CreateUser");
            Log.Info("Create and send request using POST method with Name and Username fields ");
            var _request = new RestRequest("/users", Method.Post);
            _request.AddJsonBody(new { name = "John Doe", username = "JohnDoe" });

           
            var _response = _client.Post(_request);
            var userData = JsonConvert.DeserializeObject<dynamic>(_response.Content);

            Console.WriteLine("User data: " + userData.ToString());
            
            Log.Info("Validate that response is not empty and contains the ID value");
            Assert.That(_response.Content, Is.Not.Null, "Response content should not be empty.");

            Log.Info("Validate that user receives 201 Created response code. There are no error messages");
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created), "Expected 201 Created response code.");
            Console.WriteLine("HttpStatusCode: " + _response.StatusCode);
            Assert.That(_response.Content, Does.Not.Contain("error"), "Response should not contain error message.");

        }

        [Test]
        public void TestResourceNotFound()
        {
            Log.Info("Hello. This is the beginning of Test ResourceNotFound");
            Log.Info("Create and send a request using GET method");
            var _request = new RestRequest("/invalidEndPoint", Method.Get);
            var _response = _client.Get(_request);

            Log.Info("Validating that user receives 404 Not Found response code.");
            Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), "Expected response code: 404 Not Found");
            Log.Info("Validating that there are no error messages");
            Assert.That(_response.ErrorMessage, Is.Null, "Error message should be null for 404 response");

            Console.WriteLine("HttpStatusCode: " + _response.StatusCode);
        }
    }
}