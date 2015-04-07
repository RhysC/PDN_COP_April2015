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
	
	var result = await httpClient.PutAsJsonAsync(
		"/employees/",
		new UpdateEmployeeName
	{
		Id = 8,
		Name = "aaaa",
	});
	
	result.StatusCode.Dump();
	result.Content.ReadAsStringAsync().Dump();
}

public class UpdateEmployeeName
{
	public int Id { get; set; }
	public string Name { get; set; }
}
