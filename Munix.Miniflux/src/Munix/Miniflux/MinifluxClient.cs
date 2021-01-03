namespace Munix.Miniflux
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Munix.Miniflux.Serializers;

    public class MinifluxClient
    {
        private static readonly IContentDeserializer<ErrorResponse> ErrorDeserializer
            = new JsonContentDeserializer<ErrorResponse>();

        public MinifluxClient(string baseUrl, string username, string password)
            : this(new Uri(baseUrl), username, password)
        {
        }

        public MinifluxClient(Uri baseUrl, string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty", nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));
            }

            this.BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            this.Username = username;
            this.Password = password;
        }

        public MinifluxClient(string baseUrl, string token)
            : this(new Uri(baseUrl), token)
        {
        }

        public MinifluxClient(Uri baseUrl, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException($"'{nameof(token)}' cannot be null or empty", nameof(token));
            }

            this.BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            this.Token = token;
        }

        public Uri BaseUrl { get; }

        public string Username { get; }

        public string Password { get; }

        public string Token { get; }

        public async Task<DiscoveredFeed[]> DiscoverSubscriptionsAsync(
            DiscoverSubscriptionsRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<DiscoveredFeed[]>(
                HttpMethod.Post,
                "/v1/discover",
                request).ConfigureAwait(false);
        }

        public async Task<Feed[]> GetFeedsAsync()
        {
            return await this.GetRequest<Feed[]>("/v1/feeds").ConfigureAwait(false);
        }

        public async Task<Feed> GetFeedAsync(GetFeedRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.GetRequest<Feed>(
                $"/v1/feeds/{request.FeedId}").ConfigureAwait(false);
        }

        public async Task<Icon> GetFeedIconAsync(GetIconRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.GetRequest<Icon>(
                $"/v1/feeds/{request.FeedId}/icon").ConfigureAwait(false);
        }

        public async Task<FeedReference> CreateFeedAsync(CreateFeedRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<FeedReference>(
                HttpMethod.Post,
                "/v1/feeds",
                request,
                new JsonContentSerializer(true)).ConfigureAwait(false);
        }

        public async Task UpdateFeedAsync(UpdateFeedRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this.SendRequest<object>(
                HttpMethod.Put,
                $"/v1/feeds/{request.FeedId}",
                request,
                new JsonContentSerializer(true)).ConfigureAwait(false);
        }

        public async Task RefreshFeedAsync(RefreshFeedRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this.SendRequest<object>(
                HttpMethod.Post,
                $"/v1/feeds/{request.FeedId}/refresh").ConfigureAwait(false);
        }

        public async Task RefreshAllFeedsAsync()
        {
            await this.SendRequest<object>(
                HttpMethod.Post,
                "/v1/feeds/refresh").ConfigureAwait(false);
        }

        public async Task<Entry> GetFeedEntryAsync(GetFeedEntryRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.GetRequest<Entry>(
                $"/v1/feeds/{request.FeedId}/entries/{request.EntryId}").ConfigureAwait(false);
        }

        public async Task<Entry> GetEntryAsync(GetEntryRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.GetRequest<Entry>(
                $"/v1/entries/{request.EntryId}").ConfigureAwait(false);
        }

        public async Task<EntryList> GetFeedEntriesAsync(GetFeedEntriesRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var query = BuildQueryString(request);
            return await this.GetRequest<EntryList>(
                $"/v1/feeds/{request.FeedId}/entries{query}").ConfigureAwait(false);
        }

        public async Task<EntryList> GetEntriesAsync(GetEntriesRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var query = BuildQueryString(request);
            return await this.GetRequest<EntryList>($"/v1/entries{query}").ConfigureAwait(false);
        }

        public async Task UpdateEntriesAsync(UpdateEntriesRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this.SendRequest<object>(
                HttpMethod.Put,
                "/v1/entries",
                request).ConfigureAwait(false);
        }

        public async Task ToggleEntryBookmarkAsync(ToggleEntryBookmarkRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this.SendRequest<object>(
                HttpMethod.Put,
                $"/v1/entries/{request.EntryId}/bookmark").ConfigureAwait(false);
        }

        public async Task<Category[]> GetCategoriesAsync()
        {
            return await this.GetRequest<Category[]>("/v1/categories").ConfigureAwait(false);
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<Category>(
                HttpMethod.Post,
                "/v1/categories",
                request).ConfigureAwait(false);
        }

        public async Task<Category> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<Category>(
                HttpMethod.Put,
                "/v1/categories",
                request).ConfigureAwait(false);
        }

        public async Task DeleteCategoryAsync(DeleteCategoryRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this.SendRequest<Category>(
                HttpMethod.Delete,
                $"/v1/categories/{request.CategoryId}").ConfigureAwait(false);
        }

        public async Task<string> OpmlExportAsync()
        {
            return await this.SendRequest<string>(
                HttpMethod.Get,
                "/v1/export",
                deserializer: new TextContentDeserializer()).ConfigureAwait(false);
        }

        public async Task<string> OpmlImportAsync(OpmlImportRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<string>(
                HttpMethod.Post,
                "/v1/import",
                request.Content,
                serializer: new TextContentSerializer("text/xml")).ConfigureAwait(false);
        }

        public async Task<User> CreateUserAsync(CreateUserRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<User>(HttpMethod.Post, "/v1/users", request)
                .ConfigureAwait(false);
        }

        public async Task<User> UpdateUserAsync(UpdateUserRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.SendRequest<User>(
                HttpMethod.Put,
                $"/v1/users/{request.UserId}",
                request,
                new JsonContentSerializer(true)).ConfigureAwait(false);
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return await this.GetRequest<User>("/v1/me").ConfigureAwait(false);
        }

        public async Task<User> GetUserAsync(GetUserRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await this.GetRequest<User>($"/v1/users/{request.UserId}").ConfigureAwait(false);
        }

        public async Task<User[]> GetUsersAsync()
        {
            return await this.GetRequest<User[]>($"/v1/users").ConfigureAwait(false);
        }

        public async Task DeleteUsersAsync(DeleteUserRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await this
                .SendRequest<object>(HttpMethod.Delete, $"/v1/users/{request.UserId}")
                .ConfigureAwait(false);
        }

        public async Task<string> HealthCheckAsync()
        {
            return await this.SendRequest<string>(
                HttpMethod.Get,
                $"/healthcheck",
                deserializer: new TextContentDeserializer())
                .ConfigureAwait(false);
        }

        public async Task<string> GetVersionAsync()
        {
            return await this.SendRequest<string>(
                HttpMethod.Get,
                $"/version",
                deserializer: new TextContentDeserializer())
                .ConfigureAwait(false);
        }

        private static string BuildQueryString(GetEntriesRequest request)
        {
            var parameters = new Dictionary<string, string>();

            AddConverterParameter(
                parameters,
                "status",
                request.EntryStatus,
                EntryStatus.None,
                EnumConverters.EntryStatusConverter);
            AddNullableParameter(parameters, "offset", request.Offset);
            AddNullableParameter(parameters, "limit", request.Limit);
            AddConverterParameter(
                parameters,
                "order",
                request.SortingOption,
                SortingOption.None,
                EnumConverters.SortingOptionConverter);
            AddConverterParameter(
                parameters,
                "direction",
                request.SortingDirection,
                SortingDirection.None,
                EnumConverters.SortingDirectionConverter);
            AddNullableParameter(parameters, "before", request.Before);
            AddNullableParameter(parameters, "after", request.After);
            AddNullableParameter(parameters, "before_entry_id", request.BeforeEntryId);
            AddNullableParameter(parameters, "after_entry_id", request.AfterEntryId);
            AddBoolParameter(parameters, "starred", request.Starred);
            AddStringParameter(parameters, "search", request.Search);
            AddNullableParameter(parameters, "category_id", request.CategoryId);

            return parameters.Any() ? "?" + string.Join("&", parameters.Select(x => $"{x.Key}={Uri.EscapeUriString(x.Value)}")) : string.Empty;
        }

        private static void AddConverterParameter<T>(
            IDictionary<string, string> parameters,
            string name,
            T value,
            T defaultValue,
            EnumConverter<T> converter)
            where T : struct
        {
            if (!value.Equals(defaultValue))
            {
                parameters.Add(name, converter.ToString(value));
            }
        }

        private static void AddNullableParameter<T>(
            IDictionary<string, string> parameters,
            string name,
            T? value)
            where T : struct, IFormattable
        {
            if (value.HasValue)
            {
                parameters.Add(name, value.Value.ToString("G", CultureInfo.InvariantCulture));
            }
        }

        private static void AddBoolParameter(IDictionary<string, string> parameters, string name, bool? value)
        {
            if (value.HasValue)
            {
                parameters.Add(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        private static void AddStringParameter(
            IDictionary<string, string> parameters,
            string name,
            string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parameters.Add(name, value);
            }
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = this.BaseUrl;
            if (this.Token != null)
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", this.Token);
            }
            else
            {
                var byteArray = Encoding.ASCII.GetBytes($"{this.Username}:{this.Password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(byteArray));
            }

            return client;
        }

        private async Task<T> GetRequest<T>(string url)
            where T : class
        {
            return await this.SendRequest<T>(HttpMethod.Get, url).ConfigureAwait(false);
        }

        private async Task<T> SendRequest<T>(
            HttpMethod method,
            string url,
            object parameters = null,
            IContentSerializer serializer = null,
            IContentDeserializer<T> deserializer = null)
            where T : class
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty", nameof(url));
            }

            var ser = serializer ?? new JsonContentSerializer(false);
            var des = deserializer ?? new JsonContentDeserializer<T>();

            using HttpRequestMessage msg = new HttpRequestMessage(method, url);
            if (parameters != null)
            {
                msg.Content = ser.Serialize(parameters);
            }

            T result = default(T);
            using (var client = this.CreateClient())
            {
                var response = await client.SendAsync(msg).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        string content = await response.Content
                            .ReadAsStringAsync()
                            .ConfigureAwait(false);

                        result = des.Deserialize(content);
                    }
                }
                else
                {
                    string content = await response.Content
                        .ReadAsStringAsync()
                        .ConfigureAwait(false);
                    var error = ErrorDeserializer.Deserialize(content);
                    throw new MinifluxException(response.StatusCode, error.ErrorMessage);
                }
            }

            return result;
        }
    }
}
