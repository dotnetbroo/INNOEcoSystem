using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.Interfaces.Accounts;
using INNOEcoSystem.Service.Services.Accaunts.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace INNOEcoSystem.Service.Services.Users;

public class SmsService : ISmsService
{
    private readonly IConfiguration configuration;
    private readonly IRepository<User> repository;

    public SmsService(IConfiguration configuration, IRepository<User> repository)
    {
        this.configuration = configuration;
        this.repository = repository;
    }
    public async Task<string> GenerateTokenAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://notify.eskiz.uz/api/auth/login");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent($"{configuration["SmsConfig:Email"]}"), "email"); // configuration["TelegramBotConfig:BotToken"];
        content.Add(new StringContent($"{configuration["SmsConfig:Password"]}"), "password");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();   // Check for whether send or not

        var token = await response.Content.ReadAsStringAsync();

        var jsonToken = JsonConvert.DeserializeObject<JObject>(token);

        var tokenGenereted = jsonToken["data"]["token"].ToString();

        return tokenGenereted;
    }

    public async Task<bool> SendAsync(Sms message)
    {
        var userSms = await repository.SelectAsync(u => u.IsDeleted == false);

        var token = await GenerateTokenAsync();

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://notify.eskiz.uz/api/message/sms/send");

        // Add the Authorization header with the Bearer token
        request.Headers.Add("Authorization", $"Bearer {token}");

        using var content = new MultipartFormDataContent();
        content.Add(new StringContent($"{message.PhoneNumber}"), "mobile_phone");
        content.Add(new StringContent($"{message.Message}\n{message.Url}"), "message");
        content.Add(new StringContent($"{configuration["SmsConfig:from"]}"), "from");
        request.Content = content;
        await client.SendAsync(request);

        return true;
    }
}
