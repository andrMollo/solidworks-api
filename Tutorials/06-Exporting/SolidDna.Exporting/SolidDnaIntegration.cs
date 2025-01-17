﻿using CADBooster.SolidDna;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static CADBooster.SolidDna.SolidWorksEnvironment;

namespace SolidDna.Exporting
{
    /// <summary>
    /// Register as a SolidWorks Add-in
    /// </summary>
    [Guid("6D769D97-6103-4495-AACD-63CDD0EC396B"), ComVisible(true)]  // Replace the GUID with your own.
    public class SolidDnaAddinIntegration : SolidAddIn
    {
        /// <summary>
        /// Specific application start-up code
        /// </summary>
        public override void ApplicationStartup()
        {

        }

        public override void PreLoadPlugIns()
        {

        }

        public override void PreConnectToSolidWorks()
        {

        }
    }

    /// <summary>
    /// Register as SolidDna Plug-in
    /// </summary>
    public class MySolidDnaPlugin : SolidPlugIn
    {
        #region Public Properties

        /// <summary>
        /// My Add-in description
        /// </summary>
        public override string AddInDescription => "An example of Command Items and exporting";

        /// <summary>
        /// My Add-in title
        /// </summary>
        public override string AddInTitle => "SolidDNA Exporting";

        #endregion

        #region Connect To SolidWorks

        public override void ConnectedToSolidWorks()
        {
            // Part commands
            var partGroup = Application.CommandManager.CreateCommandGroupAndTabs(
                title: "Export Part",
                items: new List<CommandManagerItem>(new[] {

                    new CommandManagerItem {
                        Name = "DXF",
                        Tooltip = "DXF",
                        ImageIndex = 0,
                        Hint = "Export part as DXF",
                        VisibleForDrawings = false,
                        VisibleForAssemblies = false,
                        OnClick = () =>
                        {
                            FileExporting.ExportPartAsDxf();
                        }
                    },

                    new CommandManagerItem {
                        Name = "STEP",
                        Tooltip = "STEP",
                        ImageIndex = 2,
                        Hint = "Export part as STEP",
                        VisibleForDrawings = false,
                        VisibleForAssemblies = false,
                        OnClick = () =>
                        {
                            FileExporting.ExportModelAsStep();
                        }
                    },

                }),
                flyoutItems: null,
                iconListsPath: "icons{0}.png",
                hint: "Export parts in other formats",
                tooltip: "Such as DXF, STEP and IGES");

            // Assembly commands
            var assemblyGroup = Application.CommandManager.CreateCommandGroupAndTabs(
                title: "Export Assembly",
                items: new List<CommandManagerItem>(new[] {

                    new CommandManagerItem {
                        Name = "STEP",
                        Tooltip = "STEP",
                        ImageIndex = 2,
                        Hint = "Export assembly as STEP",
                        VisibleForDrawings = false,
                        VisibleForParts = false,
                        OnClick = () =>
                        {
                            FileExporting.ExportModelAsStep();
                        }
                    },

                }),
                flyoutItems: null,
                iconListsPath: "icons{0}.png",
                hint: "Export assemblies in other formats",
                tooltip: "Such as Step");

            // Drawing commands
            var drawingGroup = Application.CommandManager.CreateCommandGroupAndTabs(
                title: "Export Drawing",
                items: new List<CommandManagerItem>(new[] {

                    new CommandManagerItem {
                        Name = "PDF",
                        Tooltip = "PDF",
                        Hint = "Export drawing as PDF",
                        ImageIndex = 1,
                        VisibleForParts = false,
                        VisibleForAssemblies = false,
                        OnClick = () =>
                        {
                            FileExporting.ExportDrawingAsPdf();
                        }
                    },

                }),
                flyoutItems: null,
                iconListsPath: "icons{0}.png",
                hint: "Export drawing to other formats",
                tooltip: "Such as PDF");
        }

        public override void DisconnectedFromSolidWorks()
        {

        }

        #endregion
    }
}
