﻿using DotVVM.Framework.Configuration;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using DotvvmAcademy.Web.Controls;

namespace DotvvmAcademy.Web
{
    public class DotvvmStartup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            config.Markup.AddMarkupControl("cc", "LangSwitcher", "Controls/LangSwitcher.dotcontrol");
            config.Markup.AddCodeControls("cc", typeof(SvgToHtml));
            config.Markup.AddCodeControls("cc", typeof(CodeTaskControl));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            config.Resources.Register("MonacoLoader", new ScriptResource(new FileResourceLocation("~/wwwroot/libs/monaco/loader.js")));
            config.Resources.Register("jQuery", new ScriptResource(new FileResourceLocation("~/wwwroot/libs/jquery/jquery.js")));
            config.Resources.Register("AppJS", new ScriptResource(new FileResourceLocation("~/wwwroot/scripts/app.min.js"))
            {
                Dependencies = new[] { "jQuery", "MonacoLoader" }
            });

            config.Resources.Register("StyleCSS", new StylesheetResource(new FileResourceLocation("~/wwwroot/css/style.min.css")));
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add(
                routeName: "Step",
                url: "{Language}/{Lesson}/{Step}",
                virtualPath: "Views/step.dothtml",
                defaultValues: new { Language = "en" },
                presenterFactory: LocalizablePresenter.BasedOnParameter("Language"));
            config.RouteTable.Add(
                routeName: "Default",
                url: "{Language:alpha}",
                virtualPath: "Views/default.dothtml",
                defaultValues: new { Language = "en" },
                presenterFactory: LocalizablePresenter.BasedOnParameter("Language"));
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));
        }
    }
}