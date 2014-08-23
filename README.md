OwinLinkyApi
============

This is the demo code supporting the presentation that is available here: https://www.slideshare.net/mastoj/owin-web-api-with-linky

There are a couple of goals with this code:
 
 * Show how the Owin works
 * Show the AppFunc
 * Show the Owin pipeline
 * Show simple middleware
 * Show self-hosting and iis hosting
 * Show to build a "level 3" REST application with Linky, https://github.com/zudio/Linky
 
The reason why the `WebHost` project can run at all is because I have this line:

    [assembly: OwinStartup(typeof(Startup), "Configuration")]
    
in the `Assembly.cs` file.
