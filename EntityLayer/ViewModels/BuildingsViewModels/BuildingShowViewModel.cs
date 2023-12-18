using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels.BuildingsViewModels
{
    public class BuildingShowViewModel
    {
        public int Id { get; set; }
        public Geometry geometry { get; set; }
    }
}
