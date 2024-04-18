using System.Net.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace KlaviyoSharp.Services;

/// <summary>
/// Klaviyo Image Services
/// </summary>
public class ImagesServices : KlaviyoServiceBase, IImageServices
{
    /// <summary>
    /// Constructor for Klaviyo Image Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public ImagesServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Image>> GetImages(List<string> imageFields = null,
                                                       IFilter filter = null,
                                                       string sort = null,
                                                       CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("image", imageFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTP<DataListObject<Image>>(HttpMethod.Get, "images/", _revision, query, null,
                                                                 null, cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<Image>> UploadImageFromUrl(ImageFromUrl image,
                                                            CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Image>>(HttpMethod.Post, "images/", _revision, null, null,
                                                             new DataObject<ImageFromUrl>(image), cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<Image>> GetImage(string imageId,
                                                  List<string> imageFields = null,
                                                  CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("image", imageFields);
        return await _klaviyoService.HTTP<DataObject<Image>>(HttpMethod.Get, $"images/{imageId}/", _revision,
                                                             query, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataObject<Image>> UpdateImage(string imageId,
                                                     PatchImage image,
                                                     CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Image>>(new("PATCH"), $"images/{imageId}/", _revision,
                                                             null, null, new DataObject<PatchImage>(image),
                                                             cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Image>> UploadImageFromFile(ImageFromFile image,
                                                             CancellationToken cancellationToken = default)
    {
        using var form = new MultipartFormDataContent
        {
            { new StringContent(image.Attributes.Name, Encoding.UTF8, MediaTypeNames.Text.Plain), "name" },
            { new StringContent(image.Attributes.Hidden ? "true" : "false", Encoding.UTF8, MediaTypeNames.Text.Plain), "hidden" }
        };

#if NETSTANDARD2_0
        //ReadAllBytesAsync not available in NETStandard 2.0

        using var fileContent = new ByteArrayContent(File.ReadAllBytes(image.Attributes.File));
#else
        using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(image.Attributes.File));
#endif
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        form.Add(fileContent, "file", Path.GetFileName(image.Attributes.File));

        return await _klaviyoService.HTTP<DataObject<Image>>(HttpMethod.Post, $"image-upload/", _revision,
                                                             null, null, form, cancellationToken);
    }
}
