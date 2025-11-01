using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaGuideDesigner.Services
{
    // A singleton service to manage downloading and caching images from the internet.
    // This improves performance and allows the application to work offline once images are cached.
    public class ImageCacheService
    {
        private static readonly Lazy<ImageCacheService> _instance = new Lazy<ImageCacheService>(() => new ImageCacheService());
        public static ImageCacheService Instance => _instance.Value;

        private readonly string _cacheDirectory;
        private readonly HttpClient _httpClient;

        private ImageCacheService()
        {
            _cacheDirectory = Path.Combine(Application.StartupPath, "ImageCache");
            Directory.CreateDirectory(_cacheDirectory); // Ensure the cache directory exists.
            _httpClient = new HttpClient();
        }

        // Generates a safe and unique local file path for a given URL.
        private string? GetCacheFilePath(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return null;
            }

            // Use a hash of the URL as the filename to avoid invalid characters and ensure uniqueness.
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(url));
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                var extension = Path.GetExtension(url);

                // Ensure a default extension if one isn't present in the URL
                if (string.IsNullOrEmpty(extension) || extension.Length > 5)
                {
                    extension = ".png";
                }

                return Path.Combine(_cacheDirectory, hashString + extension);
            }
        }

        // Asynchronously loads an image into a PictureBox, using the cache if available.
        public async Task LoadImageAsync(PictureBox pictureBox, string url)
        {
            if (pictureBox == null) return;

            try
            {
                var cachePath = GetCacheFilePath(url);

                if (cachePath == null)
                {
                    pictureBox.Image = null;
                    return;
                }

                if (File.Exists(cachePath))
                {
                    // Load from the local cache file.
                    // Reading into a memory stream prevents file locking.
                    using (var stream = new MemoryStream(await File.ReadAllBytesAsync(cachePath)))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    // Image not in cache, so download it.
                    var imageBytes = await _httpClient.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(cachePath, imageBytes);

                    // Load the newly downloaded image into the PictureBox.
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                // If anything goes wrong (e.g., download fails, invalid image data),
                // ensure the PictureBox is cleared.
                pictureBox.Image = null;
            }
        }
    }
}