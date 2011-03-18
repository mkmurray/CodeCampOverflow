Code Camp Overflow
===============

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
