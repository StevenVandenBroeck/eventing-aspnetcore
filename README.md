# Eventing Toolbox

Toolbox for events in ASP.NET Core.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Installation

To add the toolbox to a project, you add the package to the project.json :

``` json 
"dependencies": {
    "Eventing":  "1.0.0"
 }
``` 

In Visual Studio you can also use the NuGet Package Manager to do this.

## Usage

Register the service in the **ConfigureServices** method in the **Startup** class:

With the default options:
``` csharp
  services.AddEventing(opt => opt.RegisterExceptionHandler<MyEventingExceptionHandler>());
```

Since the events are published asynchronously, your code will not be able to catch them. You can create a handler that implements the **IEventingExceptionHandler** interface and register it during Startup.

