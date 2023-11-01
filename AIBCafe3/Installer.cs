using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
//using System.Configuration.Install;


namespace AIBCafe3
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();

        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            ////Opens the specified client configuration file as a Configuration object
            //Configuration _config = ConfigurationManager.OpenExeConfiguration(
            //    //Gets the source directory of the installation from the default context parameters
            //    Context.Parameters["assemblypath"]);

            //// Get the connectionStrings section.  Connection strings are saved under the <connectionStrings> tag
            //ConfigurationSection section = _config.GetSection("connectionStrings");

            ////Ensures that the section is not already protected
            //if (!section.SectionInformation.IsProtected)
            //{
            //    //Uses the Windows Data Protection API (DPAPI) to encrypt the configuration section
            //    //using a machine-specific secret key
            //    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //    _config.Save();
            //}
        }

    }
}



//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Configuration;
////using System.Configuration.Install;


//namespace AIBCafe3
//{
//    [RunInstaller(true)]
//    public partial class Installer : System.Configuration.Install.Installer
//    {
//        public Installer()
//        {
//            InitializeComponent();

//        }
//        public override void Install(IDictionary stateSaver)
//        {
//            base.Install(stateSaver);
//#if DEBUG
//            string applicationName =
//                Environment.GetCommandLineArgs()[0];
//#else
//           string applicationName =
//          Environment.GetCommandLineArgs()[0]+ ".exe";
//#endif

//            //Opens the specified client configuration file as a Configuration object
//            string exePath = System.IO.Path.Combine(Environment.CurrentDirectory, applicationName);

//            Configuration _config = ConfigurationManager.OpenExeConfiguration(exePath);
//            // System.Configuration.Install.Context.Parameters["assemblypath"]);

//            // Get the connectionStrings section.  Connection strings are saved under the <connectionStrings> tag
//            ConfigurationSection section = _config.GetSection("connectionStrings");

//            //Ensures that the section is not already protected
//            if (!section.SectionInformation.IsProtected)
//            {
//                //Uses the Windows Data Protection API (DPAPI) to encrypt the configuration section
//                //using a machine-specific secret key
//                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
//                _config.Save();
//            }
//        }

//    }
//}
