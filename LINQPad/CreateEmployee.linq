<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Microsoft.AspNet.WebApi.Client</NuGetReference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var httpClient = new HttpClient
	{
		BaseAddress = new Uri("http://localhost:52119/")
	};
	
	httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	
	var result = await httpClient.PostAsJsonAsync(
		"/employees/",
		new CreateEmployee
	{
		Name = "Nancy2",
		Email = "nancy@example.org"
	});
	
	result.StatusCode.Dump();
	result.Content.ReadAsStringAsync().Dump();
}

public class CreateEmployee
{
	public string Name { get; set; }
	public string Email { get; set; }
}
