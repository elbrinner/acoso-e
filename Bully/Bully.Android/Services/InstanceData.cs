using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bully.Droid.Interfaces;

namespace Bully.Droid.Services
{
    /// <summary>
    /// Servicio singleton para almacenar los datos relativos a la ejecucion actual
    /// </summary>
    public class InstanceData : IInstanceData
    {
        /// <summary>
        /// Obtiene o setea el context de la actividad actual
        /// </summary>
        /// <value>
        /// Context de la actividad actual
        /// </value>
        public Context ActualActivityContext { get; set; }
    }
}