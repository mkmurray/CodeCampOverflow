Code Camp Overflow
==================

Sample code given at a [Utah Code Camp](http://utcodecamp.com/) presentation
introducing the .NET open-source MVC web framework
[FubuMVC](http://fubumvc.com/). FubuMVC (Fubu = for us, by us) focuses on rapid
development, plugability, and convention-based configuration. It tries to focus
on SOLID principles, composability, separation of concerns, DRY, and other
critical concepts of rapid, friction/pain-free web development. There are
several differentiating features from ASP.NET MVC, such as behavior chains,
packaging, partial requests, and much more.

The following content describes the different phases of the code base throughout
the presentation, which was done using Git tags at several milestones in the
historical timeline of change sets.  The purpose to this particular method of
presentation was to show important setup steps and also showcase various
features of the FubuMVC web framework at each milestone.  Once the repository is
brought down locally to your own machine, you can easily switch between the
different snapshots of the code base by issuing `git checkout tagNameHere`
commands.

Also, this site was designed with only Google Chrome web browser in mind. Any
modern web browser probably renders the sample web app just fine, but all bets
are off with regard to all versions of Internet Explorer.

##1-Barebones

This tag contains a code base with just enough infrastructure to run a blank
FubuMVC website and to enable browsing through the diagnostics screens. The
Visual Studio 2010 SP1 solution was created starting with a `Blank ASP.NET Web
Application` targeting .NET Framework 4.0; it is also set up for IIS Express.
The dependent libraries were obtained by grabbing the latest source (as of
[3/14/11, commit e66c7e9](https://github.com/DarthFubuMVC/fubumvc/commit/e66c7e9b713c54f6f390c86140a24c1ec0f53f99))
from [FubuMVC's GitHub repository](https://github.com/DarthFubuMVC/fubumvc), and
running the default task of the Rake build script found in the root of the
repository.  This is done simply with the command `rake` but requires that you
have Ruby and several Ruby Gems installed; an `InstallGems.bat` should be able
to help with getting the necessary Ruby Gems downloaded and installed.  Now the
needed DLL libraries to build a FubuMVC website can then be found in the `build`
directory, though currently that directory contains more than is necessary.  A
simple configuration of a Fubu web application can be found in the
`Global.asax.cs` file.

##2-ConventionsAndDiagnostics

At this milestone, we have the basics of a website coming together.  The most
important first step is to set up conventions in your `FubuRegistry` that drive
controller action method discovery, define routes with their inputs &
constraints, and wire up actions to output through view location.  FubuMVC has a
terrific set of diagnostics screens that help you visualize your conventions in
action.  They are accessed by appending `/_fubu` to the root URL of your web
site (`http://localhost:58324/_fubu`, for example). Another thing you will
notice about a FubuMVC code base is the discouragement of framework noise
(attributes, inheritence, etc.) as well as the opinionated requirements for
inputs and outputs for controller actions.  Three states of controller action
input/output models are allowed:

* One input/Zero output
* Zero input/One output
* One input/One output

Creating strongly-typed models for input and output allows for reuse between
controller actions and more effective application of behavior and policies via
conventions.

##3-Behaviors

The code base at this tag contains one of my favorite features of FubuMVC,
namely behaviors.  They are conventionally-applied nodes in the composable
request/response pipeline (called a behavior chain).  In FubuMVC, controller
actions are just another node in that pipeline; same goes for the return of a
view.  Fubu allows a developer great flexibility and control over the nodes in
any given behavior chain (like ordering, insertion, deletion, etc.).  At this
point in the web application, I have added a persistence behavior (that does
does session management before and after all action calls) that uses RavenDB
document database for extremly simple (and naive) object persistence.  I also
show how to conventionally apply a simple validation behavior that makes sure
text fields and areas are not blank upon form submission (and then unhelpfully
return a HTTP 500 Internal Server Error and error message that doesn't even take
you back to the page with the offending form inputs).

We started using FubuMVC behaviors at my current company in our ASP.NET MVC site
for a while before we were ready to begin migrating fully to Fubu.  A coworker
of mine bloged about the process
[here](http://paceyourself.net/2010/08/06/integrating-fubumvc-with-aspnet-mvc-part-1/)
and [here](http://paceyourself.net/2010/08/13/integrating-fubumvc-with-aspnet-mvc-part-2/),
and then later [created a more stream-lined and accessible
solution](https://github.com/bobpace/MvcToFubu).  Definitely worth a look if you
are hesitant to jump full-bore into FubuMVC all at once.

##4-HtmlConventions

This FubuMVC feature is a convenient way to clean up and allow reuse of markup
for specified object types, models with marker interfaces or attributes, or
matching model property names to specific criteria, again all applied via
conventions.  In this sample I show a few of the default conventions, like text
boxes for editors of string properties.  I also make custom display and editor
conventions for string properties that are named `Body` by using paragraph (`p`)
and `textarea` tags respectively.  Imagine being able to define automatic markup
generation for certain domain types you've defined or even just with those
rediculous `DateTime` objects in .NET (think calendar controls and other similar
possibilities).  This feature shares many of the same advantages as templating
and partial view solutions, but I would say that HtmlConventions are likely
meant to be used for simple and straight-forward markup generation and
templating.

