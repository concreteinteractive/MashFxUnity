/******************************************
  * uWebKit 
  * (c) 2012 8 bit buffalo
  * josh@uwebkit.com
*******************************************/

#import "UWKWebEngine.h"

@implementation AppController (UWKAppController)

- (void)applicationDidFinishLaunching:(UIApplication *)application {
	printf_console("-> UWK applicationDidFinishLaunching()\n");

	if([UIDevice currentDevice].generatesDeviceOrientationNotifications == NO)
		[[UIDevice currentDevice] beginGeneratingDeviceOrientationNotifications];

	[self startUnity:application];

	UWKWebEngine.sInstance.appController = self;
}

@end
