using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCMS.Web.Helpers
{
    /// <summary>
    /// Extensiones de ayuda para la generación de Url. En las vistas SIEMPRE
    /// hay que usar estensiones del objeto Url, NUNCA poner directamente las urls
    /// </summary>
    public static class UrlExtensions
    {
        /// <summary>
        /// Página de inicio de la web pública
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>url de la home de la web pública</returns>
        public static string Home(this UrlHelper helper)
        {
            return helper.Action("Index", "Home");
        }

        /// <summary>
        /// iniciar sesion (log in)
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>url de login</returns>
        public static string LogOn(this UrlHelper helper)
        {
            return helper.Action("LogOn", "Account");
        }

        /// <summary>
        /// cerra sesion (log out)
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>url de logout</returns>
        public static string LogOff(this UrlHelper helper)
        {
            return helper.Action("LogOff", "Account");
        }

        /// <summary>
        /// Obtiene la dirección de un recurso de imagen
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <param name="fileName">nombre de archivo de la imagen con la extension</param>
        /// <returns>url completa de la imagen</returns>
        public static string Image(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/Images/{0}", fileName));
        }

        /// <summary>
        /// Obtiene la url de una hoja de estilos
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <param name="fileName">nombre de archivo de la hoja d eestilos con la extension CSS</param>
        /// <returns>url completa de la hoja de estilos</returns>
        public static string Stylesheet(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/Css/{0}", fileName));
        }

        /// <summary>
        /// Obtiene la url de un archivo de scripts (normalmente JS)
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <param name="fileName">nombre de archivo del script con su extensión</param>
        /// <returns>url completa de la hoja de estilos</returns>
        public static string Script(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Scripts/{0}", fileName));
        }

        /// <summary>
        /// Url del script del CKEditor
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>Url del script del CKEditor</returns>
        public static string CKEditorScript(this UrlHelper helper)
        {
            return helper.Content("~/Scripts/ckeditor/ckeditor.js");
        }

        /// <summary>
        /// Url del perfil de Twitter
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>Url del perfil de Twitter</returns>
        public static string TwitterProfile(this UrlHelper helper)
        {
            return "https://twitter.com/#!/mydevblog";
        }

        /// <summary>
        /// Url de la página de FB
        /// </summary>
        /// <param name="helper">referencia a la clase que se extiende</param>
        /// <returns>Url de la página de FB</returns>
        public static string FacebookProfile(this UrlHelper helper)
        {
            return "http://facebook.com";
        }
        
    }

}