using System.Reflection;
using System.Runtime.InteropServices;
using Bluegrams.Application.Attributes;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PinWin - Pin On Top")]
[assembly: AssemblyDescription("PinWin - Pin Any Window On Top of the Screen")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bluegrams")]
[assembly: AssemblyProduct("PinWin")]
[assembly: AssemblyCopyright("Copyright © 2020 Bluegrams")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if PORTABLE
[assembly: AppPortable(true)]
#else
[assembly: AppPortable(false)]
#endif
[assembly: ProductWebsite("https://pinwin.sourceforge.io")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7e06ba38-b308-43e9-b1a6-7851e7a8cbf2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.2.0.0")]
[assembly: AssemblyFileVersion("0.2.0.0")]
