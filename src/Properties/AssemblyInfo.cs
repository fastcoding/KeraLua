﻿using System.Reflection;

#if __MACOS__ || __TVOS__ || __WATCHOS__ || __IOS__

using Foundation;
[assembly: LinkerSafe]
#endif

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

