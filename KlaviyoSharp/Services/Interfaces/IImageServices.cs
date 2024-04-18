using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Interface for Klaviyo Image Services
/// </summary>
public interface IImageServices
{
    /// <summary>
    /// Get all images in an account.
    /// </summary>
    /// <param name="imageFields"></param>
    /// <param name="filter"></param>
    /// <param name="sort"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Image>> GetImages(List<string> imageFields = null,
                                          IFilter filter = null,
                                          string sort = null,
                                          CancellationToken cancellationToken = default);
    /// <summary>
    /// Import an image from a url or data uri.
    /// If you want to upload an image from a file, use the Upload Image From File endpoint instead.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Image>> UploadImageFromUrl(ImageFromUrl image,
                                               CancellationToken cancellationToken = default);
    /// <summary>
    /// Get the image with the given image ID.
    /// </summary>
    /// <param name="imageId"></param>
    /// <param name="imageFields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Image>> GetImage(string imageId,
                                     List<string> imageFields = null,
                                     CancellationToken cancellationToken = default);
    /// <summary>
    /// Update the image with the given image ID.
    /// </summary>
    /// <param name="imageId"></param>
    /// <param name="image"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Image>> UpdateImage(string imageId,
                                        PatchImage image,
                                        CancellationToken cancellationToken = default);
    /// <summary>
    /// Upload an image from a file.
    /// If you want to import an image from an existing url or a data uri, use the Upload Image From URL endpoint instead.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Image>> UploadImageFromFile(ImageFromFile image,
                                                CancellationToken cancellationToken = default);
}