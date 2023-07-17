using NuGet.Frameworks;

namespace KlaviyoSharp.Tests;
[Trait("Category", "TemplateServices")]
public class TemplateServices_Tests : IClassFixture<TemplateServices_Tests_Fixture>
{
    private TemplateServices_Tests_Fixture Fixture { get; }
    public TemplateServices_Tests(TemplateServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task TemplateTests()
    {
        var newTemplate = Models.Template.Create();
        newTemplate.Attributes = new()
        {
            Name = $"Test Template {DateTime.Now}",
            EditorType = "CODE",
            Html = "<html><head></head><body><h1>Test {{ first_name|default:\"\" }}</h1></body></html>"
        };


        //Create
        var createdTemplate = await Fixture.AdminApi.TemplateServices.CreateTemplate(newTemplate);
        Assert.NotNull(createdTemplate.Data);

        //Get
        var templates = await Fixture.AdminApi.TemplateServices.GetTemplates();
        Assert.NotEmpty(templates.Data);
        var template = await Fixture.AdminApi.TemplateServices.GetTemplate(createdTemplate.Data.Id);
        Assert.NotNull(template.Data);

        //Update
        var updateTemplate = Models.Template.Create();
        updateTemplate.Id = template.Data.Id;
        updateTemplate.Attributes = new()
        {
            Name = $"{template.Data.Attributes.Name} Updated",
            Html = template.Data.Attributes.Html.Replace("h1", "h2")
        };
        var updatedTemplate = await Fixture.AdminApi.TemplateServices.UpdateTemplate(updateTemplate.Id, updateTemplate);
        Assert.Equal(template.Data.Attributes.Html.Replace("h1", "h2"), updatedTemplate.Data.Attributes.Html);

        //Render
        var renderObject = Models.Template.Create();
        renderObject.Attributes = new()
        {
            Id = template.Data.Id,
            Context = new() { { "first_name", "Test" } }
        };
        var render = await Fixture.AdminApi.TemplateServices.CreateTemplateRender(renderObject);
        Assert.Equal(updatedTemplate.Data.Attributes.Html.Replace("{{ first_name|default:\"\" }}", renderObject.Attributes.Context["first_name"]), render.Data.Attributes.Html);

        //Clone
        var cloneObject = Models.Template.Create();
        cloneObject.Attributes = new()
        {
            Id = template.Data.Id,
            Name = $"{template.Data.Attributes.Name} Cloned"
        };
        var clone = await Fixture.AdminApi.TemplateServices.CreateTemplateClone(cloneObject);

        //Delete
        await Fixture.AdminApi.TemplateServices.DeleteTemplate(clone.Data.Id);
        await Fixture.AdminApi.TemplateServices.DeleteTemplate(template.Data.Id);

        Assert.True(true);
    }

}
public class TemplateServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}