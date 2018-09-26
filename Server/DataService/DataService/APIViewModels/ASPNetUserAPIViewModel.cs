using AutoMapper;
using HmsService.ViewModels;
using Newtonsoft.Json;
using SkyWeb.DatVM.Mvc.Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.APIViewModels
{
    [MetadataType(typeof(ASPNetUserAPIViewModelMetaData))]
    public class ASPNetUserAPIViewModel : AspNetUserViewModel
    {


        class ASPNetUserAPIViewModelMetaData
        {
            [JsonIgnore]
            public string Id { get; set; }
            [JsonIgnore]
            public string Email { get; set; }
            [JsonIgnore]
            public bool EmailConfirmed { get; set; }
            [JsonIgnore]
            public string PasswordHash { get; set; }
            [JsonIgnore]
            public string SecurityStamp { get; set; }
        }

        public ASPNetUserAPIViewModel() : base() { }

        public ASPNetUserAPIViewModel(AspNetUserViewModel original) : this()
        {
            DependencyUtils.Resolve<IMapper>().Map((object)original, (object)this, this.EntityType, this.SelfType);
        }

    }
   
}
