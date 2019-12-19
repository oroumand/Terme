using System;
using System.Collections.Generic;
using System.Text;

namespace Terme.Core.Domain.Photos.Dtos
{
    public class DtoPhotoUrlSize
    {
        public DtoPhotoUrlSize(string photoUrl, int photoSize)
        {
            PhotoUrl = photoUrl;
            PhotoSize = photoSize;
        }

        public string PhotoUrl { get; set; }
        public int PhotoSize { get; set; }
    }
}
