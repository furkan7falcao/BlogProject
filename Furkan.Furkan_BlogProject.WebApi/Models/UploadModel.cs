using Furkan.Furkan_BlogProject.WebApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.WebApi.Models
{
    public class UploadModel
    {
        public string newName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }

    }
}
