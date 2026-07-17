using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Interview.Web;

public class ApiClient(HttpClient httpClient, ProtectedLocalStorage localStorage)
{
    public async Task SetAuthorizeHeader()
    {
        var token = (await localStorage.GetAsync<string>("authToken")).Value;
        if(token != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
   public async Task<T> GetFromJsonAsync<T>(String path)
    {
        await SetAuthorizeHeader();
        return await httpClient.GetFromJsonAsync<T>(path); 
    }
    
    public async Task<T1> PostAsync<T1, T2>(String path, T2 postModel)
    {
        await SetAuthorizeHeader(); 
        var res = await httpClient.PostAsJsonAsync(path, postModel);
        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }
    public async Task<T1> UpdateAsync<T1,T2>(String path, T2 updateModel)
    {
        await SetAuthorizeHeader(); 
        var res = await httpClient.PutAsJsonAsync(path, updateModel);
        Console.WriteLine(res);
        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<T1>(await res.Content.ReadAsStringAsync());
        }
        else
        {
            Console.WriteLine("eror");
        }
            return default;
    }
    public async Task<T> DeleteAsync<T>(string path)
    {
        await SetAuthorizeHeader();
        return await httpClient.DeleteFromJsonAsync<T>(path);
    }
}

